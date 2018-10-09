using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SerilogLab.Model;
using SerilogLab.Service;

namespace SerilogLab.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private ILogger _log;
        private IEventService _eventService;

        public EventController(ILogger log, IEventService eventService)
        {
            _eventService = eventService;
            _log = log.ForContext<EventController>();
        }
        
        // GET api/event
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            var result = _eventService.GetAllEvents();
            return Ok(result);
        }

        // GET api/event/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Event3";
        }

        // POST api/event
        [HttpPost]
        public void Post([FromBody]Event eve)
        {
            
            //非結構化Log
            _log.Information($"[Non Structured Data] New Event information EventName:{eve.EventName}, StartTime:{eve.StartTime}");
            
            //結構化Log∞
            _log.Information("[Structured Data] New Event information {@event}", eve);
            
            
            var random = new Random();
            Thread.Sleep(random.Next(100, 1000));
            
        }

        // PUT api/event/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/event/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}