using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace krabs.Domain.Core.Events
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
