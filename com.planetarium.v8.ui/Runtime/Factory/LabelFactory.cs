using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory.Extensions;

namespace V8.UI.Runtime.Factory
{
    internal class LabelFactory : ComponentFactory<Label>
    {
        private readonly ElementComponentFactory _elementComponentFactory;
        private readonly IAssetList<TMP_FontAsset> _fontAssets;
        private const int FontMinSize = 2;

        public LabelFactory(ElementComponentFactory elementComponentFactory, IAssetList<TMP_FontAsset> fontAssets)
        {
            _elementComponentFactory = elementComponentFactory;
            _fontAssets = fontAssets;
        }

        protected override RectTransform CreateTyped(Label element, RectTransform parent)
        {
            var component = _elementComponentFactory.Create(element, parent);
            var go = new GameObject(element.Type);
            var rt = go.AddComponent<RectTransform>();
            rt.ResetForChild(component);

            var tmp = go.AddComponent<TextMeshProUGUI>();
            ConfigureLabel(element, tmp);
            return rt;
        }

        private void ConfigureLabel(Label element, TMP_Text tmp)
        {
            tmp.enableAutoSizing = true;
            tmp.fontSizeMin = FontMinSize;

            UpdateAlignment(tmp, element.TextAlignmentMode);
            UpdateFont(tmp, element.Font);
            UpdateColor(tmp, element.Color);
            UpdateFontSize(tmp, element.FontSize);
            UpdateText(tmp, element.Text);

            element.PropertyChanged += (_, e) => OnPropertyChanged(e, tmp, element);
        }

        private void UpdateAlignment(TMP_Text tmp, AlignmentMode mode)
        {
            tmp.alignment = UnityEnumMapper.ToTextAlignmentOptions(mode);
        }

        private void UpdateFont(TMP_Text tmp, string fontName)
        {
            if (_fontAssets.TryGetAsset(fontName, out var newFont))
            {
                tmp.font = newFont;
            }
        }

        private void UpdateColor(Graphic tmp, Color color)
        {
            tmp.color = color;
        }

        private void UpdateFontSize(TMP_Text tmp, float fontSizeMax)
        {
            tmp.fontSizeMax = fontSizeMax;
        }

        private void UpdateText(TMP_Text tmp, string text)
        {
            tmp.text = text;
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e, TMP_Text tmp, Label element)
        {
            switch (e.PropertyName)
            {
                case nameof(Label.TextAlignmentMode):
                    UpdateAlignment(tmp, element.TextAlignmentMode);
                    break;
                case nameof(Label.Font):
                    UpdateFont(tmp, element.Font);
                    break;
                case nameof(Label.Color):
                    UpdateColor(tmp, element.Color);
                    break;
                case nameof(Label.FontSize):
                    UpdateFontSize(tmp, element.FontSize);
                    break;
                case nameof(Label.Text):
                    UpdateText(tmp, element.Text);
                    break;
            }
        }
    }
}