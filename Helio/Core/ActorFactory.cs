using Helio.Debug;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Helio.Core
{
    public class ActorFactory
    {
        private int _lastActorId;
        protected Dictionary<string, Func<Component>> _componentCreators;

        public ActorFactory()
        {
            _lastActorId = 0;
            _componentCreators = new Dictionary<string, Func<Component>>();

            _componentCreators.Add(Shape.name, () => new Shape());
        }

        public Actor CreateActor(string actorRessource)
        {
            XmlDocument actorData = new XmlDocument();
            actorData.LoadXml(actorRessource);

            Actor actor = new Actor(GetNextActorId());
            if (actor.Init(actorData) == false)
            {
                throw new Exception("Enable to create the actor");
            }
            
            foreach (XmlNode element in actorData.FirstChild)
            {
                Component component = CreateComponent(element);
                actor.AddComponent(component);
                component.SetOwner(actor);
            }
            actor.PostInit();
            return actor;
        }

        protected Component CreateComponent(XmlNode node)
        {
            Component component = _componentCreators[node.Name].Invoke();
            if (component == null)
            {
                throw new Exception("Failed to create the Component");
            }
            if (component.Init(node) == false)
            {
                throw new Exception("Failed to to initialize the component");
            }
            return component;
        }

        private int GetNextActorId()
        {
            _lastActorId += 1;
            return _lastActorId;
        }
    }
}
