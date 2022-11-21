using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace DrawingAppASE.Tests
{
    /// <summary>
    /// Unit tests for Circle class
    /// </summary>
    [TestClass]
    public class CircleTests
    {
        /// <summary>
        /// testing draw method of Circle class, when provided with correct parameters method should be called
        /// </summary>
        [TestMethod]
        public void Draw_WhenProvidedWithGraphicsAndPen_RunsSuccessfully()
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

        /// <summary>
        /// testing draw method, when graphics or pen parameters are missing should throw appropriate exception
        /// </summary>
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
