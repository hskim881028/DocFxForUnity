using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;

namespace V8.UI.Tests
{
    public class ImageTests
    {
        private class TestableImage : Image
        {
            public TestableImage(string id, string type)
                : base(id, type)
            {
            }
        }

        private const string Json = @"
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

        [Test]
        public void DeserializationTest()
        {
            var image = JsonConvert.DeserializeObject<Image>(Json);

            Assert.AreEqual("TestId", image.Id);
            Assert.AreEqual(nameof(Image), image.Type);
            Assert.IsNotNull(image.Children);
            Assert.AreEqual(0, image.Children.Count);
            Assert.AreEqual(AlignmentMode.TopCenter, image.AnchorAlignmentMode);
            Assert.AreEqual(SizeMode.Pixel, image.SizeMode);
            Assert.AreEqual(new Vector2(100, 200), image.Size);
            Assert.AreEqual(PositionMode.Absolute, image.PositionMode);
            Assert.AreEqual(new Vector2(10, 20), image.Position);
            Assert.AreEqual("SampleTexture", image.Texture);
        }

        [Test]
        public void SetPropertyTest()
        {
            var image = JsonConvert.DeserializeObject<Image>(Json);
            var propertyChanges = new Dictionary<string, bool>
            {
                { nameof(Image.AnchorAlignmentMode), false },
                { nameof(Image.SizeMode), false },
                { nameof(Image.Size), false },
                { nameof(Image.PositionMode), false },
                { nameof(Image.Position), false },
                { nameof(Image.Texture), false }
            };
  
            image.PropertyChanged += (_, args) =>
            {
                if (propertyChanges.ContainsKey(args.PropertyName))
                {
                    propertyChanges[args.PropertyName] = true;
                }
            };

            image.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            image.SizeMode = SizeMode.Percent;
            image.Size = Vector2.zero;
            image.PositionMode = PositionMode.Relative;
            image.Position = Vector2.zero;
            image.Texture = "NewTexture";

            foreach (var property in propertyChanges.Values)
            {
                Assert.IsTrue(property);
            }
        }

        [Test]
        public void DisposeTest()
        {
            var image = new TestableImage("TestId", "Image");
            var eventHandlerCalled = false;
            image.PropertyChanged += (_, _) => { eventHandlerCalled = true; };
            image.Dispose();
            image.AnchorAlignmentMode = AlignmentMode.BottomLeft;
            Assert.IsFalse(eventHandlerCalled);
        }
    }
}