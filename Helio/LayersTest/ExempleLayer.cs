using Helio.Events;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Layers
{
    class ExempleLayer : ILayer
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public void Event(Event evnt)
        {
            EventDispatcher dispatcher = new EventDispatcher(evnt);
            dispatcher.Dispatch(EventType.MOUSE_PRESSED, (evnt) => OnMousePressed(evnt));
        }

        public bool OnMousePressed(Event evnt)
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
