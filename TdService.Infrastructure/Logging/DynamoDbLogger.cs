// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamoDbLogger.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The dynamo db logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using System;

    /// <summary>
    /// The dynamo DB logger.
    /// </summary>
    public class DynamoDbLogger : ILogger
    {
        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Warn(string message)
        {
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Debug(string message)
        {
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Info(string message)
        {
        }

        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Trace(string message)
        {
        }

        /// <summary>
        /// The error.
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
