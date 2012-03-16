// -----------------------------------------------------------------------
// <copyright file="SMTPService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Email
{
    using System.Net.Mail;

    /// <summary>
    /// SMTP Service.
    /// </summary>
    public class SmtpService : IEmailService
    {
        /// <summary>
        /// Send email.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        public void SendMail(string @from, string to, string subject, string body)
        {
            var message = new MailMessage { Subject = subject, Body = body };
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}