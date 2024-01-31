using System;
using UnityEngine;

namespace V8.UI.Runtime.Factory
{
    /// <summary>
    /// An abstract base class for creating UI components of specific UIElement types,
    /// implementing the IComponentFactory interface.
    /// </summary>
    /// <typeparam name="T">UIElement</typeparam>
    internal abstract class ComponentFactory<T> : IComponentFactory
    {
        public string Type => typeof(T).Name;

        public RectTransform Create(object element, RectTransform parent)
        {
            if (element is not T typedElement)
            {
                throw new InvalidOperationException($"The element is not of the expected type {Type}." +
                                                    $" Actual type: {element.GetType().Name}");
            }

            return CreateTyped(typedElement, parent);
        }

        protected abstract RectTransform CreateTyped(T element, RectTransform parent);
    }
}