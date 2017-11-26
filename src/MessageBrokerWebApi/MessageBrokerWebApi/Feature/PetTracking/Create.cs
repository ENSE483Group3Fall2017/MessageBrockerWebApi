using AutoMapper;
using ENSE483Group3Fall2017.MessageBrokerWebApi.Infrastructure.Messaging;
using ENSE483Group3Fall2017.PetTracking.Contracts.V1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Feature.PetTracking
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid BatchId { get; set; }

            public string GpsCoordinates { get; set; }

            public DateTime FrameStart { get; set; }

            public DateTime FrameEnd { get; set; }

            public IEnumerable<TrackingItem> TrackingItems { get; set; }

            public class TrackingItem
            {
                public Guid Id { get; set; }

                public string BeaconId { get; set; }

                public decimal Proximity { get; set; }

                public DateTime Created { get; set; }
            }
        }

        public class CommandHandler : ICancellableAsyncRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly IMessageQueueRelay<TrackingBatch> _queueRelay;

            public CommandHandler(IMapper mapper, IMessageQueueRelay<TrackingBatch> queueRelay)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _queueRelay = queueRelay ?? throw new ArgumentNullException(nameof(queueRelay));
            }

            public Task Handle(Command command, CancellationToken cancellationToken)
            {
                var message = _mapper.Map<Command, TrackingBatch>(command);
                return _queueRelay.PostAsync(message);
            }
        }
    }
}