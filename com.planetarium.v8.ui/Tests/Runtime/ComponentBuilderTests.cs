using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Runtime;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Provider;

namespace V8.UI.Tests
{
    public class ComponentBuilderTests
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
        private IAssetList<TMP_FontAsset> _stubFontAssets;
        private IAssetList<Texture2D> _stubImageAssets;
        private Dictionary<string, Element> _stubElements;

        [SetUp]
        public void SetUp()
        {
            _canvas = new GameObject().AddComponent<RectTransform>();
            _stubFontAssets = ScriptableObject.CreateInstance<FontList>();
            _stubImageAssets = ScriptableObject.CreateInstance<TextureList>();
            _stubElements = new Dictionary<string, Element>();

            var provider = new ElementFactoryProvider();
            var factory = provider.GetFactory(nameof(Element));
            _stubElements.Add("Test", factory.Create(JObject.Parse(Json)));
        }

        [Test]
        public void CreateTest()
        {
            var factoryProvider = new ComponentFactoryProvider(_stubFontAssets, _stubImageAssets);
            var uiBuilder = new ComponentBuilder(_canvas, factoryProvider);
            Assert.IsNotNull(uiBuilder);
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                var componentBuilder = new ComponentBuilder(null, factoryProvider);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var componentBuilder = new ComponentBuilder(_canvas, null);
            });
        }
        
        [Test]
        public void InstantiateUITest()
        {
            var factoryProvider = new ComponentFactoryProvider(_stubFontAssets, _stubImageAssets);
            var uiBuilder = new ComponentBuilder(_canvas, factoryProvider);
            uiBuilder.InstantiateUI(_stubElements);

            Assert.AreEqual(2,_canvas.childCount);
            
            var expectedId = _stubElements["Test"].Id;
            var uiComponent = _canvas.GetChild(0);
            Assert.AreEqual(expectedId, uiComponent.GetComponent<RectTransform>().name);
            Assert.AreEqual(100, uiComponent.GetComponent<RectTransform>().sizeDelta.x);
            Assert.AreEqual(100, uiComponent.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}