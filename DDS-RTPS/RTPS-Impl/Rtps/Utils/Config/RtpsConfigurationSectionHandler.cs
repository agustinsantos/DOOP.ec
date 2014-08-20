using Doopec.Rtps.Utils.Config;
using System.Configuration;

namespace Doopec.Rtps.Config
{
    /// <summary>
    /// Class to register for the RTPS section of the configuration file
    /// </summary>
    /// <remarks>
    /// The RTPS section of the configuration file needs to have a section
    /// handler registered. This is the section handler used. It simply returns
    /// the XML element that is the root of the section.
    /// </remarks>
    /// <example>
    /// Example of registering the RTPS section handler :
    /// <code lang="XML" escaped="true">
    /// <configuration>
    ///		<configSections>
    ///			<section name="Doopec.Rtps" type="Doopec.Rtps.Config.RtpsConfigurationSectionHandler, Doopec" />
    ///		</configSections>
    ///		<Doopec.Rtps>
    ///			RTPS configuration XML goes here
    ///		</Doopec.Rtps>
    /// </configuration>
    /// </code>
    /// </example>
    public class RtpsConfigurationSectionHandler : ConfigurationSection
    {
        #region Public Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RtpsConfigurationSectionHandler"/> class.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Default constructor.
        /// </para>
        /// </remarks>
        public RtpsConfigurationSectionHandler()
        {
        }

        #endregion Public Instance Constructors

        [ConfigurationProperty("Doopec.Rtps.SPDP")]
        public SpdpConfig SPDPConfig
        {
            get { return (SpdpConfig)this["Doopec.Rtps.SPDP"]; }
        }

         [ConfigurationProperty("Doopec.Rtps.Writer", IsDefaultCollection = true, IsKey = false, IsRequired = false)]
        public WriterConfig WriterConfiguration
        {
            get { return (WriterConfig)this["Doopec.Rtps.Writer"]; }
        }

        [ConfigurationProperty("Doopec.Rtps.Reader", IsDefaultCollection = true, IsKey = false, IsRequired = false)]
        public ReaderConfig ReaderConfiguration
        {
            get { return (ReaderConfig)this["Doopec.Rtps.Reader"]; }
        }
    }
}
