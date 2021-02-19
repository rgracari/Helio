using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Helio.Core
{
    public class Actor
    {
        private int _id;
        private Dictionary<string, Component> _components;

        public Actor(int id)
        {
            _id = id;
            _components = new Dictionary<string, Component>();
        }

        public bool Init(XmlNode xmlData)
        {
            Logger.Warn($"Initializing Actor {_id} (not doing anything now)");
            return true;
        }
        
        public void PostInit()
        {
            foreach (var component in _components)
            {
                component.Value.PostInit();
            }
        }

        public void Update(DeltaTime deltaTime)
        {
            foreach (var component in _components)
            {
                component.Value.Update(deltaTime);
            }
        }

        public int GetId() { return _id; }

        public T? GetComponent<T>(string componentId) where T : Component
        {
            Component component;
            if (_components.TryGetValue(componentId, out component) == true)
            {
                if (component != null)
                {
                    return component as T;
                }
            }
            throw new Exception("The Component id wasn't finded in the map");
        }

        public void AddComponent(Component component)
        {
            _components.Add(component.GetName(), component);
        }

        public override string ToString()
        {
            return $"id: {_id}, components count: {_components.Count}";
        }
    }
}
