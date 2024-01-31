using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace V8.UI.Runtime.Configuration
{
    public static class JsonFileUtility
    {
        public static IEnumerable<FileInfo> GetJsonFiles(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var jsonFiles = directoryInfo.GetFiles("*.json");
            if (jsonFiles.Length == 0)
            {
                throw new Exception("No JSON files found");
            }

            return jsonFiles;
        }

        public static Dictionary<string, JToken> ConvertJsonFilesToJObject(IEnumerable<FileInfo> jsonFiles)
        {
            var jsonData = new Dictionary<string, JToken>();
            foreach (var file in jsonFiles)
            {
                var uiName = Path.GetFileNameWithoutExtension(file.Name);
                var json = File.ReadAllText(file.FullName);
                var jObject = JObject.Parse(json);
                jsonData.Add(uiName, jObject);
            }

            return jsonData;
        }
    }
}