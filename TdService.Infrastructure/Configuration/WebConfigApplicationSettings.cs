// -----------------------------------------------------------------------
// <copyright file="WebConfigApplicationSettings.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Web config application settings.
    /// </summary>
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        /// <summary>
        /// Gets LoggerName.
        /// </summary>
        public string LoggerName
        {
            get
            {
                return ConfigurationManager.AppSettings["LoggerName"];
            }
        }

        /// <summary>
        /// Gets the USPS user name.
        /// </summary>
        public string UspsUserName
        {
            get
            {
                return ConfigurationManager.AppSettings["UspsUserName"];
            }
        }

        /// <summary>
        /// Gets the USPS production url.
        /// </summary>
        public string UspsProductionUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["UspsProductionUrl"];
            }
        }
    }
}