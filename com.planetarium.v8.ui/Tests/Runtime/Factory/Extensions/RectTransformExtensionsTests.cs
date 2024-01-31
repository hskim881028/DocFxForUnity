using System;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory.Extensions;

namespace V8.UI.Tests
{
    public class RectTransformExtensionsTests
    {
        private GameObject _parent;
        private RectTransform _parentRectTransform;
        private RectTransform _rectTransform;
        
        [SetUp]
        public void SetUp()
        {
            _parent = new GameObject("TestParent");
            _parentRectTransform = _parent.AddComponent<RectTransform>();
            var go = new GameObject("TestRectTransform");
            _rectTransform = go.AddComponent<RectTransform>();
            _rectTransform.anchorMin = new Vector2(999, 999);
            _rectTransform.anchorMax = new Vector2(999, 999);
            _rectTransform.offsetMin = new Vector2(999, 999);
            _rectTransform.offsetMax = new Vector2(999, 999);
            _rectTransform.SetParent(null);
        }
        
        [Test]
        public void ResetForChildTest()
        {
            _rectTransform.ResetForChild(_parentRectTransform);
            Assert.AreEqual(_parentRectTransform, _rectTransform.parent);
            Assert.AreEqual(Vector2.zero, _rectTransform.anchorMin);
            Assert.AreEqual(Vector2.one, _rectTransform.anchorMax);
            Assert.AreEqual(Vector2.zero, _rectTransform.offsetMin);
            Assert.AreEqual(Vector2.zero, _rectTransform.offsetMax);
        }

        [Test]
        public void UpdateAbsolutePositionTest()
        {
            var position = new Vector2(777, 777);
            var expectedPosition = new Vector2(position.x, -position.y);
            _rectTransform.UpdatePosition(PositionMode.Absolute, position, _parentRectTransform);
            Assert.AreEqual(expectedPosition, _rectTransform.anchoredPosition);
        }
        
        [Test]
        public void UpdateRelativePositionTest()
        {
            var position = new Vector2(50, 50);
            var ratioX = Mathf.Clamp(position.x, 0, 100) * 0.01f;
            var ratioY = Mathf.Clamp(position.y, 0, 100) * 0.01f;
            var parentRect = _parentRectTransform.rect;
            var expectedPosition = new Vector2(parentRect.width * ratioX, -parentRect.height * ratioY);
            
            _rectTransform.UpdatePosition(PositionMode.Relative, position, _parentRectTransform);
            Assert.AreEqual(expectedPosition, _rectTransform.anchoredPosition);
        }

        [Test]
        public void UpdatePositionExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _rectTransform.UpdatePosition((PositionMode)999, Vector2.zero, _parentRectTransform);
            });
        }

        [Test]
        public void UpdateAnchorTest()
        {
            const AlignmentMode mode = AlignmentMode.MiddleLeft;
            var expectSettings = UnityEnumMapper.ToAnchorSettings(mode);
            _rectTransform.UpdateAnchor(mode);
            Assert.AreEqual(expectSettings.Min, _rectTransform.anchorMin);
            Assert.AreEqual(expectSettings.Max, _rectTransform.anchorMax);
            Assert.AreEqual(expectSettings.Pivot, _rectTransform.pivot);
        }
        
        [Test]
        public void UpdateSizeTest()
        {
            var size = new Vector2(77, 77);
            _rectTransform.UpdateSize(size);
            Assert.AreEqual(size, _rectTransform.sizeDelta);
        }
    }
}