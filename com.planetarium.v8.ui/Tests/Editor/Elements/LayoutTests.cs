using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;

namespace V8.UI.Tests
{
    public class LayoutTests
    {
        private class TestableLayout : Layout
        {
            public TestableLayout(string id, string type)
                : base(id, type)
            {
            }
        }

        private const string Json = @"
        {
            'Id': 'Layout_1',
            'Type': 'Layout',
            'ChildAlignmentMode': 'TopLeft',
            'ChildConstraintMode': 'FixedRowCount',
            'CornerMode': 'UpperLeft',
            'AxisMode': 'Horizontal',
            'Padding': {
                'Left': 10,
                'Right': 10,
                'Top': 5,
                'Bottom': 5
            },
            'ChildSize': {
                'X': 100,
                'Y': 100
            },
            'Spacing': {
                'X': 2,
                'Y': 2
            },
            'ChildConstraintCount': 1,
            'SizeMode': 'Pixel',
            'Size': {
                'X': 100,
                'Y': 100
            },
            'PositionMode': 'Relative',
            'Position': {
                'X': 0,
                'Y': 80
            },
            'Children': [
                {
                    'Id': 'Label_1',
                    'Type': 'Label',
                    'AnchorAlignmentMode': 'TopLeft',
                    'SizeMode': 'Pixel',
                    'Size': {
                        'X': 200,
                        'Y': 200
                    },
                    'PositionMode': 'Absolute',
                    'Position': {
                        'X': 200,
                        'Y': 200
                    },
                    'TextAlignmentMode': 'BottomRight',
                    'Font': 'NotoSans-SDF',
                    'Color': {
                        'R': 1,
                        'G': 1,
                        'B': 1,
                        'A': 1
                    },
                    'FontSize': 12,
                    'Text': 'Hello World!',
                    'Children': []
                },
                {
                    'Id': 'Image_1',
                    'Type': 'Image',
                    'AnchorAlignmentMode': 'TopLeft',
                    'SizeMode': 'Pixel',
                    'Size': {
                        'X': 100,
                        'Y': 100
                    },
                    'PositionMode': 'Absolute',
                    'Position': {
                        'X': 100,
                        'Y': 100
                    },
                    'Texture': 'TestImage',
                    'Children': []
                }
            ]
        }";


        [Test]
        public void DeserializationTest()
        {
            var layout = JsonConvert.DeserializeObject<Layout>(Json);

            Assert.AreEqual("Layout_1", layout.Id);
            Assert.AreEqual(nameof(Layout), layout.Type);
            Assert.AreEqual(AlignmentMode.TopLeft, layout.ChildAlignmentMode);
            Assert.AreEqual(ConstraintMode.FixedRowCount, layout.ChildConstraintMode);
            Assert.AreEqual(CornerMode.UpperLeft, layout.CornerMode);
            Assert.AreEqual(AxisMode.Horizontal, layout.AxisMode);
            Assert.AreEqual(new Padding(10, 10, 5, 5), layout.Padding);
            Assert.AreEqual(new Vector2(100, 100), layout.ChildSize);
            Assert.AreEqual(new Vector2(2, 2), layout.Spacing);
            Assert.AreEqual(1, layout.ChildConstraintCount);
            Assert.AreEqual(2, layout.Children.Count);
        }

        [Test]
        public void SetPropertyTest()
        {
            var layout = JsonConvert.DeserializeObject<Layout>(Json);
            var propertyChanges = new Dictionary<string, bool>
            {
                {nameof(Layout.AnchorAlignmentMode), true},
                {nameof(Layout.SizeMode), true},
                {nameof(Layout.Size), true},
                {nameof(Layout.PositionMode), true},
                {nameof(Layout.Position), true},
                {nameof(Layout.CornerMode), true},
                {nameof(Layout.AxisMode), true},
                {nameof(Layout.ChildAlignmentMode), true},
                {nameof(Layout.ChildConstraintMode), true},
                {nameof(Layout.Padding), true},
                {nameof(Layout.ChildSize), true},
                {nameof(Layout.Spacing), true},
                {nameof(Layout.ChildConstraintCount), true},
            };

            layout.PropertyChanged += (_, args) =>
            {
                if (propertyChanges.ContainsKey(args.PropertyName))
                {
                    propertyChanges[args.PropertyName] = true;
                }
            };

            layout.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            layout.SizeMode = SizeMode.Percent;
            layout.Size = Vector2.zero;
            layout.PositionMode = PositionMode.Relative;
            layout.Position = Vector2.zero;
            layout.CornerMode = CornerMode.LowerRight;
            layout.AxisMode = AxisMode.Vertical;
            layout.ChildAlignmentMode = AlignmentMode.MiddleRight;
            layout.ChildConstraintMode = ConstraintMode.Flexible;
            layout.Padding = new Padding(10, 10, 10, 10);
            layout.ChildSize = new Vector2(50, 50);
            layout.Spacing = new Vector2(5, 5);
            layout.ChildConstraintCount = 5;

            foreach (var property in propertyChanges.Values)
            {
                Assert.IsTrue(property);
            }
        }

        [Test]
        public void DisposeTest()
        {
            var layout = new TestableLayout("TestId", "TestType");
            var eventHandlerCalled = false;
            layout.PropertyChanged += (_, e) => { eventHandlerCalled = true; };
            layout.Dispose();
            layout.ChildConstraintMode = ConstraintMode.FixedColumnCount;
            Assert.IsFalse(eventHandlerCalled);
        }
    }
}