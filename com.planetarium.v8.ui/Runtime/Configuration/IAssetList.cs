using UnityEngine;

namespace V8.UI.Runtime.Configuration
{
    public interface IAssetList<T> where T : Object
    {
        public bool TryGetAsset(string assetName, out T asset);
    }
}