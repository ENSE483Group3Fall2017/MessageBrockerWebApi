using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MessageBrokerWebApi.Feature.Ping
{
    [Produces("application/json")]
    [Route("api/Ping")]
    public class PingController : Controller
    {
        // GET: api/Ping
        [HttpGet]
        public IEnumerable<string> Get() =>
            new string[] { "Pong", DateTime.Now.ToString() };
    }
}