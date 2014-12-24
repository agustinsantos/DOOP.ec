using Doopec.Dds.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps
{
    public interface IRtpsEngine
    {
    }

    public class RtpsEngine
    {
        private static IRtpsEngine theInstance;

        public static IRtpsEngine Instance
        {
            get
            {
                if (theInstance == null)
                { theInstance = CreateEngine(null); }
                return theInstance;
            }
        }

        private RtpsEngine()
        {
        }

        public static IRtpsEngine CreateEngine(IDictionary<string, Object> environment)
        {
            DdsConfigurationSectionHandler ddsConfig = ConfigurationManager.GetSection("Doopec.Dds") as DdsConfigurationSectionHandler;
            string className = ddsConfig.Settings["TransportEngine"].Value;
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
}
