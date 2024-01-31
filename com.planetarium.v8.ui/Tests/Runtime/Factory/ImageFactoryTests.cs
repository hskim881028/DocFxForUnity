using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory;

namespace V8.UI.Tests
{
    public class ImageFactoryTests
    {
        private class TestTextureList : TextureList
        {
            public void SetAssets(List<Texture2D> assets)
            {
                _assets = assets;
            }
        }

        private RectTransform _canvas;
        private ImageFactory _imageFactory;
        private readonly Texture2D _sampleTexture1 = new(2, 2) { name = "SampleTexture1" };
        private readonly Texture2D _sampleTexture2 = new(3, 3) { name = "SampleTexture2" };

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
            var uiElementFactory = new Runtime.Factory.ElementComponentFactory();
            var textureList = ScriptableObject.CreateInstance<TestTextureList>();
            textureList.SetAssets(new List<Texture2D> { _sampleTexture1, _sampleTexture2 });
            _imageFactory = new ImageFactory(uiElementFactory, textureList);
        }

        [Test]
        public void OnPropertyChangedTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Image',
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
                'Texture': 'SampleTexture1'
            }";

            var element = JsonConvert.DeserializeObject<Image>(json);
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
            element.Texture = _sampleTexture2.name;

            Assert.AreEqual(expectedAlignmentMode, element.AnchorAlignmentMode);
            Assert.AreEqual(expectedPositionMode, element.PositionMode);
            Assert.AreEqual(expectedPosition, element.Position);
            Assert.AreEqual(expectedSizeMode, element.SizeMode);
            Assert.AreEqual(expectedSize, element.Size);
            Assert.AreEqual(_sampleTexture2.name, element.Texture);
            
            element.Texture = _sampleTexture1.name; // _cachedSprites test
            Assert.AreEqual(_sampleTexture1.name, element.Texture);
        }

        [Test]
        public void GetSpriteTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Image',
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
                'Texture': 'SampleTexture1'
            }";

            var element = JsonConvert.DeserializeObject<Image>(json);
            _imageFactory.Create(element, _canvas);
            element.Texture = "SampleTexture2";
            Assert.AreEqual("SampleTexture2", element.Texture);
            element.Texture = "SampleTexture1";
            Assert.AreEqual("SampleTexture1", element.Texture);
        }
        
        [Test]
        public void GetSpriteExceptionTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Image',
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
                'Texture': 'SampleTexture1'
            }";

            var element = JsonConvert.DeserializeObject<Image>(json);
            _imageFactory.Create(element, _canvas);

            Assert.Throws<Exception>(() => element.Texture = "EmptyTexture");
        }
    }
}