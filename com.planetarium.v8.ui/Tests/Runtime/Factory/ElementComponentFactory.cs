using System;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime.Factory;

namespace V8.UI.Tests
{
    public class ElementComponentFactory
    {
        private RectTransform _canvas;
        
        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
        }
        
        [Test]
        public void CreateTest()
        {
            var uiElementFactory = new Runtime.Factory.ElementComponentFactory();
            Assert.AreEqual("Element", uiElementFactory.Type);
            
            var labelFactory = new LabelFactory(uiElementFactory, null);
            Assert.AreEqual("Label", labelFactory.Type);
            
            var imageFactory = new ImageFactory(uiElementFactory, null);
            Assert.AreEqual("Image", imageFactory.Type);
        }

        [Test]
        public void CreateExceptionTest()
        {
            var test = new object();
            var uiElementFactory = new Runtime.Factory.ElementComponentFactory();
            Assert.Throws<InvalidOperationException>(() => uiElementFactory.Create(test, _canvas));
        }
    }
}