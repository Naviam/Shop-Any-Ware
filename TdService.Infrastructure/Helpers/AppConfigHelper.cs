// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppConfigHelper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   App config helper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    using System.Configuration;

    /// <summary>
    /// App config helper
    /// </summary>
    public static class AppConfigHelper
    {
        /// <summary>
        /// Gets the amazon S3 bucket.
        /// </summary>
        public static string AmazonS3Bucket
        {
            get
            {
                return ConfigurationManager.AppSettings["AmazonS3Bucket"];
            }
        }

        /// <summary>
        /// Gets the AWS access key.
        /// </summary>
        public static string AwsAccessKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSAccessKey"];
            }
        }

        /// <summary>
        /// Gets the AWS secret key.
        /// </summary>
        public static string AwsSecretKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSSecretKey"];
            }
        }

        /// <summary>
        /// Gets the AWS url.
        /// </summary>
        public static string AwsUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["AWSUrl"];
            }
        }
    }
}
