using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Helio.Events;

namespace Helio
{
    public class Application : Game
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch? _spriteBatch;

        private EventManager _eventManager;

        public Application()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _eventManager = new EventManager();
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
