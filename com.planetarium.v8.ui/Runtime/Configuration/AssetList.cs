using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace V8.UI.Runtime.Configuration
{
    /// <summary>
    /// Manages a collection of assets of type T, allowing retrieval by name.
    /// </summary>
    /// <typeparam name="T">The type of asset, which must be derived from Unity's Object class</typeparam>
    public abstract class AssetList<T> : ScriptableObject, IAssetList<T> where T : Object
    {
        [SerializeField] protected List<T> _assets;

        public bool TryGetAsset(string assetName, out T asset)
        {
            asset = default;
            foreach (var a in _assets.Where(a => a.name == assetName))
            {
                asset = a;
                return true;
            }

            // Debug.LogError($"Asset with name '{assetName}' not found.");
            return false;
        }
    }
}