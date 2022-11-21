using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingAppASE;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingAppASE.Tests
{
    /// <summary>
    /// Unit tests for Parser class
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        /// <summary>
        /// Parse method should run if commands and parameters are valid
        /// </summary>
        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndValidParameters_RunsSuccessfully()
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

        /// <summary>
        /// Parse method should throw appropriate exception when invalid command
        /// </summary>
        [TestMethod]
        public void ParseAction_WhenProvidedWithInvalidCommandAndValidParameters_ThrowsInvalidCommandsException()
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

        /// <summary>
        /// Parse method should throw appropriate exception when invalid parameter
        /// </summary>
        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndInvalidParameters_ThrowsInvalidParametersException()
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
                Assert.AreEqual(e.Message, "Parameters have to be integers");
            }
        }
    }
}