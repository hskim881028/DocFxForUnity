using UnityEngine;

namespace V8.UI.Runtime.Factory
{
    /// <summary>
    /// Interface for factories to create UI Component.
    /// </summary>
    public interface IComponentFactory : IFactory
    {
        public RectTransform Create(object element, RectTransform parent);
    }
}