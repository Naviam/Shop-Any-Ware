// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmazonSimpleEmailService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AmazonSimpleEmailService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Email
{
    using System.Linq;

    using Amazon.Runtime;
    using Amazon.SimpleEmail.Model;

    /// <summary>
    /// The amazon simple email service.
    /// </summary>
    public class AmazonSimpleEmailService : IEmailService
    {
        /// <summary>
        /// The credentials.
        /// </summary>
        private readonly BasicAWSCredentials credentials = new BasicAWSCredentials("", "");

        /// <summary>
        /// The send mail.
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
            using (var client = Amazon.AWSClientFactory.CreateAmazonSimpleEmailServiceClient(this.credentials))
            {
                var request = new SendEmailRequest();
                var destination = new Destination(to.Split(';', ',').ToList());
                request.WithDestination(destination);
                request.WithSource(@from);
                var message = new Message();
                message.WithSubject(new Content(subject));
                var html = new Body { Html = new Content(body) };
                message.WithBody(html);
                request.WithMessage(message);
                request.WithReturnPath("noreply@shopanyware.com");
                client.SendEmail(request);
            }
        }
    }
}
