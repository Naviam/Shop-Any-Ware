namespace TdService.Infrastructure.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon;
    using Amazon.DynamoDB.DocumentModel;
    using NLog;
    using NLog.Targets;

    [Target("DynamoDb")]
    public class NLogAmazonDynamoDbTarget : TargetWithLayout
    {
        public NLogAmazonDynamoDbTarget()
        {
        }

        //[Required]
        public string AmazonAccessKeyId { get; set; }

        public string AmazonSecretAccessKey { get; set; }

        protected override void Write(NLog.Common.AsyncLogEventInfo logEvent)
        {
            using (var client = AWSClientFactory.CreateAmazonDynamoDBClient(this.AmazonAccessKeyId, this.AmazonSecretAccessKey))
            {
                Table table = Table.LoadTable("TdService_Logs");
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

                table.BeginPutItem(log, );
            }

            base.Write(logEvent);
        }

        protected override void Write(LogEventInfo logEvent)
        {
            using (var client = AWSClientFactory.CreateAmazonDynamoDBClient(this.AmazonAccessKeyId, this.AmazonSecretAccessKey))
            {
                Table table = Table.LoadTable("TdService_Logs");
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

                table.PutItem(log);
            }

            base.Write(logEvent);
        }
    }
}