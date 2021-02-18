using System;
using System.Collections.Generic;
using System.Text;

using Helio.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Layers
{
    public interface ILayer : IEventListener
    {
        public void Update(GameTime gameTime);

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
