using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Math;

namespace UnitTesting.GSEvgenievich
{
    public class Tests
    {
        private readonly BasicCalc _calculator;

        public Tests()
        {
            _calculator = new BasicCalc();
        }

        [Fact]
        public void LCM_ShouldReturnCorrectLargestMultipleNumber()
        {
            int result = _calculator.LCM(18, 24);
            Assert.Equal(72, result);
        }


        [Theory]
        [InlineData(10000, 100, 10000)]
        [InlineData(1, 2, 2)]
        [InlineData(5, 9, 45)]
        public void LCM_Theory(int a, int b, int expectedResult)
        {
            int result = _calculator.LCM(a, b);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LCM_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.LCM(-10, 10));
        }

        [Fact]
        public void IsPerfectNumber_ShouldReturnTrue()
        {
            bool result = _calculator.IsPerfectNumber(6);
            Assert.Equal(true, result);
        }


        [Theory]
        [InlineData(19, false)]
        [InlineData(28, true)]
        [InlineData(496, true)]
        public void IsPerfectNumber_Theory(int a, bool expectedResult)
        {
            bool result = _calculator.IsPerfectNumber(a);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void IsPerfectNumber_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.IsPerfectNumber(-10));
        }
    }
}
