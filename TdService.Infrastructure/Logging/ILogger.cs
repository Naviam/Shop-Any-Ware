﻿// -----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using System;

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

        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        void Error(string message, Exception exception);
    }
}