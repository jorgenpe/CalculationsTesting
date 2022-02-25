using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    public class CalculatorTest
    {
        // Test with theory. Inlinedata has two in values and the last value is the expected result.
        [Theory]
        [InlineData(2.1, 2, 4.1)]
        [InlineData(3.1, -2.5, 0.6)]
        [InlineData(4, 2, 6)]
        [InlineData(2.3, 2.2, 4.5)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 0, 0)]
        public void TestAddIs(double numberOne, double numberTwo, double expected)
        {
            //Create a new objekt of type calculator
            Calculator calculator = new Calculator();

            //Test the calculator by insert numbers in to the method Add in calculator class.
            //Compare it to the expected result.
            Assert.Equal(expected, calculator.Add(numberOne, numberTwo),1);
        }
        [Fact]
        public void TestAddIsNot()
        {
            //Arrange
            Calculator calculator = new Calculator();
            double expected = 4.5;
            //Act and Assert
            Assert.NotEqual(expected, calculator.Add(1.1, 3));
        }

        [Theory]
        [InlineData(new double[] { 2.1, 2,5.4 }, 9.5)]
        [InlineData(new double[] { 2.1, 0, 5.4, 1 }, 8.5)]
        [InlineData(new double[] { 2.1, 2, 5.4, 2.3, 5 }, 16.8)]
        [InlineData(new double[] { 2.1, 2, 5, 2, -10 }, 1.1)]
        [InlineData(new double[] { 2 }, 2)]
        [InlineData(new double[] { 0 }, 0)]
        public void TestAddArrayIs(double [] numbers, double expected)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act and Assert
            Assert.Equal(expected, calculator.Add(numbers),1);
        }


        // Test with theory. Inlinedata has two in values and the last value is the expected result.
        [Theory]
        [InlineData(2.1, 2, 0.1)]
        [InlineData(3.1, 2.5, 0.6)]
        [InlineData(2.6, -2, 4.6)]
        [InlineData(2.3, 2.6, -0.3)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 0, 0)]
        public void TestSubIs(double numberOne, double numberTwo, double expected)
        {
            //Create a new objekt of type calculator
            Calculator calculator = new Calculator();

            //Test the calculator by insert numbers in to the method Sub in calculator class.
            //Compare it to the expected result.
            Assert.Equal(expected, calculator.Sub(numberOne, numberTwo), 1);
        }
        [Fact]
        public void TestSubIsNot()
        { 
            //Arrange
            Calculator calculator = new Calculator();
            double expected = -4.5;
            //Act and Assert
            Assert.NotEqual(expected, calculator.Sub(1.1, 3));
        }

        [Theory]
        [InlineData(new double[] { 2.1, 2, 5.4 }, -5.3)]
        [InlineData(new double[] { (-2.1), 0, 5.4, 1 }, -8.5)]
        [InlineData(new double[] { 2.1, 2, 5.4, 2.3, 5 }, -12.6)]
        [InlineData(new double[] { 2.1, 2, 5, 2, -10 }, 3.1)]
        [InlineData(new double[] { 2 }, 2)]
        [InlineData(new double[] { 0 }, 0)]
        public void TestSubArrayIs(double[] numbers, double expected)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act and Assert
            Assert.Equal(expected, calculator.Sub(numbers), 1);
        }


        // Test with theory. Inlinedata has two in values and the last value is the expected result.
        [Theory]
        [InlineData(2.2, 10, 22)]
        [InlineData(-3.1, -20, 62)]
        [InlineData(2, 2, 4)]
        [InlineData(15.1, -3, -45.3)]
        [InlineData(2, 0, 0)]
        [InlineData(0, 0, 0)]
        public void TestMultiIs(double numberOne, double numberTwo, double expected)
        {
            //Create a new objekt of type calculator
            Calculator calculator = new Calculator();

            //Test the calculator by insert numbers in to the method Multi in calculator class.
            //Compare it to the expected result.
            Assert.Equal(expected, calculator.Multi(numberOne, numberTwo), 1);
        }

        [Fact]
        public void TestMultiIsNot()
        {
            //Arrange
            Calculator calculator = new Calculator();
            double expected = -2;
            //Act and Assert
            Assert.NotEqual(expected, calculator.Multi(1.1, 3));
        }

        // Test with theory. Inlinedata has two in values and the last value is the expected result.
        [Theory]
        [InlineData(2.2, 22, 0.1)]
        [InlineData(-300, -20, 15)]
        [InlineData(2, 2, 1)]
        [InlineData(15.3, -3, -5.1)]
        [InlineData(0, 2, 0)]
        public void TestDivIs(double numberOne, double numberTwo, double expected)
        {
            //Create a new objekt of type calculator
            Calculator calculator = new Calculator();

            //Test the calculator by insert numbers in to the method Div in calculator class.
            //Compare it to the expected result.
            Assert.Equal(expected, calculator.Div(numberOne, numberTwo), 1);
        }

        //Test of thrown DivideByZeroException
        [Fact]
        public void TestDivThrowsException()
        {
            //Arrange
            string expectedText = "Division by zero is not possible.";
            Calculator calculator = new Calculator();
            //Act
            var result = Assert.Throws<DivideByZeroException>(() => calculator.Div(0,0));
            //Assert
            Assert.Equal(expectedText, result.Message);
        }

        [Fact]
        public void TestDivIsNot()
        {
            //Arrange
            Calculator calculator = new Calculator();
            double expected = -2;
            //Act and Assert
            Assert.NotEqual(expected, calculator.Div(1.1, 3));
        }

    }
}
