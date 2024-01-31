using System;
using System.Collections.Generic;
using V8.UI.Elements.Basic;

namespace V8.UI.Runtime
{
    /// <summary>
    /// Manages UI Elements by their names.
    /// </summary>
    public sealed class UIManager
    {
        private readonly Dictionary<string, Element> _uis;

        /// <summary>
        /// Initializes UIManager with a dictionary of UI Elements.
        /// </summary>
        public UIManager(Dictionary<string, Element> uis)
        {
            _uis = uis;
        }

        /// <summary>
        /// Retrieves an element of the specified type with the given name.
        /// </summary>
        /// <typeparam name="T">Type of element to retrieve, subclass of Element.</typeparam>
        /// <param name="name">Name of the element to retrieve.</param>
        /// <returns>Element of the specified type.</returns>
        public T Get<T>(string name) where T : Element
        {
            if (!_uis.TryGetValue(name, out var ui))
            {
                throw new Exception($"Element '{name}' not found.");
            }
            
            if (ui is not T typedUi)
            {
                throw new InvalidCastException($"Element '{name}' is not of type {typeof(T).Name}.");
            }
            
            return typedUi;
        }
    }
}