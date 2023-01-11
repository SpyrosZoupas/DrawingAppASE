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