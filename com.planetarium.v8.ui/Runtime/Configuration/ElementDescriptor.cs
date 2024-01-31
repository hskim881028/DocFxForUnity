using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace V8.UI.Runtime.Configuration
{
    /// <summary>
    /// Defines the type of a UI element for meta data interpretation and instantiation.
    /// </summary>
    public readonly struct ElementDescriptor
    {
        public string Type { get; }
        public List<JToken> Children { get; }

        [JsonConstructor]
        public ElementDescriptor(string type, List<JToken> children = null)
        {
            Type = type;
            Children = children ?? new List<JToken>();
        }
    }
}