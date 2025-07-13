using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using SQSTest.Models;

namespace SQSTest.Services
{
    public class OrderService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _queueUrl;

        public OrderService(IOptions<AwsOptions> options)
        {
            var awsOptions = options.Value;
            var accessKey = awsOptions.AccessKey;
            var secretKey = awsOptions.SecretKey;
            var region = awsOptions.Region;
            _queueUrl = awsOptions.QueueUrl;

            var sqsConfig = new AmazonSQSConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(region) };
            _sqsClient = new AmazonSQSClient(accessKey, secretKey, sqsConfig);
        }

        public async Task<string> CreateOrder(Order order)
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = order.OrderDetails
            };

            var response = await _sqsClient.SendMessageAsync(sendMessageRequest);
            return response.MessageId;
        }
    }
}
