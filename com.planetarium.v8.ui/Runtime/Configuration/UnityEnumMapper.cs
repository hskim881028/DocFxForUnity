using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using V8.UI.Configuration;

namespace V8.UI.Runtime.Configuration
{
    public readonly struct UnityEnumMapper
    {
        public static AnchorSettings ToAnchorSettings(AlignmentMode mode)
        {
            return mode switch
            {
                AlignmentMode.TopLeft => new AnchorSettings(new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1)),
                AlignmentMode.TopCenter => new AnchorSettings(new Vector2(0.5f, 1), new Vector2(0.5f, 1), new Vector2(0.5f, 1)),
                AlignmentMode.TopRight => new AnchorSettings(new Vector2(1, 1), new Vector2(1, 1), new Vector2(1, 1)),
                AlignmentMode.MiddleLeft => new AnchorSettings(new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f)),
                AlignmentMode.MiddleCenter => new AnchorSettings(new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f)),
                AlignmentMode.MiddleRight => new AnchorSettings(new Vector2(1, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 0.5f)),
                AlignmentMode.BottomLeft => new AnchorSettings(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)),
                AlignmentMode.BottomCenter => new AnchorSettings(new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0)),
                AlignmentMode.BottomRight => new AnchorSettings(new Vector2(1, 0), new Vector2(1, 0), new Vector2(1, 0)),
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
        
        public static TextAlignmentOptions ToTextAlignmentOptions(AlignmentMode mode)
        {
            return mode switch
            {
                AlignmentMode.TopLeft => TextAlignmentOptions.TopLeft,
                AlignmentMode.TopCenter => TextAlignmentOptions.Top,
                AlignmentMode.TopRight => TextAlignmentOptions.TopRight,
                AlignmentMode.MiddleLeft => TextAlignmentOptions.MidlineLeft,
                AlignmentMode.MiddleCenter => TextAlignmentOptions.Midline,
                AlignmentMode.MiddleRight => TextAlignmentOptions.MidlineRight,
                AlignmentMode.BottomLeft => TextAlignmentOptions.BottomLeft,
                AlignmentMode.BottomCenter => TextAlignmentOptions.Bottom,
                AlignmentMode.BottomRight => TextAlignmentOptions.BottomRight,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }

        public static TextAnchor ToTextAnchor(AlignmentMode mode)
        {
            return mode switch
            {
                AlignmentMode.TopLeft => TextAnchor.UpperLeft,
                AlignmentMode.TopCenter => TextAnchor.UpperCenter,
                AlignmentMode.TopRight => TextAnchor.UpperRight,
                AlignmentMode.MiddleLeft => TextAnchor.MiddleLeft,
                AlignmentMode.MiddleCenter => TextAnchor.MiddleCenter,
                AlignmentMode.MiddleRight => TextAnchor.MiddleRight,
                AlignmentMode.BottomLeft => TextAnchor.LowerLeft,
                AlignmentMode.BottomCenter => TextAnchor.LowerCenter,
                AlignmentMode.BottomRight => TextAnchor.LowerRight,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }

        public static GridLayoutGroup.Constraint ToConstraint(ConstraintMode mode)
        {
            return mode switch
            {
                ConstraintMode.Flexible => GridLayoutGroup.Constraint.Flexible,
                ConstraintMode.FixedColumnCount => GridLayoutGroup.Constraint.FixedColumnCount,
                ConstraintMode.FixedRowCount => GridLayoutGroup.Constraint.FixedRowCount,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }

        public static GridLayoutGroup.Corner ToCorner(CornerMode mode)
        {
            return mode switch
            {
                CornerMode.UpperLeft => GridLayoutGroup.Corner.UpperLeft,
                CornerMode.UpperRight => GridLayoutGroup.Corner.UpperRight,
                CornerMode.LowerLeft => GridLayoutGroup.Corner.LowerLeft,
                CornerMode.LowerRight => GridLayoutGroup.Corner.LowerRight,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }

        public static GridLayoutGroup.Axis ToAxis(AxisMode mode)
        {
            return mode switch
            {
                AxisMode.Horizontal => GridLayoutGroup.Axis.Horizontal,
                AxisMode.Vertical => GridLayoutGroup.Axis.Vertical,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
    }
}