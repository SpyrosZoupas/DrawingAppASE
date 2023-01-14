using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingAppASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using System.Drawing;

namespace DrawingAppASE.Tests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        /// <summary>
        /// Shape Factory creates a valid Circle object of type Shape when provided with "circle" as parameter 
        /// </summary>
        [TestMethod]
        public void CreateShapeTest_WhenProvidedWithValidShapeName_CreatesShapeObject()
        {
            Circle expectedCircle = new Circle(0, 0, 100);

            ShapeFactory factory = new ShapeFactory();
            string shape = "circle";
            List<int> paramList = new List<int>();
            paramList.Add(0);
            paramList.Add(0);
            paramList.Add(100);

            Shape actualCircle = factory.CreateShape(shape, paramList);

            actualCircle.ShouldDeepEqual(expectedCircle);
        }

        /// <summary>
        /// Shape Factory throws Argument Exception when shape parameter is not a valid shape name
        /// </summary>
        [TestMethod()]
        public void CreateShapeTest_WhenProvidedWithInvalidShapeName_ThrowsArgumentException()
        {                 
            try
            {
                ShapeFactory factory = new ShapeFactory();
                string shape = "circlee";
                List<int> paramList = new List<int>();
                paramList.Add(0);
                paramList.Add(0);
                paramList.Add(100);

                Shape circle = factory.CreateShape(shape, paramList);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

        /// <summary>
        /// Shape Factory throws Argument Exception when paramList parameter contains more parameters for user command than needed
        /// </summary>
        [TestMethod()]
        public void CreateShapeTest_WhenProvidedWithMoreParametersThanNeeded_ThrowsArgumentException()
        {
            try
            {
                ShapeFactory factory = new ShapeFactory();
                string shape = "rectangle";
                List<int> paramList = new List<int>();
                paramList.Add(0);
                paramList.Add(0);
                paramList.Add(100);
                paramList.Add(200);
                paramList.Add(500);

                Shape rectangle = factory.CreateShape(shape, paramList);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

        /// <summary>
        /// Shape Factory throws Argument Exception when paramList parameter does not contain enough parameters for user command
        /// </summary>
        [TestMethod()]
        public void CreateShapeTest_WhenProvidedWithNotEnoughParameters_ThrowsArgumentException()
        {
            try
            {
                ShapeFactory factory = new ShapeFactory();
                string shape = "rectangle";
                List<int> paramList = new List<int>();
                paramList.Add(0);
                paramList.Add(0);
                paramList.Add(100);              

                Shape rectangle = factory.CreateShape(shape, paramList);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }
    }
}