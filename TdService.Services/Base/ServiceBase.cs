// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The service base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Base
{
    using TdService.Infrastructure.Logging;

    /// <summary>
    /// The service base.
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// The logger.
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        protected ServiceBase(ILogger logger)
        {
            this.Logger = logger;
        }
    }
}
