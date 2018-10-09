using System;

namespace SerilogLab.Model
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public string UserCreated { get; set; }
        
    }
}