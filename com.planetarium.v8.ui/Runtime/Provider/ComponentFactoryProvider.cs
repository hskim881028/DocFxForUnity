using TMPro;
using UnityEngine;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory;

namespace V8.UI.Runtime.Provider
{
    internal class ComponentFactoryProvider : FactoryProvider<IComponentFactory>
    {
        public ComponentFactoryProvider(IAssetList<TMP_FontAsset> fontAssets, IAssetList<Texture2D> imageAssets)
        {
            var uiElementFactory = new ElementComponentFactory();
            RegisterFactory(uiElementFactory);
            RegisterFactory(new LabelFactory(uiElementFactory, fontAssets));
            RegisterFactory(new ImageFactory(uiElementFactory, imageAssets));
            RegisterFactory(new LayoutFactory(uiElementFactory));
        }
    }
}