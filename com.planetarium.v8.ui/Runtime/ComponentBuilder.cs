using System.Collections.Generic;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Runtime.Factory;
using V8.UI.Runtime.Provider;

namespace V8.UI.Runtime
{
    /// <summary>
    /// Creates Unity UI based on a component.
    /// </summary>
    internal sealed class ComponentBuilder
    {
        private readonly RectTransform _canvas;
        private readonly IFactoryProvider<IComponentFactory> _factoryProvider;

        public ComponentBuilder(RectTransform canvas, IFactoryProvider<IComponentFactory> factoryProvider)
        {
            _canvas = canvas;
            _factoryProvider = factoryProvider;
        }

        public void InstantiateUI(Dictionary<string, Element> elements)
        {
            foreach (var element in elements.Values)
            {
                CreateComponent(element, _canvas);
            }
        }

        private void CreateComponent(Element element, RectTransform parent)
        {
            var factory = _factoryProvider.GetFactory(element.GetType().Name);
            var component = factory.Create(element, parent);
            CreateChildrenComponent(element.Children, component);
        }

        private void CreateChildrenComponent(List<Element> children, RectTransform parent)
        {
            foreach (var child in children)
            {
                CreateComponent(child, parent);
            }
        }
    }
}
