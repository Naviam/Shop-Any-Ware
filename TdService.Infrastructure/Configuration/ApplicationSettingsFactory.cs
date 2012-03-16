// -----------------------------------------------------------------------
// <copyright file="ApplicationSettingsFactory.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Configuration
{
    /// <summary>
    /// Application Settings Factory.
    /// </summary>
    public class ApplicationSettingsFactory
    {
        /// <summary>
        /// Application Settings.
        /// </summary>
        private static IApplicationSettings localApplicationSettings;

        /// <summary>
        /// Initialize application settings factory.
        /// </summary>
        /// <param name="applicationSettings">
        /// The application settings.
        /// </param>
        public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings)
        {
            localApplicationSettings = applicationSettings;
        }

        /// <summary>
        /// Get application settings.
        /// </summary>
        /// <returns>
        /// Application settings.
        /// </returns>
        public static IApplicationSettings GetApplicationSettings()
        {
            return localApplicationSettings;
        }
    }
}