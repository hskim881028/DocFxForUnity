using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class AssetListTests
    {
        public class TestAssetList : AssetList<ScriptableObject>
        {
            public void SetAssets(List<ScriptableObject> assets)
            {
                _assets = assets;
            }
        }

        private TestAssetList _assetList;
        private ScriptableObject _testAsset1;
        private ScriptableObject _testAsset2;
        
        [SetUp]
        public void SetUp()
        {
            _testAsset1 = ScriptableObject.CreateInstance<ScriptableObject>();
            _testAsset1.name = "TestAsset1";

            _testAsset2 = ScriptableObject.CreateInstance<ScriptableObject>();
            _testAsset2.name = "TestAsset2";

            _assetList = ScriptableObject.CreateInstance<TestAssetList>();
            _assetList.SetAssets(new List<ScriptableObject> { _testAsset1, _testAsset2 });
        }

        [Test]
        public void TryGetAssetTest()
        {
            var result = _assetList.TryGetAsset("TestAsset1", out var asset);
            Assert.IsTrue(result);
            Assert.AreEqual(_testAsset1, asset);
        }

        [Test]
        public void TryGetAsset2()
        {
            var result = _assetList.TryGetAsset("NonExistingAsset", out var asset);
            Assert.IsFalse(result);
            Assert.IsNull(asset);
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