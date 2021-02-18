using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events
{
    interface IEventDispatcher
    {
        void Dispatch(EventType eventType, Predicate<Event> handler);
    }
}
