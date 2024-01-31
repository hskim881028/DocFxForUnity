using Newtonsoft.Json.Linq;
using V8.UI.Elements.Basic;

namespace V8.UI.Runtime.Factory
{
    public interface IElementFactory : IFactory
    {
        public Element Create(JToken jToken);
    }
}