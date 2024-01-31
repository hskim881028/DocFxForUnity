using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;

namespace V8.UI.Tests
{
    public class LabelTests
    {
        private class TestableLabel : Image
        {
            public TestableLabel(string id, string type)
                : base(id, type)
            {
            }
        }

        private const string Json = @"
            {
                'Id': 'TestId',
                'Type': 'Label',
                'Children': [],
                'AnchorAlignmentMode': 'MiddleCenter',
                'SizeMode': 'Pixel',
                'Size': {'x': 100, 'y': 200},
                'PositionMode': 'Absolute',
                'Position': {'x': 10, 'y': 20},
                'TextAlignmentMode': 'BottomRight',
                'Font': 'NotoSans-SDF',
                'Color': {'R': 1, 'G': 1, 'B': 1, 'A': 1},
                'FontSize': 12,
                'Text': 'Hello World!'
            }";

        [Test]
        public void DeserializationTest()
        {
            var label = JsonConvert.DeserializeObject<Label>(Json);

            Assert.AreEqual("TestId", label.Id);
            Assert.AreEqual(nameof(Label), label.Type);
            Assert.IsNotNull(label.Children);
            Assert.AreEqual(0, label.Children.Count);
            Assert.AreEqual(AlignmentMode.MiddleCenter, label.AnchorAlignmentMode);
            Assert.AreEqual(SizeMode.Pixel, label.SizeMode);
            Assert.AreEqual(new Vector2(100, 200), label.Size);
            Assert.AreEqual(PositionMode.Absolute, label.PositionMode);
            Assert.AreEqual(new Vector2(10, 20), label.Position);
            Assert.AreEqual(AlignmentMode.BottomRight, label.TextAlignmentMode);
            Assert.AreEqual("NotoSans-SDF", label.Font);
            Assert.AreEqual(new Color(1, 1, 1, 1), label.Color);
            Assert.AreEqual(12, label.FontSize);
            Assert.AreEqual("Hello World!", label.Text);
        }

        [Test]
        public void SetPropertyTest()
        {
            var label = JsonConvert.DeserializeObject<Label>(Json);
            var propertyChanges = new Dictionary<string, bool>
            {
                { nameof(Label.AnchorAlignmentMode), false },
                { nameof(Label.SizeMode), false },
                { nameof(Label.Size), false },
                { nameof(Label.PositionMode), false },
                { nameof(Label.Position), false },
                { nameof(Label.TextAlignmentMode), false },
                { nameof(Label.Font), false },
                { nameof(Label.Color), false },
                { nameof(Label.FontSize), false },
                { nameof(Label.Text), false },
            };

            label.PropertyChanged += (_, args) =>
            {
                if (propertyChanges.ContainsKey(args.PropertyName))
                {
                    propertyChanges[args.PropertyName] = true;
                }
            };

            label.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            label.SizeMode = SizeMode.Percent;
            label.Size = Vector2.zero;
            label.PositionMode = PositionMode.Relative;
            label.Position = Vector2.zero;
            label.TextAlignmentMode = AlignmentMode.MiddleRight;
            label.Font = "NewFont";
            label.Color = new Color(0, 0, 0, 0);
            label.FontSize = 24;
            label.Text = "Updated Text";

            foreach (var property in propertyChanges.Values)
            {
                Assert.IsTrue(property);
            }
        }

        [Test]
        public void DisposeTest()
        {
            var label = new TestableLabel("TestId", "TestType");
            var eventHandlerCalled = false;
            label.PropertyChanged += (_, e) => { eventHandlerCalled = true; };
            label.Dispose();
            label.AnchorAlignmentMode = AlignmentMode.MiddleLeft;
            Assert.IsFalse(eventHandlerCalled);
        }
    }
}