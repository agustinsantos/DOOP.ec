using Doopec.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Doopec.Rtps.RtpsTransport
{
    public static class RtpsEngineFactory
    {
        private static IRtpsEngine theInstance;

        public static IRtpsEngine Instance
        {
            get
            {
                if (theInstance == null)
                { theInstance = RtpsEngineFactory.CreateEngine(null); }
                return theInstance;
            }
        }

        public static IRtpsEngine CreateEngine(IDictionary<string, Object> environment)
        {
            DDSConfigurationSection ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;
            RTPSConfigurationSection rtpsConfig = Doopec.Configuration.RTPSConfigurationSection.Instance;
            string transportProfile = ddsConfig.Domains[0].TransportProfile.Name;
            string className = rtpsConfig.Transports[transportProfile].Type;
            if (string.IsNullOrWhiteSpace(className))
            {
                // no implementation class name specified
                throw new ApplicationException("Please Set the RTPS engine type property in the settings.");
            }

            Type ctxClass = Type.GetType(className, true);


            // --- Instantiate new object --- //
            try
            {
                // First, try a constructor that will accept the environment.
                object newInstance = Activator.CreateInstance(ctxClass, environment);
                if (newInstance != null)
                    return (IRtpsEngine)newInstance;
            }
            catch (Exception)
            {
                /* No Map constructor found; try a no-argument constructor
                 * instead.
                 * 
                 * Get the constructor and call it explicitly rather than
                 * calling Class.newInstance(). The latter propagates all
                 * exceptions, even checked ones, complicating error handling
                 * for us and the user.
                 */
                object newInstance = Activator.CreateInstance(ctxClass);
                return (IRtpsEngine)newInstance;
            }
            throw new ApplicationException("Exception building a RTPS engine using " + className);
        }
    }

    public class RtpsEngine : IRtpsEngine
    {
        protected RtpsDiscovery discoveryModule = new RtpsDiscovery();


        public IRtpsDiscovery DiscoveryModule
        {
            get { return discoveryModule; }
        }
    }
}
