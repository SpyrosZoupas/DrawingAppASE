using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingAppASE;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingAppASE.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndValidParameters_ThenRunsSuccessfully()
        {
            try
            {
                var bitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(bitmap);
                var pen = new Pen(Color.Red);
                var commands = new List<string>() { "circle 50" };
                Parser.ParseAction(graphics, pen, commands);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndValidParameters_ThenThrowsInvalidCommandsException()
        {
            try
            {
                var bitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(bitmap);
                var pen = new Pen(Color.Red);
                var commands = new List<string>() { "test 50" };
                Parser.ParseAction(graphics, pen, commands);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual(e.Message, "Invalid command");
            }
        }

        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndValidParameters_ThenThrowsInvalidParametersException()
        {
            try
            {
                var bitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(bitmap);
                var pen = new Pen(Color.Red);
                var commands = new List<string>() { "circle test" };
                Parser.ParseAction(graphics, pen, commands);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual(e.Message, "Invalid parameters");
            }
        }
    }
}