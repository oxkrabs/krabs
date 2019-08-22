using krabs.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using krabs.Domain.Core.Commands;
using krabs.Domain.Core.Events;
using MediatR;

namespace krabs.Infrastructure.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        //private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator)
        {
            //_eventStore = eventStore;
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
//            if (!@event.MessageType.Equals("DomainNotification"))
//                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
