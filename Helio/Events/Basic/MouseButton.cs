using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events.Basic
{
    class MouseButton : Event
    {
        public MouseState MouseState { get; }

        public MouseButton(MouseState mouseState) : base(EventType.MOUSE_PRESSED)
        {
            MouseState = mouseState;
        }
    }
}
