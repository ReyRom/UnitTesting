using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Math;

namespace UnitTesting
{
    public class Testing
    {
        private readonly BasicCalc _calculator;

        public Testing()
        {
            _calculator = new BasicCalc();
        }

        [Fact]
        public void Factorial_ShouldReturnCorrectValue()
        {
            double result = _calculator.Factorial(4);
            Assert.Equal(24, result);
        }

        [Theory]
        [InlineData(3, 6)]
        [InlineData(1, 1)]
        [InlineData(0, 1)]
        public void Factorial_Theory(int a, int expectedResult)
        {
            double result = _calculator.Factorial(a);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Factorial_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-2));
        }

        [Fact]
        public void SolveQuadraticEquation_ShouldCorrectValue()
        {
            (double?, double?) result = _calculator.SolveQuadraticEquation(2, -5, 2);
            Assert.Equal((2, 0.5), result);
        }

        [Theory]
        [InlineData(1, -2, -15, 5, -3)]
        [InlineData(5, -9, -2, 2, -0.2)]
        [InlineData(2, -11, -21, 7, -1.5)]
        public void SolveQuadraticEquation_Theory(double a, double b, double c, double expectedResult1, double expectedResult2)
        {
            (double?, double?) result = _calculator.SolveQuadraticEquation(a, b, c);
            Assert.Equal(expectedResult1, result.Item1);
            Assert.Equal(expectedResult2, result.Item2);
        }

        [Fact]
        public void SolveQuadraticEquation_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.SolveQuadraticEquation(0, -2, -10));
        }
    }
}
