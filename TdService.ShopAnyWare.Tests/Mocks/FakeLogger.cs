// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeLogger.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The fake logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Mocks
{
    using System;

    using TdService.Infrastructure.Logging;

    /// <summary>
    /// The fake logger.
    /// </summary>
    public class FakeLogger : ILogger
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
