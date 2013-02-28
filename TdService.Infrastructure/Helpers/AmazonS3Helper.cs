namespace TdService.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon;
    using Amazon.S3.Model;

    /// <summary>
    /// S3 helper
    /// </summary>
    public static class AmazonS3Helper
    {
        public static void SaveFile(string awsAccessKey, string awsSecretKey, string bucket, string path, Stream fileStream)
        {
            using (var amazonClient = AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
            {
                var createFileRequest = new PutObjectRequest()
                {
                    CannedACL = S3CannedACL.PublicRead,
                    Timeout = Int32.MaxValue
                };
                createFileRequest.WithKey(path);
                createFileRequest.WithBucketName(bucket);
                createFileRequest.WithInputStream(fileStream);
                amazonClient.PutObject(createFileRequest);
            }
        }

        public static void CopyFile(string awsAccessKey, string awsSecretKey, string sourceBucket, string sourceKey, string destinationBucket, string destinationKey)
        {
            using (var amazonClient = AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
            {
                var copyRequest = new CopyObjectRequest()
                {
                    CannedACL = S3CannedACL.PublicRead
                };
                copyRequest.WithSourceBucket(sourceBucket);
                copyRequest.WithSourceKey(sourceKey);
                copyRequest.WithDestinationBucket(destinationBucket);
                copyRequest.WithDestinationKey(destinationKey);
                amazonClient.CopyObject(copyRequest);
            }
        }
    }
}
