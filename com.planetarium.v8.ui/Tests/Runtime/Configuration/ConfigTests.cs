using System.IO;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class ConfigTests
    {
        [Test]
        public void JsonDirectoryPath_ReturnsCorrectPath()
        {
            var actualPath = Config.JsonDirectoryPath;
#if UNITY_EDITOR
            var expectedPathInEditor = Path.Combine(Application.streamingAssetsPath, "UI");
            Assert.AreEqual(expectedPathInEditor, actualPath);
#else
            var expectedPathInBuild = Path.Combine(Application.persistentDataPath, "UI");
            Assert.AreEqual(expectedPathInBuild, actualPath);
#endif
        }
    }
}