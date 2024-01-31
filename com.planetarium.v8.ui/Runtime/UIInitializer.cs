using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Provider;

namespace V8.UI.Runtime
{
    /// <summary>
    /// Initializes and constructs the UI elements from provided data.
    /// </summary>
    public sealed class UIInitializer
    {
        private readonly RectTransform _canvas;
        private readonly IAssetList<TMP_FontAsset> _fontAssets;
        private readonly IAssetList<Texture2D> _imageAssets;

        /// <summary>
        /// Constructs a UIInitializer with references to the canvas and asset lists.
        /// </summary>
        public UIInitializer(RectTransform canvas, IAssetList<TMP_FontAsset> fontAssets, IAssetList<Texture2D> imageAssets)
        {
            _canvas = canvas;
            _fontAssets = fontAssets;
            _imageAssets = imageAssets;
        }

        /// <summary>
        /// Initializes the UI manager with UI data and constructs UI elements.
        /// </summary>
        /// <param name="uiData">Dictionary containing UI configuration data, keyed by UI names.</param>
        /// <returns>A UIManager instance managing the created UI elements.</returns>
        public UIManager Initialize(Dictionary<string, JToken> uiData)
        {
            var elementFactoryProvider = new ElementFactoryProvider();
            var interpreter = new UIDataInterpreter(elementFactoryProvider);
            var uis = interpreter.OrganizeElements(uiData);
            var componentFactoryProvider = new ComponentFactoryProvider(_fontAssets, _imageAssets);
            var uiBuilder = new ComponentBuilder(_canvas, componentFactoryProvider);
            uiBuilder.InstantiateUI(uis);
            var uiManager = new UIManager(uis);
            return uiManager;
        }

    }
}