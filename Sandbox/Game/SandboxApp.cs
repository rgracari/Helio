using Helio;
using Helio.Core;
using Helio.Debug;
using System.IO;

namespace Sandbox.Game
{
    public class SandboxApp : Application
    {
        protected override void Initialize()
        {
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

            Logger.Test(actor);

            // Page 213 de gamecoding pour la suite
        }
    }
}
