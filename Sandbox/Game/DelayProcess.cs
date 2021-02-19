using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Game
{
    public class DelayProcess : Process
    {
        private double _timeToDelay;
        private double _timeCurrentlyDelayed;

        public DelayProcess(double timeToDelay)
        {
            _timeToDelay = timeToDelay;
            _timeCurrentlyDelayed = 0;
        }

        public override void OnUpdate(GameTime deltaTime)
        {
            _timeCurrentlyDelayed += deltaTime.ElapsedGameTime.TotalMilliseconds;
            
            if (_timeCurrentlyDelayed >= _timeToDelay)
            {
                Succeed();
            }
        }
    }
}
