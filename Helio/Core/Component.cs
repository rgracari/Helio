using Helio.Debug;
using System.Xml;

namespace Helio.Core
{
    public abstract class Component
    {
        protected Actor? _owner;

        public void SetOwner(Actor owner)
        {
            _owner = owner;
            Logger.Warn("abstract Component -> voir si on est obligé de précisé le Actor?");
        }

        abstract public string GetName();

        abstract public bool Init(XmlNode xmlData);
        
        public virtual void PostInit() { }

        public virtual void Update(DeltaTime deltaTime) { }
    }
}
