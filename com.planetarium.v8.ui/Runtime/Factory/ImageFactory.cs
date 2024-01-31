using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory.Extensions;
using Rect = UnityEngine.Rect;

namespace V8.UI.Runtime.Factory
{
    internal class ImageFactory : ComponentFactory<Image>
    {
        private readonly ElementComponentFactory _elementComponentFactory;
        private readonly IAssetList<Texture2D> _imageAssets;
        private readonly Dictionary<string, Sprite> _cachedSprites = new();

        public ImageFactory(ElementComponentFactory elementComponentFactory, IAssetList<Texture2D> imageAssets)
        {
            _elementComponentFactory = elementComponentFactory;
            _imageAssets = imageAssets;
        }

        protected override RectTransform CreateTyped(Image element, RectTransform parent)
        {
            var component = _elementComponentFactory.Create(element, parent);
            var go = new GameObject(element.Type);
            var rt = go.AddComponent<RectTransform>();
            rt.ResetForChild(component);

            var imageComponent = go.AddComponent<UnityEngine.UI.Image>();
            ConfigureImage(element, imageComponent);
            return rt;
        }

        private void ConfigureImage(Image element, UnityEngine.UI.Image img)
        {
            UpdateSprite(img, element);

            element.PropertyChanged += (_, e) => OnPropertyChanged(e, img, element);
        }

        private void UpdateSprite(UnityEngine.UI.Image image, Image element)
        {
            image.sprite = GetSprite(element);
        }

        private Sprite GetSprite(Image element)
        {
            if (_cachedSprites.TryGetValue(element.Texture, out var sprite))
            {
                return sprite;
            }

            if (!_imageAssets.TryGetAsset(element.Texture, out var texture))
            {
                throw new Exception($"Texture not found: {element.Texture}");
            }

            var rect = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rect, Vector2.one);
            sprite.name = element.Texture;
            _cachedSprites.Add(element.Texture, sprite);
            return sprite;
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e, UnityEngine.UI.Image img, Image element)
        {
            switch (e.PropertyName)
            {
                case nameof(Image.Texture):
                    UpdateSprite(img, element);
                    break;
            }
        }
    }
}