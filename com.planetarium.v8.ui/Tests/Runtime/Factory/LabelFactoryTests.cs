using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory;

namespace V8.UI.Tests
{
    public class LabelFactoryTests
    {
        private class TestFontList : FontList
        {
            public void SetAssets(List<TMP_FontAsset> assets)
            {
                _assets = assets;
            }
        }
        
        private RectTransform _canvas;
        private LabelFactory _labelFactory;
        private TMP_FontAsset _defaultFontAsset;

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
            _defaultFontAsset = go.AddComponent<TextMeshProUGUI>().font;
            var uiElementFactory = new Runtime.Factory.ElementComponentFactory();
            var fontList = ScriptableObject.CreateInstance<TestFontList>();
            fontList.SetAssets(new List<TMP_FontAsset> { _defaultFontAsset });
            _labelFactory = new LabelFactory(uiElementFactory, fontList);
        }

        [Test]
        public void OnPropertyChangedTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Label',
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
                'Position': {'x': 10, 'y': 20},
                'TextAlignmentMode': 'BottomRight',
                'Font': 'NotoSans-SDF',
                'Color': {'R': 1, 'G': 1, 'B': 1, 'A': 1},
                'FontSize': 12,
                'Text': 'Hello World!'
            }";
            
            var element = JsonConvert.DeserializeObject<Label>(json);
            _labelFactory.Create(element, _canvas);
        
            var expectedAlignmentMode = AlignmentMode.MiddleLeft;
            var expectedPositionMode = PositionMode.Relative; 
            var expectedPosition = new Vector2(99, 99);
            var expectedSizeMode = SizeMode.Percent;
            var expectedSize = new Vector2(99, 99);
            var expectedFontSize = 7;
            var expectedColor = new Color(0, 0, 0, 0);
            var expectedTextAlignmentMode = AlignmentMode.TopLeft;
            var expectedText = "Change Text";
            
            element.Font = _defaultFontAsset.name;
            element.AnchorAlignmentMode = expectedAlignmentMode;
            element.PositionMode = expectedPositionMode;
            element.Position = expectedPosition;
            element.SizeMode = expectedSizeMode;
            element.Size = expectedSize;
            element.FontSize = expectedFontSize;
            element.Color = expectedColor;
            element.TextAlignmentMode = expectedTextAlignmentMode;
            element.Text = expectedText;
            
            Assert.AreEqual(_defaultFontAsset.name, element.Font);
            Assert.AreEqual(expectedAlignmentMode, element.AnchorAlignmentMode);
            Assert.AreEqual(expectedPositionMode, element.PositionMode);
            Assert.AreEqual(expectedPosition, element.Position);
            Assert.AreEqual(expectedSizeMode, element.SizeMode);
            Assert.AreEqual(expectedSize, element.Size);
            Assert.AreEqual(expectedFontSize, element.FontSize);
            Assert.AreEqual(expectedColor, element.Color);
            Assert.AreEqual(expectedTextAlignmentMode, element.TextAlignmentMode);
            Assert.AreEqual(expectedText, element.Text);
        }
    }
}
