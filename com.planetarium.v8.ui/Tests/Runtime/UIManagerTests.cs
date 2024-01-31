using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using V8.UI.Elements.Basic;
using V8.UI.Runtime;
using V8.UI.Runtime.Provider;

namespace V8.UI.Tests
{
    public class UIManagerTests
    {
        private const string UIName = "TestUI";

        private const string Json = @"
            {
                'Id': 'TestId',
                'Type': 'Element',
                'Children': [
                    {
                        'Id': 'ChildId1',
                        'Type': 'Element'
                    },
                    {
                        'Id': 'ChildId2',
                        'Type': 'Element'
                    }
                ],
                'AnchorAlignmentMode': 'TopCenter',
                'SizeMode': 'Pixel',
                'Size': {'x': 100, 'y': 200},
                'PositionMode': 'Absolute',
                'Position': {'x': 10, 'y': 20}
            }";

        private ElementFactoryProvider _factoryProvider;
        private UIManager _uiManager;

        [SetUp]
        public void Setup()
        {
            _factoryProvider = new ElementFactoryProvider();
            var elementFactory = _factoryProvider.GetFactory(nameof(Label));
            var element = elementFactory.Create(JObject.Parse(Json));
            var data = new Dictionary<string, Element>
            {
                { UIName, element }
            };

            _uiManager = new UIManager(data);
        }

        [Test]
        public void GetTest()
        {
            var element = _uiManager.Get<Element>(UIName);
            Assert.IsNotNull(element);
            Assert.AreEqual("TestId", element.Id);
        }

        [Test]
        public void GetExceptionTest()
        {
            Assert.Throws<System.Exception>(() => _uiManager.Get<Element>("NonExistentElement"));
        }

        [Test]
        public void GetInvalidCastExceptionTest()
        {
            Assert.Throws<System.InvalidCastException>(() => _uiManager.Get<Image>(UIName));
        }
    }
}