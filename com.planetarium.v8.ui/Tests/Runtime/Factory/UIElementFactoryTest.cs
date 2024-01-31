using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;

namespace V8.UI.Tests
{
    public class UIElementFactoryTest
    {
        private RectTransform _canvas;
        private Runtime.Factory.ElementComponentFactory _elementComponentFactory;

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
            _elementComponentFactory = new Runtime.Factory.ElementComponentFactory();
        }

        [Test]
        public void OnPropertyChangedTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Element',
                'Children': [
                    {
                        'Id': 'ChildId1',
                        'Type': 'Element'
                    },
                    {
                        'Id': 'ChildId2',
                        'Type': 'Element'
                    }
                ],
                'AnchorAlignmentMode': 'TopCenter',
                'SizeMode': 'Pixel',
                'Size': {'x': 100, 'y': 200},
                'PositionMode': 'Absolute',
                'Position': {'x': 10, 'y': 20}
            }";
            var element = JsonConvert.DeserializeObject<Element>(json);
            _elementComponentFactory.Create(element, _canvas);
            
            var expectedAlignmentMode = AlignmentMode.MiddleLeft;
            var expectedPositionMode = PositionMode.Relative; 
            var expectedPosition = new Vector2(99, 99);
            var expectedSizeMode = SizeMode.Percent;
            var expectedSize = new Vector2(99, 99);

            element.AnchorAlignmentMode = expectedAlignmentMode;
            element.PositionMode = expectedPositionMode;
            element.Position = expectedPosition;
            element.SizeMode = expectedSizeMode;
            element.Size = expectedSize;
            
            Assert.AreEqual(expectedAlignmentMode, element.AnchorAlignmentMode);
            Assert.AreEqual(expectedPositionMode, element.PositionMode);
            Assert.AreEqual(expectedPosition, element.Position);
            Assert.AreEqual(expectedSizeMode, element.SizeMode);
            Assert.AreEqual(expectedSize, element.Size);
        }
    }
}