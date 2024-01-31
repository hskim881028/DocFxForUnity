using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class UIInitializerTests
    {
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


        private RectTransform _canvas;
        private FontList _fontList;
        private TextureList _textureListList;


        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Canvas");
            _canvas = go.AddComponent<RectTransform>();
            _fontList = ScriptableObject.CreateInstance<FontList>();
            _textureListList = ScriptableObject.CreateInstance<TextureList>();
        }

        [Test]
        public void CreateTest()
        {
            var uiInitializer = new UIInitializer(_canvas, _fontList, _textureListList);
            Assert.IsNotNull(uiInitializer);
        }

        [Test]
        public void InitializeTest()
        {
            var data = new Dictionary<string, JToken>
            {
                { "Test", JObject.Parse(Json) }
            };

            var uiInitializer = new UIInitializer(_canvas, _fontList, _textureListList);
            var uiManager = uiInitializer.Initialize(data);
            
            Assert.IsNotNull(uiManager);
        }
    }
}