﻿// --------------------------------------------------------------------------------------------------------------------
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
