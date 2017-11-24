using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Feature.PetTracking
{
    [Route("api/[controller]")]
    public class PetTrackingController : Controller
    {
        private readonly IMediator _mediator;

        public PetTrackingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST api/values
        [HttpPost]
        public Task Post(Create.Command command) =>
            _mediator.Send(command);
    }
}