using System;
using UnityEngine;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Runtime.Factory.Extensions
{
    public static class RectTransformExtensions
    {
        public static void ResetForChild(this RectTransform rt, RectTransform parentGameObject)
        {
            rt.SetParent(parentGameObject);
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }

        public static void UpdatePosition(this RectTransform rt, PositionMode mode, Vector2 position, RectTransform parent)
        {
            switch (mode)
            {
                case PositionMode.Absolute:
                    SetAbsolutePosition(rt, position);
                    break;
                case PositionMode.Relative:
                    SetRelativePosition(rt, position, parent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public static void UpdateAnchor(this RectTransform rt, AlignmentMode mode)
        {
            var anchorSetting = UnityEnumMapper.ToAnchorSettings(mode);
            SetAnchor(rt, anchorSetting);
        }

        public static void UpdateSize(this RectTransform rt, Vector2 size)
        {
            rt.sizeDelta = size;
        }

        private static void SetAbsolutePosition(RectTransform rt, Vector2 position)
        {
            rt.anchoredPosition = new Vector2(position.x, -position.y);
        }

        private static void SetRelativePosition(RectTransform rt, Vector2 position, RectTransform parent)
        {
            var ratioX = ConvertPercentage(position.x);
            var ratioY = ConvertPercentage(position.y);
            var parentRect = parent.rect;
            rt.anchoredPosition = new Vector2(parentRect.width * ratioX, -parentRect.height * ratioY);
        }

        private static void SetAnchor(RectTransform rt, AnchorSettings anchorSetting)
        {
            rt.anchorMin = anchorSetting.Min;
            rt.anchorMax = anchorSetting.Max;
            rt.pivot = anchorSetting.Pivot;
        }

        private static float ConvertPercentage(float value)
        {
            return Mathf.Clamp(value, 0, 100) * 0.01f;
        }
    }
}