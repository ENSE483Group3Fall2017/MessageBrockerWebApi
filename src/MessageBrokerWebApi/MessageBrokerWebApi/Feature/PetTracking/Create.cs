using AutoMapper;
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

            public CommandHandler(IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public Task Handle(Command message, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}