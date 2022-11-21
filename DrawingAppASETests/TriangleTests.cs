using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingAppASE.Tests
{
    /// <summary>
    /// Unit tests for Triangle class
    /// </summary>
    [TestClass]
    public class TriangleTests
    {
        /// <summary>
        /// testing draw method of Triangle class, when provided with correct parameters method should be called
        /// </summary>
        [TestMethod]
        public void Draw_WhenProvidedWithGraphicsAndPen_ThenRunsSuccessfully()
        {
            try
            {
                var outputBitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(outputBitmap);
                var pen = new Pen(Color.Red);
                var sut = new Triangle(0, 0, 30, 30, 50, 50, 100, 100);
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
                var sut = new Triangle(0, 0, 30, 30, 50, 50, 100, 100);
                sut.Draw(null, null, false);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }
    }
}
