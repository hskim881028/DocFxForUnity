using NUnit.Framework;
using TMPro;
using UnityEngine;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory;
using V8.UI.Runtime.Provider;
using System;

namespace V8.UI.Tests
{
    public class ComponentFactoryProviderTests
    {
        private ComponentFactoryProvider _factoryProvider;
        private IAssetList<TMP_FontAsset> _stubFontAssets;
        private IAssetList<Texture2D> _stubImageAssets;

        [SetUp]
        public void SetUp()
        {
            _stubFontAssets = ScriptableObject.CreateInstance<FontList>();
            _stubImageAssets = ScriptableObject.CreateInstance<TextureList>();
            _factoryProvider = new ComponentFactoryProvider(_stubFontAssets, _stubImageAssets);
        }

        [Test]
        public void FactoryRegistrationTest()
        {
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(ElementComponentFactory)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(LabelFactory)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(ImageFactory)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(LayoutFactory)));
        }

        [Test]
        public void FactoryCreationTest()
        {
            Assert.IsInstanceOf<ElementComponentFactory>(_factoryProvider.GetFactory(nameof(ElementComponentFactory)));
            Assert.IsInstanceOf<LabelFactory>(_factoryProvider.GetFactory(nameof(LabelFactory)));
            Assert.IsInstanceOf<ImageFactory>(_factoryProvider.GetFactory(nameof(ImageFactory)));
            Assert.IsInstanceOf<LayoutFactory>(_factoryProvider.GetFactory(nameof(LayoutFactory)));
        }

        [Test]
        public void ExceptionForInvalidArgumentsTest()
        {
            Assert.Throws<ArgumentNullException>(() => { _ = new ComponentFactoryProvider(null, _stubImageAssets); });
            Assert.Throws<ArgumentNullException>(() => { _ = new ComponentFactoryProvider(_stubFontAssets, null); });
        }
    }
}