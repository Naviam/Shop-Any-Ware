// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmazonS3Helper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   S3 helper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    using System.IO;

    using Amazon;
    using Amazon.S3.Model;

    /// <summary>
    /// S3 helper
    /// </summary>
    public static class AmazonS3Helper
    {
        /// <summary>
        /// The save file.
        /// </summary>
        /// <param name="awsAccessKey">
        /// The AWS access key.
        /// </param>
        /// <param name="awsSecretKey">
        /// The AWS secret key.
        /// </param>
        /// <param name="bucket">
        /// The bucket.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="fileStream">
        /// The file stream.
        /// </param>
        public static void SaveFile(string awsAccessKey, string awsSecretKey, string bucket, string path, Stream fileStream)
        {
            using (var amazonClient = AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
            {
                var createFileRequest = new PutObjectRequest
                                            {
                                                CannedACL = S3CannedACL.PublicRead,
                                                Timeout = int.MaxValue
                                            };
                createFileRequest.WithKey(path);
                createFileRequest.WithBucketName(bucket);
                createFileRequest.WithInputStream(fileStream);
                amazonClient.PutObject(createFileRequest);
            }
        }

        /// <summary>
        /// The copy file.
        /// </summary>
        /// <param name="awsAccessKey">
        /// The AWS access key.
        /// </param>
        /// <param name="awsSecretKey">
        /// The AWS secret key.
        /// </param>
        /// <param name="sourceBucket">
        /// The source bucket.
        /// </param>
        /// <param name="sourceKey">
        /// The source key.
        /// </param>
        /// <param name="destinationBucket">
        /// The destination bucket.
        /// </param>
        /// <param name="destinationKey">
        /// The destination key.
        /// </param>
        public static void CopyFile(string awsAccessKey, string awsSecretKey, string sourceBucket, string sourceKey, string destinationBucket, string destinationKey)
        {
            using (var amazonClient = AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
            {
                var copyRequest = new CopyObjectRequest { CannedACL = S3CannedACL.PublicRead };
                copyRequest.WithSourceBucket(sourceBucket);
                copyRequest.WithSourceKey(sourceKey);
                copyRequest.WithDestinationBucket(destinationBucket);
                copyRequest.WithDestinationKey(destinationKey);
                amazonClient.CopyObject(copyRequest);
            }
        }
    }
}