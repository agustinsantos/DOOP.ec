using log4net;
using System;
using System.Reflection;

namespace ExampleDDS.Common
{
    class ExampleApp
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public virtual void RunExample(string[] args)
        {
            LogAssemblyInfo();
        }

        private static void LogAssemblyInfo()
        {
            AssemblyName mainAn = Assembly.GetExecutingAssembly().GetName();
            log.InfoFormat("This program is Name={0}, Version={1}, Culture={2}, PublicKey token={3}",
                        mainAn.Name, mainAn.Version, mainAn.CultureInfo.Name, (BitConverter.ToString(mainAn.GetPublicKeyToken())));
            log.Info("Referenced assemblies:");
            foreach (AssemblyName an in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                string name = an.Name.ToLowerInvariant();
                if (name == "log4net" || name.Contains("doopec") || name.Contains("dds") || name.Contains("rtps"))
                    log.InfoFormat("Name={0}, Version={1}, Culture={2}, PublicKey token={3}",
                        an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
            }
        }
    }
}
