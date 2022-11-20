using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace DrawingAppASE.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Draw_WhenProvidedWithGraphicsAndPen_ThenRunsSuccessfully()
        {
            try
            {
                var outputBitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(outputBitmap);
                var pen = new Pen(Color.Red);
                var sut = new Circle(0, 0, 10);
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
                var sut = new Circle(0, 0, 50);
                sut.Draw(null, null, false);
            } 
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }

        }
    }
}
