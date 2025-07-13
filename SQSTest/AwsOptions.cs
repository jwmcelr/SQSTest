namespace SQSTest
{
    // Options class for AWS configuration
    public class AwsOptions
    {
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string QueueUrl { get; set; } = string.Empty;
    }
}
