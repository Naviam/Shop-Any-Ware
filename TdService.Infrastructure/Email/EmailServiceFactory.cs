// -----------------------------------------------------------------------
// <copyright file="EmailServiceFactory.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Email
{
    /// <summary>
    /// Email service factory.
    /// </summary>
    public class EmailServiceFactory
    {
        /// <summary>
        /// Email service.
        /// </summary>
        private static IEmailService localEmailService;

        /// <summary>
        /// Initialize email service factory.
        /// </summary>
        /// <param name="emailService">
        /// The email service.
        /// </param>
        public static void InitializeEmailServiceFactory(IEmailService emailService)
        {
            localEmailService = emailService;
        }

        /// <summary>
        /// Get email service.
        /// </summary>
        /// <returns>
        /// Email service.
        /// </returns>
        public static IEmailService GetEmailService()
        {
            return localEmailService;
        }
    }
}