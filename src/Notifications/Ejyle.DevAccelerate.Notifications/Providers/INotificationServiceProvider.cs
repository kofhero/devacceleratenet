using Ejyle.DevAccelerate.Notifications.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Providers
{
    public interface INotificationServiceProvider<TKey, TMessage>
        where TMessage : INotificationMessage<TKey>
    {
        Task SendAsync(TMessage message);
        Task SendAsync(List<TMessage> message);
    }
}
