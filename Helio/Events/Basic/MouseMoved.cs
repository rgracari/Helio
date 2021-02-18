using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events.Basic
{
    class MouseMoved : Event
    {
        public MouseState MouseState { get; }

        public MouseMoved(MouseState mouseState) : base(EventType.MOUSE_MOVED)
        {
            MouseState = mouseState;
        }
    }
}
