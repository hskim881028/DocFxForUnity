using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using V8.UI.Elements.Basic;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory;
using V8.UI.Runtime.Provider;

namespace V8.UI.Runtime
{
    /// <summary>
    /// Interprets and transforms JSON UI metadata into structured models for use in Unity applications.
    /// </summary>
    internal sealed class UIDataInterpreter
    {
        private readonly IFactoryProvider<IElementFactory> _factoryProvider;

        public UIDataInterpreter(IFactoryProvider<IElementFactory> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        /// <summary>
        /// Organizes JSON data by parsing it into UI elements and grouping them by UI names.
        /// </summary>
        /// <param name="uiData">Dictionary where keys are ui names and values are ui data.</param>
        /// <returns>Dictionary of element by ui name.</returns>
        public Dictionary<string, Element> OrganizeElements(Dictionary<string, JToken> uiData)
        {
            var elements = new Dictionary<string, Element>();
            foreach (var (uiName, jToken) in uiData)
            {
                var element = CreateElement(jToken);
                elements.Add(uiName, element);
            }

            return elements;
        }

        private Element CreateElement(JToken ui)
        {
            var descriptor = ui.ToObject<ElementDescriptor>();
            var factory = _factoryProvider.GetFactory(descriptor.Type);
            var element = factory.Create(ui);
            CreateChildrenElements(element, descriptor.Children);
            return element;
        }

        private void CreateChildrenElements(Element element, IEnumerable<JToken> children)
        {
            element.Children.Clear();
            foreach (var childToken in children)
            {
                var child = CreateElement(childToken);
                element.Children.Add(child);
            }
        }
    }
}