using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    ///			<section name="RTPS" type="Doopec.Rtps.Config.RtpsConfigurationSectionHandler, Doopec" />
    ///		</configSections>
    ///		<RTPS>
    ///			RTPS configuration XML goes here
    ///		</RTPS>
    /// </configuration>
    /// </code>
    /// </example>
    public class RtpsConfigurationSectionHandler : IConfigurationSectionHandler
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

        #region Implementation of IConfigurationSectionHandler

        /// <summary>
        /// Parses the configuration section.
        /// </summary>
        /// <param name="parent">The configuration settings in a corresponding parent configuration section.</param>
        /// <param name="configContext">The configuration context when called from the ASP.NET configuration system. Otherwise, this parameter is reserved and is a null reference.</param>
        /// <param name="section">The <see cref="XmlNode" /> for the RTPS section.</param>
        /// <returns>The <see cref="XmlNode" /> for the RTPS section.</returns>
        /// <remarks>
        /// <para>
        /// Returns the <see cref="XmlNode"/> containing the configuration data,
        /// </para>
        /// </remarks>
        public object Create(object parent, object configContext, XmlNode section)
        {
            return section;
        }

        #endregion Implementation of IConfigurationSectionHandler
    }
}
