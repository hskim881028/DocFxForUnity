using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using V8.UI.Elements.Basic;
using UnityEngine;
using V8.UI.Configuration;

namespace V8.UI.Tests
{
    public class ElementTests
    {
        private class TestableElement : Element
        {
            public TestableElement(string id, string type, List<Element> children = null)
                : base(id, type, children)
            {
            }
        }

        private const string Json = @"
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

        [Test]
        public void DeserializationTest()
        {
            var element = JsonConvert.DeserializeObject<Element>(Json);

            Assert.AreEqual("TestId", element.Id);
            Assert.AreEqual(nameof(Element), element.Type);
            Assert.IsNotNull(element.Children);
            Assert.AreEqual(2, element.Children.Count);
            Assert.AreEqual("ChildId1", element.Children[0].Id);
            Assert.AreEqual("Element", element.Children[0].Type);
            Assert.AreEqual("ChildId2", element.Children[1].Id);
            Assert.AreEqual("Element", element.Children[1].Type);
            Assert.AreEqual(AlignmentMode.TopCenter, element.AnchorAlignmentMode);
            Assert.AreEqual(SizeMode.Pixel, element.SizeMode);
            Assert.AreEqual(new Vector2(100, 200), element.Size);
            Assert.AreEqual(PositionMode.Absolute, element.PositionMode);
            Assert.AreEqual(new Vector2(10, 20), element.Position);
        }

        [Test]
        public void SetPropertyTest()
        {
            var element = JsonConvert.DeserializeObject<Element>(Json);
            var propertyChanges = new Dictionary<string, bool>
            {
                { nameof(Element.AnchorAlignmentMode), false },
                { nameof(Element.SizeMode), false },
                { nameof(Element.Size), false },
                { nameof(Element.PositionMode), false },
                { nameof(Element.Position), false }
            };

            element.PropertyChanged += (_, args) =>
            {
                if (propertyChanges.ContainsKey(args.PropertyName))
                {
                    propertyChanges[args.PropertyName] = true;
                }
            };

            element.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            element.SizeMode = SizeMode.Percent;
            element.Size = Vector2.zero;
            element.PositionMode = PositionMode.Relative;
            element.Position = Vector2.zero;

            foreach (var property in propertyChanges.Values)
            {
                Assert.IsTrue(property);
            }
        }

        [Test]
        public void DisposeTest()
        {
            var element = new TestableElement("TestId", nameof(Element));
            var eventHandlerCalled = false;
            element.PropertyChanged += (_, e) => { eventHandlerCalled = true; };
            element.Dispose();
            element.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            Assert.IsFalse(eventHandlerCalled);
        }
    }
}