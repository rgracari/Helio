using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Events.Basic
{
    class KeyboardPressed : Event
    {
        public KeyboardState KeyboardState { get; }

        public KeyboardPressed(KeyboardState keyboardState) : base(EventType.KEYBOARD_PRESSED)
        {
            KeyboardState = keyboardState;
        }
    }
}
