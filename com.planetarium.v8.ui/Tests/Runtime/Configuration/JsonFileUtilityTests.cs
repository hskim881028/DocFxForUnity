using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Runtime.Configuration;

namespace V8.UI.Tests
{
    public class JsonFileUtilityTests
    {
        private const string FileName = "test.json";
        private static readonly string FilePath = Path.Combine(Application.streamingAssetsPath, "JsonFileUtilityTests");

        [SetUp]
        public void SetUp()
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(FilePath))
            {
                Directory.Delete(FilePath, true);
            }
        }

        [Test]
        public void GetJsonFilesTest()
        {
            var path = Application.persistentDataPath;
            var fullPath = Path.Combine(path, FileName);
            File.WriteAllText(fullPath, string.Empty);
            var fileInfo = new FileInfo(fullPath);
            var jsonFiles = JsonFileUtility.GetJsonFiles(path);

            Assert.NotNull(jsonFiles);
            Assert.AreEqual(1, jsonFiles.Count());
            Assert.AreEqual(fileInfo.Name, jsonFiles.First().Name);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        [Test]
        public void GetJsonFilesExceptionTest()
        {
            Assert.Throws<Exception>(() => JsonFileUtility.GetJsonFiles(FilePath));
        }

        [Test]
        public void ConvertJsonFilesToJObjectTest()
        {
            const string json = @"
            {
                'Id': 'TestId',
                'Type': 'Image',
                'Children': [],
                'AnchorAlignmentMode': 'TopCenter',
                'SizeMode': 'Pixel',
                'Size': {'x': 100, 'y': 200},
                'PositionMode': 'Absolute',
                'Position': {'x': 10, 'y': 20},
                'Texture': 'SampleTexture'
            }";

            var filePath = Path.Combine(FilePath, FileName);
            File.WriteAllText(filePath, json);
            var fileInfo = new FileInfo(filePath);
            var jsonFiles = new List<FileInfo> { fileInfo };

            var jsonData = JsonFileUtility.ConvertJsonFilesToJObject(jsonFiles);

            Assert.AreEqual(1, jsonData.Count);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}