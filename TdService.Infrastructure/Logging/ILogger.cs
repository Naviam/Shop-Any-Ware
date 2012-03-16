// -----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    /// <summary>
    /// Interface for logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Log(string message);
    }
}