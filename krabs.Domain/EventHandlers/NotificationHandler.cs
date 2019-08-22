using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using krabs.Domain.Events;
using MediatR;

namespace krabs.Domain.EventHandlers
{
    public class NotificationHandler : INotificationHandler<NotifyEvent>
    {
        public Task Handle(NotifyEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Notify: {notification.NotifyText}");
            return Task.CompletedTask;
        }
    }
}