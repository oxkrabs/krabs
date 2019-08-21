using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace krabs.SSO.Mediatr.Handlers
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
