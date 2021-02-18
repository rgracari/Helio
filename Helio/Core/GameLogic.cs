using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Core
{
    class GameLogic
    {
        private List<GameView> _gameViews = new List<GameView>();
        private Dictionary<int, Actor> _actors;

        public GameLogic()
        {
            _actors = new Dictionary<int, Actor>();
        }

        public void AddView(GameView gameView)
        {
            _gameViews.Add(gameView);
        }

        public Actor GetActor(int actorId)
        {
            return _actors[actorId];
        }
    }
}
