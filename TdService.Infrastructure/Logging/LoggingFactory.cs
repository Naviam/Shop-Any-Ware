﻿// -----------------------------------------------------------------------
// <copyright file="LoggingFactory.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    /// <summary>
    /// Logger factory.
    /// </summary>
    public class LoggingFactory
    {
        /// <summary>
        /// Logger class.
        /// </summary>
        private static ILogger localLogger;

        /// <summary>
        /// Initialize log factory.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public static void InitializeLogFactory(ILogger logger)
        {
            localLogger = logger;
        }

        /// <summary>
        /// Get logger.
        /// </summary>
        /// <returns>
        /// Loger class.
        /// </returns>
        public static ILogger GetLogger()
        {
            return localLogger;
        }
    }
}