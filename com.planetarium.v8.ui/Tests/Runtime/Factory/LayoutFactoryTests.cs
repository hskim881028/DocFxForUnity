using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;
using V8.UI.Runtime.Factory;

namespace V8.UI.Tests
{
    public class LayoutFactoryTests
    {
        private RectTransform _canvas;
        private LayoutFactory _layoutFactory;

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
            var uiElementFactory = new Runtime.Factory.ElementComponentFactory();
            _layoutFactory = new LayoutFactory(uiElementFactory);
        }

        [Test]
        public void OnPropertyChangedTest()
        {
            const string json = @"
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
            
            var layout = JsonConvert.DeserializeObject<Layout>(json);
            _layoutFactory.Create(layout, _canvas);
            
            var expectedAlignmentMode = AlignmentMode.MiddleLeft;
            var expectedPositionMode = PositionMode.Relative; 
            var expectedPosition = new Vector2(99, 99);
            var expectedSizeMode = SizeMode.Percent;
            var expectedSize = new Vector2(99, 99);
            
            var expectedCornerMode = CornerMode.LowerRight;
            var expectedAxisMode = AxisMode.Vertical;
            var expectedChildAlignmentMode = AlignmentMode.MiddleRight;
            var expectedChildConstraintMode = ConstraintMode.Flexible;
            var expectedPadding = new Padding(10, 10, 10, 10);
            var expectedChildSize = new Vector2(50, 50);
            var expectedSpacing = new Vector2(5, 5);
            var expectedChildConstraintCount = 5;

            layout.AnchorAlignmentMode = expectedAlignmentMode;
            layout.PositionMode = expectedPositionMode;
            layout.Position = expectedPosition;
            layout.SizeMode = expectedSizeMode;
            layout.Size = expectedSize;
            
            layout.CornerMode = expectedCornerMode;
            layout.AxisMode = expectedAxisMode;
            layout.ChildAlignmentMode = expectedChildAlignmentMode;
            layout.ChildConstraintMode = expectedChildConstraintMode;
            layout.Padding = expectedPadding;
            layout.ChildSize = expectedChildSize;
            layout.Spacing = expectedSpacing;
            layout.ChildConstraintCount = expectedChildConstraintCount;
      
            Assert.AreEqual(expectedAlignmentMode, layout.AnchorAlignmentMode);
            Assert.AreEqual(expectedPositionMode, layout.PositionMode);
            Assert.AreEqual(expectedPosition, layout.Position);
            Assert.AreEqual(expectedSizeMode, layout.SizeMode);
            Assert.AreEqual(expectedSize, layout.Size);
            Assert.AreEqual(expectedCornerMode, layout.CornerMode);
            Assert.AreEqual(expectedAxisMode, layout.AxisMode);
            Assert.AreEqual(expectedChildAlignmentMode, layout.ChildAlignmentMode);
            Assert.AreEqual(expectedChildConstraintMode, layout.ChildConstraintMode);
            Assert.AreEqual(expectedPadding, layout.Padding);
            Assert.AreEqual(expectedChildSize, layout.ChildSize);
            Assert.AreEqual(expectedSpacing, layout.Spacing);
            Assert.AreEqual(expectedChildConstraintCount, layout.ChildConstraintCount);
        }
    }
}