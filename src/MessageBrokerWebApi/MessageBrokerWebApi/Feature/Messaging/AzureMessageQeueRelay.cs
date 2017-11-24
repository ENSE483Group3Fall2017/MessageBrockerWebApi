using ENSE483Group3Fall2017.Messaging.Contracts;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Feature.Messaging
{
    public class AzureMessageQeueRelay : IMessageQueueRelay
    {
        private readonly QueueClient _queueClient;

        public AzureMessageQeueRelay(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);
        }

        public Task PostAsync<T>(T message)
        {
            var envelop = new Envelop<T>(message);
            var messageContent = JsonConvert.SerializeObject(envelop as Envelop);
            var messageBody = Encoding.UTF8.GetBytes(messageContent);

            return _queueClient.SendAsync(new Message(messageBody));
        }
    }
}
