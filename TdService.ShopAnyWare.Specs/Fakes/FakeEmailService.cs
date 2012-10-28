// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeEmailService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Fake email service to testing purpose.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Fakes
{
    using System.Collections.Generic;

    using TdService.Infrastructure.Email;

    /// <summary>
    /// Fake email service to testing purpose.
    /// </summary>
    public class FakeEmailService : IEmailService
    {
        /// <summary>
        /// Gets or sets the sent mails.
        /// </summary>
        public List<Mail> SentMails { get; set; }

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
        public void SendMail(string from, string to, string subject, string body)
        {
            if (this.SentMails == null)
            {
                this.SentMails = new List<Mail>();
            }

            this.SentMails.Add(new Mail { Body = body, From = from, To = to, Subject = subject });
        }
    }
}