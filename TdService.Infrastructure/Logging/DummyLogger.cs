// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyLogger.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The dummy logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using System;

    /// <summary>
    /// The dummy logger.
    /// </summary>
    public class DummyLogger : ILogger
    {
        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Log(string message)
        {
        }

        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Error(string message, Exception exception)
        {
        }
    }
}
