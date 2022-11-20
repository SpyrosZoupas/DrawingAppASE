using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingAppASE.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void Draw_WhenProvidedWithGraphicsAndPen_ThenRunsSuccessfully()
        {
            try
            {
                var outputBitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(outputBitmap);
                var pen = new Pen(Color.Red);
                var sut = new Rectangle(0, 0, 50, 30);
                sut.Draw(graphics, pen, false);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Draw_WhenNotProvidedWithGraphicsAndPen_ThrowsNullReferenceException()
        {
            try
            {
                var sut = new Rectangle(0, 0, 50, 30);
                sut.Draw(null, null, false);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }
    }
}
