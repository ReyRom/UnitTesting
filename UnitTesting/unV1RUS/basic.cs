using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Math;

namespace UnitTesting.unV1RUS
{
    public class BasicCalcTest
    {
        private readonly BasicCalc _calculator;

        public BasicCalcTest()
        {
            _calculator = new BasicCalc();
        }


        [Fact]
        public void IsPrime_ShouldReturnTrueIfPrime()
        {
            bool calc = _calculator.IsPrime(5);
            Assert.Equal(true, calc);
        }

        [Fact]
        public void IsPrime_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.IsPrime(-2));
        }


        [Theory]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(1, false)]

        public void IsPrime_Theory(int a, bool expectedResult)
        {
            bool calc = _calculator.IsPrime(a);
            Assert.Equal(expectedResult, calc);
        }

    }
}
