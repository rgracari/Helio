using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events
{
    public abstract class Event
    {
        private EventType _eventType;
        
        public bool IsHandled { get; set; }

        protected Event(EventType eventType)
        {
            _eventType = eventType;
            IsHandled = false;
        }

        public EventType GetEventType()
        {
            return _eventType;
        }
    }
}
