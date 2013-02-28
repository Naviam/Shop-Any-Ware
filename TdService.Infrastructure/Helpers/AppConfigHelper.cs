namespace TdService.Infrastructure.Helpers
{
    using System.Configuration;


    /// <summary>
    /// App config helper
    /// </summary>
    public static class AppConfigHelper
    {
        public static string AmazonS3Bucket
        {
            get
            {
                return ConfigurationManager.AppSettings["AmazonS3Bucket"];
            }
        }

        public static string AWSAccessKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSAccessKey"];
            }
        }

        public static string AWSSecretKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSSecretKey"];
            }
        }

        public static string AWSUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSUrl"];
            }
        }
    }
}
