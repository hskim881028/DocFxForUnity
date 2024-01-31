using System.ComponentModel;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Runtime.Factory.Extensions;

namespace V8.UI.Runtime.Factory
{
    internal class ElementComponentFactory : ComponentFactory<Element>
    {
        protected override RectTransform CreateTyped(Element element, RectTransform parent)
        {
            var go = new GameObject(element.Id);
            var rt = go.AddComponent<RectTransform>();
            ConfigureUIElement(rt, element, parent);
            return rt;
        }

        private static void ConfigureUIElement(RectTransform rt, Element element, RectTransform parent)
        {
            rt.SetParent(parent);
            rt.UpdateSize(element.Size);
            rt.UpdateAnchor(element.AnchorAlignmentMode);
            rt.UpdatePosition(element.PositionMode, element.Position, parent);

            element.PropertyChanged += (_, e) => OnPropertyChanged(e, rt, element, parent);
        }

        private static void OnPropertyChanged(PropertyChangedEventArgs e, RectTransform rt, Element element, RectTransform parent)
        {
            switch (e.PropertyName)
            {
                case nameof(Element.AnchorAlignmentMode):
                    rt.UpdateAnchor(element.AnchorAlignmentMode);
                    break;
                case nameof(Element.PositionMode):
                case nameof(Element.Position):
                    rt.UpdatePosition(element.PositionMode, element.Position, parent);
                    break;
                case nameof(Element.SizeMode):
                case nameof(Element.Size):
                    rt.UpdateSize(element.Size);
                    break;
            }
        }
    }
}