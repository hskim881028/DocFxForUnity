using System;
using V8.UI.Configuration;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class UnitEnumMapperTests
    {
        [Test]
        public void ToAnchorSettingsTest()
        {
            ToAnchorSetting(AlignmentMode.TopLeft, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1));
            ToAnchorSetting(AlignmentMode.TopCenter, new Vector2(0.5f, 1), new Vector2(0.5f, 1), new Vector2(0.5f, 1));
            ToAnchorSetting(AlignmentMode.TopRight, new Vector2(1, 1), new Vector2(1, 1), new Vector2(1, 1));
            ToAnchorSetting(AlignmentMode.MiddleLeft, new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f));
            ToAnchorSetting(AlignmentMode.MiddleCenter, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
            ToAnchorSetting(AlignmentMode.MiddleRight, new Vector2(1, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 0.5f));
            ToAnchorSetting(AlignmentMode.BottomLeft, new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
            ToAnchorSetting(AlignmentMode.BottomCenter, new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0));
            ToAnchorSetting(AlignmentMode.BottomRight, new Vector2(1, 0), new Vector2(1, 0), new Vector2(1, 0));
        }
        
        private static void ToAnchorSetting(AlignmentMode mode, Vector2 expectedMin, Vector2 expectedMax, Vector2 expectedPivot)
        {
            var anchorSettings = UnityEnumMapper.ToAnchorSettings(mode);
            Assert.AreEqual(expectedMin, anchorSettings.Min);
            Assert.AreEqual(expectedMax, anchorSettings.Max);
            Assert.AreEqual(expectedPivot, anchorSettings.Pivot);
        }

        [Test]
        public void ToAnchorSettingsExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToAnchorSettings((AlignmentMode)999));
        }
        
        [Test]
        public void ToTextAlignmentOptionsTest()
        {
            ToTextAlignmentOptions(AlignmentMode.TopLeft, TextAlignmentOptions.TopLeft);
            ToTextAlignmentOptions(AlignmentMode.TopCenter, TextAlignmentOptions.Top);
            ToTextAlignmentOptions(AlignmentMode.TopRight, TextAlignmentOptions.TopRight);
            ToTextAlignmentOptions(AlignmentMode.MiddleLeft, TextAlignmentOptions.MidlineLeft);
            ToTextAlignmentOptions(AlignmentMode.MiddleCenter, TextAlignmentOptions.Midline);
            ToTextAlignmentOptions(AlignmentMode.MiddleRight, TextAlignmentOptions.MidlineRight);
            ToTextAlignmentOptions(AlignmentMode.BottomLeft, TextAlignmentOptions.BottomLeft);
            ToTextAlignmentOptions(AlignmentMode.BottomCenter, TextAlignmentOptions.Bottom);
            ToTextAlignmentOptions(AlignmentMode.BottomRight, TextAlignmentOptions.BottomRight);
        }
        
        private static void ToTextAlignmentOptions(AlignmentMode mode, TextAlignmentOptions expectedOptions)
        {
            var textAlignmentOptions = UnityEnumMapper.ToTextAlignmentOptions(mode);
            Assert.AreEqual(expectedOptions, textAlignmentOptions);
        }
        
        [Test]
        public void ToTextAlignmentOptionsExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToTextAlignmentOptions((AlignmentMode)999));
        }

        [Test]
        public void ToTextAnchorTest()
        {
            ToTextAnchor(AlignmentMode.TopLeft, TextAnchor.UpperLeft);
            ToTextAnchor(AlignmentMode.TopCenter, TextAnchor.UpperCenter);
            ToTextAnchor(AlignmentMode.TopRight, TextAnchor.UpperRight);
            ToTextAnchor(AlignmentMode.MiddleLeft, TextAnchor.MiddleLeft);
            ToTextAnchor(AlignmentMode.MiddleCenter, TextAnchor.MiddleCenter);
            ToTextAnchor(AlignmentMode.MiddleRight, TextAnchor.MiddleRight);
            ToTextAnchor(AlignmentMode.BottomLeft, TextAnchor.LowerLeft);
            ToTextAnchor(AlignmentMode.BottomCenter, TextAnchor.LowerCenter);
            ToTextAnchor(AlignmentMode.BottomRight, TextAnchor.LowerRight);
        }
        
        private static void ToTextAnchor(AlignmentMode mode, TextAnchor expectedTextAnchor)
        {
            var textAnchor = UnityEnumMapper.ToTextAnchor(mode);
            Assert.AreEqual(expectedTextAnchor, textAnchor);
        }
        
        [Test]
        public void ToTextAnchorExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToTextAnchor((AlignmentMode)999));
        }
        
        [Test]
        public void ToConstraintTest()
        {
            ToConstraint(ConstraintMode.Flexible, GridLayoutGroup.Constraint.Flexible);
            ToConstraint(ConstraintMode.FixedColumnCount, GridLayoutGroup.Constraint.FixedColumnCount);
            ToConstraint(ConstraintMode.FixedRowCount, GridLayoutGroup.Constraint.FixedRowCount);
        }
        
        private static void ToConstraint(ConstraintMode mode, GridLayoutGroup.Constraint expectedConstraint)
        {
            var constraint = UnityEnumMapper.ToConstraint(mode);
            Assert.AreEqual(expectedConstraint, constraint);
        }
        
        [Test]
        public void ToConstraintExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToConstraint((ConstraintMode)999));
        }
        
        [Test]
        public void ToCornerTest()
        {
            ToCorner(CornerMode.UpperLeft, GridLayoutGroup.Corner.UpperLeft);
            ToCorner(CornerMode.UpperRight, GridLayoutGroup.Corner.UpperRight);
            ToCorner(CornerMode.LowerLeft, GridLayoutGroup.Corner.LowerLeft);
            ToCorner(CornerMode.LowerRight, GridLayoutGroup.Corner.LowerRight);
        }
        
        private static void ToCorner(CornerMode mode, GridLayoutGroup.Corner expectedCorner)
        {
            var corner = UnityEnumMapper.ToCorner(mode);
            Assert.AreEqual(expectedCorner, corner);
        }
        
        [Test]
        public void ToCornerExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToCorner((CornerMode)999));
        }
        
        [Test]
        public void ToAxisTest()
        {
            ToAxis(AxisMode.Horizontal, GridLayoutGroup.Axis.Horizontal);
            ToAxis(AxisMode.Vertical, GridLayoutGroup.Axis.Vertical);
        }
        
        private static void ToAxis(AxisMode mode, GridLayoutGroup.Axis expectedAxis)
        {
            var axis = UnityEnumMapper.ToAxis(mode);
            Assert.AreEqual(expectedAxis, axis);
        }
        
        [Test]
        public void ToAxisExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => UnityEnumMapper.ToAxis((AxisMode)999));
        }
    }
}