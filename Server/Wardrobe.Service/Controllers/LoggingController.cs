using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.Model.Entities.Logging;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Logging")]
    public class LoggingController : BaseWardrobeController
    {
        private readonly ILoggingService _service;
        public LoggingController(ILoggingService service, ILogger<LoggingController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<LogMessage> Get()
        {
            return _service.GetLogMessages();
        }

        [HttpGet("{id}", Name = "GetLogMessage")]
        public LogMessage Get(int id)
        {
            return _service.GetLogMessageById(id);
        }

        [HttpPost]
        public void Post([FromBody]LogMessage value)
        {
            _service.AddLogMessage(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]LogMessage value)
        {
            _service.UpdateLogMessage(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteLogMessage(id);
        }
    }
}
