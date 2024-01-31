using UnityEngine;

namespace V8.UI.Runtime.Configuration
{
    public readonly struct AnchorSettings
    {
        public readonly Vector2 Min;
        public readonly Vector2 Max;
        public readonly Vector2 Pivot;

        public AnchorSettings(Vector2 min, Vector2 max, Vector2 pivot)
        {
            Min = min;
            Max = max;
            Pivot = pivot;
        }
    }
}