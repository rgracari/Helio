using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events
{
    public interface IEventListener
    {
        public void Event(Event evnt);
    }
}
