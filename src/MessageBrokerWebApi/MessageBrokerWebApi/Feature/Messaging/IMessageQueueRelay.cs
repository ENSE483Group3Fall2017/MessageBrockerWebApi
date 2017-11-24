using System.Threading.Tasks;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Feature.Messaging
{
    public interface IMessageQueueRelay
    {
        Task PostAsync<T>(T message);
    }
}
