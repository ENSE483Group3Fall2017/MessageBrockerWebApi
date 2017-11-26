using System.Threading.Tasks;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Infrastructure.Messaging
{
    public interface IMessageQueueRelay<T>
    {
        Task PostAsync(T message);
    }
}
