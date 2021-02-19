using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Game
{
    class KaboomProcess : Process
    {
        private string _explosion;

        public KaboomProcess(string explosion)
        {
            _explosion = explosion;
        }

        public override void OnUpdate(GameTime deltaTime)
        {
            Logger.Test(_explosion, LoggerColor.Red);
            Succeed();
        }
    }
}
