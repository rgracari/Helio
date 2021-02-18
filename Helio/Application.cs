using Helio.Events.Basic;
using Helio.Layers;
using Helio.Log;
using Helio.Test;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace Helio
{
    public class Application : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch? _spriteBatch;

        // for testing
        private Input _input;
        private List<ILayer> _layerStack;

        public Application()
        {
            // Tests
            Logger.SetLevel(LoggerLevel.Trace);
            Logger.Trace("Trace");
            Logger.Info("Info");
            Logger.Warn("Attention!!");
            Logger.Error("Errors!");

            _input = new Input();
            _layerStack = new List<ILayer> { new ExempleLayer() };

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            KeyboardState keyboardState = Keyboard.GetState();

            Keys[] pressedKeys = keyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                //_input.Event(new KeyboardPressed(keyboardState));

                foreach (ILayer layer in _layerStack)
                {
                    layer.Event(new KeyboardPressed(keyboardState));
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_spriteBatch != null)
            {
                foreach (ILayer layer in _layerStack)
                {
                    layer.Draw(gameTime, _spriteBatch);
                }
            }
            base.Draw(gameTime);
        }
    }
}
