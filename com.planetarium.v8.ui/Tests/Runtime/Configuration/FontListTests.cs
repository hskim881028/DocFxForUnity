using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class FontListTests
    {
        public class TestFontList : FontList
        {
            public void SetAssets(List<TMP_FontAsset> assets)
            {
                _assets = assets;
            }
        }

        private TestFontList _assetList;
        private TMP_FontAsset _testAsset1;
        private TMP_FontAsset _testAsset2;

        [SetUp]
        public void SetUp()
        {
            _assetList = ScriptableObject.CreateInstance<TestFontList>();
            _testAsset1 = ScriptableObject.CreateInstance<TMP_FontAsset>();
            _testAsset1.name = "TestAsset1";
            _testAsset2 = ScriptableObject.CreateInstance<TMP_FontAsset>();
            _testAsset2.name = "TestAsset2";
            _assetList.SetAssets(new List<TMP_FontAsset> { _testAsset1, _testAsset2 });
        }

        [Test]
        public void TryGetAssetTest()
        {
            var result = _assetList.TryGetAsset("TestAsset1", out var asset);
            Assert.IsTrue(result);
            Assert.AreEqual(_testAsset1, asset);
            Assert.IsInstanceOf<TMP_FontAsset>(asset);
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