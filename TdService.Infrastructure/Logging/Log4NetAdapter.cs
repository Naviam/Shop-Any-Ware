// -----------------------------------------------------------------------
// <copyright file="Log4NetAdapter.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using System;

    using Configuration;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Log4net adapter.
    /// </summary>
    public class Log4NetAdapter : ILogger
    {
        /// <summary>
        /// Logger implementation.
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetAdapter"/> class.
        /// </summary>
        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            this.log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        /// <summary>
        /// Add log info message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Log(string message)
        {
            this.log.Info(message);
        }

        /// <summary>
        /// Log the exception.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Error(string message, Exception exception)
        {
            this.log.Error(message, exception);
        }
    }
}
