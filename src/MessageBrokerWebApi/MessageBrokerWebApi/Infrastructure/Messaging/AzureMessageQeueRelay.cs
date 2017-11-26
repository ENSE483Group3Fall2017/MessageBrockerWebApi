using ENSE483Group3Fall2017.Messaging.Contracts;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Infrastructure.Messaging
{
    public class AzureMessageQeueRelay<T> : IMessageQueueRelay<T>
    {
        private readonly QueueClient _queueClient;

        public AzureMessageQeueRelay(AzureMessageQeueRelayConfiguration configuration)
        {
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _queueClient = new QueueClient(configuration.ConnectionString, configuration.QueueName);
        }

        public Task PostAsync(T message)
        {
            var envelop = new Envelop<T>(message);
            var messageContent = JsonConvert.SerializeObject(envelop as Envelop);
            var messageBody = Encoding.UTF8.GetBytes(messageContent);

            return _queueClient.SendAsync(new Message(messageBody));
        }
    }

    public class AzureMessageQeueRelayConfiguration
    {
        public AzureMessageQeueRelayConfiguration(string connectionString, string queueName)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(queueName)) throw new ArgumentException(nameof(queueName));
            ConnectionString = connectionString;
            QueueName = queueName;
        }

        public string ConnectionString { get; }

        public string QueueName { get; }
    }
}
