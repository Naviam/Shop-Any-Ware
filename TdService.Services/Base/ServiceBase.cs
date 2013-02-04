using TdService.Infrastructure.Logging;

namespace TdService.Services.Base
{
    public abstract class ServiceBase
    {
        /// <summary>
        /// The logger.
        /// </summary>
        protected readonly ILogger logger;

        public ServiceBase(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
