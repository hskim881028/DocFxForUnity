using Newtonsoft.Json.Linq;
using V8.UI.Elements.Basic;

namespace V8.UI.Runtime.Factory
{
    internal class ElementFactory<T> : IElementFactory where T : Element
    {
        public string Type => typeof(T).Name;

        public Element Create(JToken jToken)
        {
            return jToken.ToObject<T>();
        }
    }
}