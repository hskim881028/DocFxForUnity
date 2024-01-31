using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using V8.UI.Elements.Basic;
using V8.UI.Runtime;
using V8.UI.Runtime.Factory;
using V8.UI.Runtime.Provider;

namespace V8.UI.Tests
{
    public class ElementFactoryProviderTests
    {
        private ElementFactoryProvider _factoryProvider;

        [SetUp]
        public void SetUp()
        {
            _factoryProvider = new ElementFactoryProvider();
        }
        
        [Test]
        public void FactoryRegistrationTest()
        {
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(Element)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(Label)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(Image)));
            Assert.IsNotNull(_factoryProvider.GetFactory(nameof(Layout)));
            

        }
        
        [Test]
        public void FactoryCreationTest()
        {
            Assert.IsInstanceOf<ElementFactory<Element>>(_factoryProvider.GetFactory(nameof(Element)));
            Assert.IsInstanceOf<ElementFactory<Label>>(_factoryProvider.GetFactory(nameof(Label)));
            Assert.IsInstanceOf<ElementFactory<Image>>(_factoryProvider.GetFactory(nameof(Image)));
            Assert.IsInstanceOf<ElementFactory<Layout>>(_factoryProvider.GetFactory(nameof(Layout)));
            
        }
        
        [Test]
        public void ExceptionForUnregisteredFactoryTest()
        {
            Assert.Throws<NotImplementedException>(() => _factoryProvider.GetFactory("NonExistentFactory"));
        }
        
        [Test]
        public void GetFactoryExceptionTest()
        {
            const string invalidJson = @"
            {
                ""Id"": ""Image_1"",
                ""Type"": ""WrongType"",
                ""AnchorAlignmentMode"": ""TopLeft"",
                ""SizeMode"": ""Pixel"",
                ""Size"": {
                  ""X"": 100,
                  ""Y"": 100
                },
                ""PositionMode"": ""Relative"",
                ""Position"": {
                  ""X"": 50,
                  ""Y"": 50
                },
                ""Texture"": ""TestImage"",
                ""Children"": []
            }
            ";
        
            var jObject = JObject.Parse(invalidJson);
            var data = new Dictionary<string, JToken>()
            {
                { "test", jObject }
            };
            
            var elementFactoryProvider = new ElementFactoryProvider();
            var interpreter = new UIDataInterpreter(elementFactoryProvider);
            Assert.Throws<NotImplementedException>(() => interpreter.OrganizeElements(data));
        }   
    }
}