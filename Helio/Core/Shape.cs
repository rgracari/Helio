using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Helio.Core
{
    class Shape : Component
    {
        public static string name = "Shape";

        public override string GetName() { return name; }

        public override bool Init(XmlNode xmlData)
        {
            Logger.Warn("Shape Component should Init some data");
            return true;
        }
    }
}
