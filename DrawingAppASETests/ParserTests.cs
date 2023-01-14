using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingAppASE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace DrawingAppASE.Tests
{
    /// <summary>
    /// Unit tests for Parser class
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        /// <summary>
        /// ParseAction method should run if commands and parameters are valid
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
        /// ParseAction method should throw appropriate exception when invalid command
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
        /// ParseAction method should throw appropriate exception when invalid parameter
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
                Assert.IsInstanceOfType(e, typeof(FormatException));
                Assert.AreEqual(e.Message, "One of the identified items was in an invalid format.");
            }
        }

        /// <summary>
        /// ParseAction method should run with valid command and valid user declared variable as command parameterss
        /// </summary>
        [TestMethod]
        public void ParseAction_WhenProvidedWithValidCommandAndValidUserDeclaredVariableAsParameters_RunsSuccessfully()
        {
            try
            {
                var bitmap = new Bitmap(300, 500);
                var graphics = Graphics.FromImage(bitmap);
                var pen = new Pen(Color.Red);
                Variable x = new Variable("x", 100);
                var commands = new List<string>() { "circle x" };
                Parser.ParseAction(graphics, pen, commands);
            }
            catch
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// ParseInt method should convert the string "10" to an integer 10
        /// </summary>
        [TestMethod]
        public void ParseInt_WhenProvidedwithNumberString_ReturnNumberAsInteger()
        {
            var number = "10";
            var result = Parser.ParseInt(number);
            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// ParseInt method throws FormatException when its string parameter is not a number
        /// </summary>
        [TestMethod]
        public void ParseInt_WhenNotProvidedwithNumberString_ThrowsFormatException()
        {
            try
            {
                var number = "invalidvariable";
                var result = Parser.ParseInt(number);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }

        /// <summary>
        /// ParseInt method returns variable value when user declared variable passed as parameter
        /// </summary>
        [TestMethod]
        public void ParseInt_WhenProvidedwithUserDeclaredVariable_ReturnVariableValueAsInterger()
        {
            Variable variablesTest = new Variable("x", 10);
            var result = Parser.ParseInt("x");
            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// ParseInt method throws FormatException when parameter is too big of a number
        /// </summary>
        [TestMethod]
        public void ParseInt_WhenProvidedwithBigNumberString_ThrowFormatException()
        {
            try
            {
                var number = "9999999999999999999999999999999999";
                var result = Parser.ParseInt(number);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }


    }
}