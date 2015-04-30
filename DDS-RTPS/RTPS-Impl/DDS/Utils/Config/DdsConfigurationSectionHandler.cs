using Common.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Doopec.Dds.Config
{
    /// <summary>
    /// Class to register for the DDS section of the configuration file
    /// </summary>
    /// <remarks>
    /// The /// <summary> section of the configuration file needs to have a section
    /// handler registered. This is the section handler used. It simply returns
    /// the XML element that is the root of the section.
    /// </remarks>
    /// <example>
    /// Example of registering the /// <summary> section handler :
    /// <code lang="XML" escaped="true">
    /// <configuration>
    ///		<configSections>
    ///			<section name="Doopec.Ddds" type="Doopec.Dds.Config.DdsConfigurationSectionHandler, Doopec" />
    ///		</configSections>
    ///		<Doopec.Ddds>
    ///			DDS configuration XML goes here
    ///		</Doopec.Ddds>
    /// </configuration>
    /// </code>
    /// </example>
    public class DdsConfigurationSectionHandler : ConfigurationSection
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Public Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DdsConfigurationSectionHandler"/> class.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Default constructor.
        /// </para>
        /// </remarks>
        public DdsConfigurationSectionHandler()
        {
        }

        #endregion Public Instance Constructors


        [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = false)]
        public DdsSettingCollection Settings
        {
            get
            {
                return this[""] as DdsSettingCollection;
            }
        }

        public int DefaultDomainId
        {
            get
            {
                int rst = 0;
                if (this.Settings["DefaultDomainId"] != null && !string.IsNullOrWhiteSpace(this.Settings["DefaultDomainId"].Value))
                    if (!int.TryParse(this.Settings["DefaultDomainId"].Value, out rst))
                        log.WarnFormat("Invalid Domain Id: {0}. It should be a integer value.");
                return rst;
            }
        }

        [ConfigurationProperty("Doopec.Dds.QoS.Domain", IsKey = false, IsRequired = false)]
        public QoSConfig QoSDomainCollection
        {
            get
            {
                return (QoSConfig)this["Doopec.Dds.QoS.Domain"];
            }
        }

        [ConfigurationProperty("Doopec.Dds.QoS.Topic", IsKey = false, IsRequired = false)]
        public QoSConfig QoSTopicCollection
        {
            get
            {
                return (QoSConfig)this["Doopec.Dds.QoS.Topic"];
            }
        }

        [ConfigurationProperty("Doopec.Dds.QoS.DataWriter", IsKey = false, IsRequired = false)]
        public QoSConfig QoSDataWriterCollection
        {
            get
            {
                return (QoSConfig)this["Doopec.Dds.QoS.DataWriter"];
            }
        }

        [ConfigurationProperty("Doopec.Dds.QoS.DataReader", IsKey = false, IsRequired = false)]
        public QoSConfig QoSDataReaderCollection
        {
            get
            {
                return (QoSConfig)this["Doopec.Dds.QoS.DataReader"];
            }
        }
    }

    [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add",
     CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DdsSettingCollection : KeyValueConfigurationCollection
    {

    }
}
