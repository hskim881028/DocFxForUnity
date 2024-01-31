using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using V8.UI.Runtime;
using V8.UI.Runtime.Provider;

namespace V8.UI.Tests
{
    public class UIDataInterpreterTests
    {
        [Test]
        public void OrganizeUIElementsTest()
        {
            const string json = @"
                {
                    ""Id"": ""Layout_1"",
                    ""Type"": ""Layout"",
                    ""ChildAlignmentMode"": ""TopLeft"",
                    ""ChildConstraintMode"": ""FixedRowCount"",
                    ""CornerMode"": ""UpperLeft"",
                    ""AxisMode"": ""Horizontal"",
                    ""Padding"": {
                        ""Left"": 10,
                        ""Right"": 10,
                        ""Top"": 5,
                        ""Bottom"": 5
                    },
                    ""ChildSize"": {
                        ""X"": 100,
                        ""Y"": 100
                    },
                    ""Spacing"": {
                        ""X"": 2,
                        ""Y"": 2
                    },
                    ""ChildConstraintCount"": 1,
                    ""SizeMode"": ""Pixel"",
                    ""Size"": {
                        ""X"": 100,
                        ""Y"": 100
                    },
                    ""PositionMode"": ""Relative"",
                    ""Position"": {
                        ""X"": 0,
                        ""Y"": 80
                    },
                    ""Children"": [
                        {
                            ""Id"": ""Label_1"",
                            ""Type"": ""Label"",
                            ""AnchorAlignmentMode"": ""TopLeft"",
                            ""SizeMode"": ""Pixel"",
                            ""Size"": {
                                ""X"": 200,
                                ""Y"": 200
                            },
                            ""PositionMode"": ""Absolute"",
                            ""Position"": {
                                ""X"": 200,
                                ""Y"": 200
                            },
                            ""TextAlignmentMode"": ""BottomRight"",
                            ""Font"": ""NotoSans-SDF"",
                            ""Color"": {
                                ""R"": 1,
                                ""G"": 1,
                                ""B"": 1,
                                ""A"": 1
                            },
                            ""FontSize"": 12,
                            ""Text"": ""Hello World!"",
                            ""Children"": []
                        },
                        {
                            ""Id"": ""Image_1"",
                            ""Type"": ""Image"",
                            ""AnchorAlignmentMode"": ""TopLeft"",
                            ""SizeMode"": ""Pixel"",
                            ""Size"": {
                                ""X"": 100,
                                ""Y"": 100
                            },
                            ""PositionMode"": ""Absolute"",
                            ""Position"": {
                                ""X"": 100,
                                ""Y"": 100
                            },
                            ""Texture"": ""TestImage"",
                            ""Children"": []
                        },
                        {
                            ""Id"": ""Element_1"",
                            ""Type"": ""Element"",
                            ""AnchorAlignmentMode"": ""TopLeft"",
                            ""SizeMode"": ""Pixel"",
                            ""Size"": {
                                ""X"": 10,
                                ""Y"": 10
                            },
                            ""PositionMode"": ""Absolute"",
                            ""Position"": {
                                ""X"": 10,
                                ""Y"": 10
                            },
                            ""Children"": []
                        }
                    ]
                }
            ";
            
            var jObject = JObject.Parse(json);
            var data = new Dictionary<string, JToken>()
            {
                { "test",  jObject}
            };
            var elementFactoryProvider = new ElementFactoryProvider();
            var interpreter = new UIDataInterpreter(elementFactoryProvider);
            var uiElements = interpreter.OrganizeElements(data);

            Assert.IsNotNull(uiElements);
            Assert.AreEqual("test", uiElements.First().Key);

            var element = uiElements.First().Value;
            Assert.AreEqual("Layout_1", element.Id);
            Assert.AreEqual("Layout", element.Type);
            Assert.AreEqual(3, element.Children.Count);
        }
    }
}