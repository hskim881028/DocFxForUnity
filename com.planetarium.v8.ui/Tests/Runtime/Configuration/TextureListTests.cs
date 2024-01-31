using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class TextureListTests
    {
        public class TestTextureList : TextureList
        {
            public void SetAssets(List<Texture2D> assets)
            {
                _assets = assets;
            }
        }

        private TestTextureList _assetList;
        private Texture2D _testAsset1;
        private Texture2D _testAsset2;

        [SetUp]
        public void SetUp()
        {
            _assetList = ScriptableObject.CreateInstance<TestTextureList>();
            _testAsset1 = new Texture2D(2, 2)
            {
                name = "TestAsset1"
            };
            _testAsset2 = new Texture2D(2, 2)
            {
                name = "TestAsset2"
            };
            _assetList.SetAssets(new List<Texture2D> { _testAsset1, _testAsset2 });
        }

        [Test]
        public void TryGetAssetTest()
        {
            var result = _assetList.TryGetAsset("TestAsset1", out var asset);
            Assert.IsTrue(result);
            Assert.AreEqual(_testAsset1, asset);
            Assert.IsInstanceOf<Texture2D>(asset);
        }

        [TearDown]
        public void Cleanup()
        {
            if (_testAsset1 != null)
            {
                Object.DestroyImmediate(_testAsset1);
            }

            if (_testAsset2 != null)
            {
                Object.DestroyImmediate(_testAsset2);
            }

            if (_assetList != null)
            {
                Object.DestroyImmediate(_assetList);
            }
        }
    }
}