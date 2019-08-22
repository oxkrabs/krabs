using System;
using krabs.Domain.Core.Events;

namespace krabs.Domain.Events
{
    public class NotifyEvent : Event
    {
        public string NotifyText { get; }
        
        public NotifyEvent(string notifyText)
        {
            AggregateId = Guid.NewGuid();
            NotifyText = notifyText;
        }
    }
}