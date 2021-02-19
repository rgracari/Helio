using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Core
{
    class GameLogic
    {
        private List<GameView> _gameViews;
        private Dictionary<int, Actor> _actors;

        public GameLogic()
        {
            _gameViews = new List<GameView>();
            _actors = new Dictionary<int, Actor>();
        }

        public void Update(GameTime gameTime)
        {
            // Updates
        }

        public void AddView(GameView gameView)
        {
            _gameViews.Add(gameView);
        }

        public List<GameView> GetGameViews()
        {
            return _gameViews;
        }

        public Actor GetActor(int actorId)
        {
            return _actors[actorId];
        }
    }
}
