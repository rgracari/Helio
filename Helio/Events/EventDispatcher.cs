using Helio.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private Event _evnt;

        public EventDispatcher(Event eventItem)
        {
            _evnt = eventItem;
        }

        public void Dispatch(EventType eventType, Predicate<Event> handler)
        {
            if (_evnt.IsHandled == true)
                return;

            if (_evnt.GetEventType() == eventType)
                _evnt.IsHandled = handler(_evnt);
        }
    }
}
