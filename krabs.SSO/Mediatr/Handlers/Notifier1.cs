using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace krabs.SSO.Mediatr.Handlers
{
    public class Notifier1 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier1. Message : {notification.NotifyText}");
            return Task.CompletedTask;
        }
    }
}
