using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingAppASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParseAction_oneMatchingStringLowerCase_returnsCorrectAction()
        {
            var input = new List<string> { "circle" };

            var result = Parser.ParseAction(input);

            //Assert.AreEqual(Action.Circle, result); what?
        }

        public void ParseAction_oneMatchingStringUpperCase_returnsCorrectAction()
        {
            var input = new List<string> { "CIRCLE" };

            var result = Parser.ParseAction(input);

            //Assert.AreEqual(Action.Circle, result); what?
        }

        public void ParseAction_oneMatchingStringMixedCase_returnsCorrectAction()
        {
            var input = new List<string> { "cIrClE" };

            var result = Parser.ParseAction(input);

            //Assert.AreEqual(Action.Circle, result); what?
        }

        public void ParseAction_oneMatchingStringTwoNonMatching_returnsCorrectAction()
        {
            var input = new List<string> { "circle", "pear", "banana" };

            var result = Parser.ParseAction(input);

            //Assert.AreEqual(Action.Circle, result); what?
        }

        public void ParseAction_twoMatchingStrings_returnsFirstAction()
        {
            var input = new List<string> { "circle" };

            var result = Parser.ParseAction(input);

            //Assert.AreEqual(Action.Circle, result); what?
        }
    }
}