// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLogAmazonDynamoDbTarget.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the NLogAmazonDynamoDbTarget type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Logging
{
    using Amazon;
    using Amazon.DynamoDB.DocumentModel;
    using NLog;
    using NLog.Common;
    using NLog.Targets;

    /// <summary>
    /// The n log amazon dynamo DB target.
    /// </summary>
    [Target("DynamoDb")]
    public class NLogAmazonDynamoDbTarget : TargetWithLayout
    {
        /// <summary>
        /// Gets or sets the amazon access key id.
        /// </summary>
        public string AmazonAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the amazon secret access key.
        /// </summary>
        public string AmazonSecretAccessKey { get; set; }

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="logEvent">
        /// The log event.
        /// </param>
        protected override void Write(AsyncLogEventInfo logEvent)
        {
            using (var client = AWSClientFactory.CreateAmazonDynamoDBClient(this.AmazonAccessKeyId, this.AmazonSecretAccessKey))
            {
                var table = Table.LoadTable(client, "TdService_Logs");
                var log = this.CreateLogDocument(logEvent.LogEvent);

                table.BeginPutItem(log, ar => { }, null);
            }

            base.Write(logEvent);
        }

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="logEvent">
        /// The log event.
        /// </param>
        protected override void Write(LogEventInfo logEvent)
        {
            using (var client = AWSClientFactory.CreateAmazonDynamoDBClient(this.AmazonAccessKeyId, this.AmazonSecretAccessKey))
            {
                var table = Table.LoadTable(client, "TdService_Logs");
                var log = this.CreateLogDocument(logEvent);
                table.PutItem(log);
            }

            base.Write(logEvent);
        }

        /// <summary>
        /// The create log document.
        /// </summary>
        /// <param name="logEvent">
        /// The log event.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        private Document CreateLogDocument(LogEventInfo logEvent)
        {
            var log = new Document();
            log["Id"] = logEvent.SequenceID;
            log["TimeStamp"] = logEvent.TimeStamp;
            log["Level"] = logEvent.Level.ToString();
            log["Message"] = logEvent.Message;
            log["UserStackFrameNumber"] = logEvent.UserStackFrameNumber;
            if (logEvent.UserStackFrame != null)
            {
                log["FileName"] = logEvent.UserStackFrame.GetFileName();
                log["FileLineNumber"] = logEvent.UserStackFrame.GetFileLineNumber();
                log["FileColumnNumber"] = logEvent.UserStackFrame.GetFileColumnNumber();
                log["MethodName"] = logEvent.UserStackFrame.GetMethod().Name;
            }

            if (logEvent.Exception != null)
            {
                log["ExceptionMessage"] = logEvent.Exception.Message;
                log["ExceptionHResult"] = logEvent.Exception.HResult;
                log["ExceptionStackTrace"] = logEvent.Exception.StackTrace;
                log["ExceptionSource"] = logEvent.Exception.Source;
            }

            log["UserEmail"] = logEvent.Properties["UserEmail"].ToString();
            log["OrderId"] = logEvent.Properties["OrderId"].ToString();
            log["PackageId"] = logEvent.Properties["PackageId"].ToString();
            log["TransactionId"] = logEvent.Properties["TransactionId"].ToString();

            return log;
        }
    }
}