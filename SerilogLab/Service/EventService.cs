using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Serilog;
using SerilogLab.Model;
using System.Linq;


namespace SerilogLab.Service
{
    public class EventService : IEventService
    {
        private IList<Event> _eventList;
        
        public EventService()
        {
            _eventList = new List<Event>()
            {
                new Event()
                {
                    EventId = 1,
                    EventName = "A Team vs B Team",
                    UserCreated = "LBJ",
                    StartTime = DateTime.Now
                },
                new Event()
                {
                    EventId = 2,
                    EventName = "C Team vs D Team",
                    UserCreated = "Curry",
                    StartTime = DateTime.Now
                }
            };
        }
        
        public IEnumerable<Event> GetAllEvents()
        {
            var processTime = new Random();
            Thread.Sleep(processTime.Next(100,1000));

            return _eventList;
        }
        
        public void CreateEvent(Event eve)
        {
            var processTime = new Random();
            Thread.Sleep(processTime.Next(100,1000));
            
            _eventList.Add(eve);
            
        }
    }
}