using System.Collections.Generic;
using SerilogLab.Model;

namespace SerilogLab.Service
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        void CreateEvent(Event eve);
    }
}