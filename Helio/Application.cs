using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Helio.Events;
using Helio.Core;

namespace Helio
{
    public class Application : Game
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch? _spriteBatch;

        private GameLogic _gameLogic;
        //private EventManager _eventManager;

        public Application()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _gameLogic = new GameLogic();
            //_eventManager = new EventManager();
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


            // Before updating the game we are gonna do this
            // IEventManager::Get()->VTick(20);

            _gameLogic.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameView gameView in _gameLogic.GetGameViews())
            {
                gameView.Draw(gameTime, _spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
