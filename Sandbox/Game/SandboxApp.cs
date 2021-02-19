using Helio;
using Helio.Core;
using Microsoft.Xna.Framework;
using System.IO;

namespace Sandbox.Game
{
    public class SandboxApp : Application
    {
        private ProcessManager _processManager;

        public SandboxApp()
        {
            _processManager = new ProcessManager();
        }

        protected override void Initialize()
        {
            Logger.Warn("For Process and process Managers set GameTime -> DeltaTime");
            Process delayProcess = new DelayProcess(3000);
            
            Process kaboomProcess = new KaboomProcess("Boom boom ahhhh boomm !!!");
            delayProcess.AttachChild(kaboomProcess);

            _processManager.AttachProcess(delayProcess);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            string dataXml = "";
            using (StreamReader sr = new StreamReader(Path.Combine(Content.RootDirectory, "Xml", "BaseActor.xml")))
            {
                dataXml = sr.ReadToEnd();
            }

            ActorFactory actorFactory = new ActorFactory();
            Actor actor = actorFactory.CreateActor(dataXml);
        }

        protected override void Update(GameTime gameTime)
        {
            _processManager.UpdateProcesses(gameTime);
            base.Update(gameTime);
        }
    }
}
