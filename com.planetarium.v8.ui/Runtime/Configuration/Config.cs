using System.IO;
using UnityEngine;

namespace V8.UI.Runtime.Configuration
{
    public class Config
    {
        private const string DirectoryName = "UI";
        
        public static string JsonDirectoryPath
        {
            get
            {
#if UNITY_EDITOR
                return Path.Combine(Application.streamingAssetsPath, DirectoryName);
#else
                return Path.Combine(Application.persistentDataPath, DirectoryName);
#endif
            }
        }
    }
}