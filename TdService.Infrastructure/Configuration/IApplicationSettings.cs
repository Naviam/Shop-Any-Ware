// -----------------------------------------------------------------------
// <copyright file="IApplicationSettings.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Configuration
{
    /// <summary>
    /// Interface for application settings provider.
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// Gets LoggerName.
        /// </summary>
        string LoggerName { get; }
    }
}