using NUnit.Framework;
using V8.UI.Configuration;

namespace V8.UI.Tests.Configuration
{
    public class PaddingTests
    {
        [Test]
        public void PaddingTest()
        {
            const int left = 10;
            const int right = 20;
            const int top = 30;
            const int bottom = 40;

            var padding = new Padding(left, right, top, bottom);

            Assert.AreEqual(left, padding.Left);
            Assert.AreEqual(right, padding.Right);
            Assert.AreEqual(top, padding.Top);
            Assert.AreEqual(bottom, padding.Bottom);
        }
    }
}