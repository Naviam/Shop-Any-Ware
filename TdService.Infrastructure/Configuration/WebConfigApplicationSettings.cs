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
    public class WebConfigApplicationSettings
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
    }
}