using Newtonsoft.Json;
using UnityEngine;
using V8.UI.Configuration;

namespace V8.UI.Elements.Basic
{
    public class Label : Element
    {
        private AlignmentMode _textAlignmentMode;
        private string _font;
        private Color _color;
        private int _fontSize;
        private string _text;

        [JsonConstructor]
        protected Label(string id, string type) : base(id, type)
        {
        }

        public AlignmentMode TextAlignmentMode
        {
            get => _textAlignmentMode;
            set => SetProperty(ref _textAlignmentMode, value, nameof(TextAlignmentMode));
        }

        public string Font
        {
            get => _font;
            set => SetProperty(ref _font, value, nameof(Font));
        }

        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value, nameof(Color));
        }

        public int FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value, nameof(FontSize));
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value, nameof(Text));
        }
    }
}