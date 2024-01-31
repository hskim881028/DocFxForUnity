using Newtonsoft.Json;

namespace V8.UI.Elements.Basic
{
    public class Image : Element
    {
        private string _texture;

        [JsonConstructor]
        protected Image(string id, string type) : base(id, type)
        {
        }

        public string Texture
        {
            get => _texture;
            set => SetProperty(ref _texture, value, nameof(Texture));
        }
    }
}