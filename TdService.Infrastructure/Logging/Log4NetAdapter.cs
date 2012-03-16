// -----------------------------------------------------------------------
// <copyright file="Log4NetAdapter.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using Configuration;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// TODO: Update summary.
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
    }
}
