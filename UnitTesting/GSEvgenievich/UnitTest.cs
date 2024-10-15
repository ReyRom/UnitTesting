using Microsoft.VisualStudio.TestPlatform.TestHost;
using TestingLib.Math;

namespace UnitTesting.GSEvgenievich
{
    public class UnitTest
    {
        private readonly BasicCalc _calculator;

        public UnitTest()
        {
            _calculator = new BasicCalc();
        }

        // Задание 1
        [Fact]
        public void LCM_PositiveNumbers_ReturnsCorrectLCM()
        {
            int a = 12;
            int b = 15;
            int expectedResult = 60;

            int result = _calculator.LCM(a, b);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(4, 6)]
        [InlineData(7, 11)]
        public void LCM_MultipleInputs_ReturnsCorrectLCM(int a, int b)
        {
            int result = _calculator.LCM(a, b);

            Assert.True(result % a == 0 && result % b == 0);
        }

        [Fact]
        public void LCM_NegativeNumbers_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.LCM(-13, 16));
        }

        // Задание 2
        [Fact]
        public void IsPrime_ValidInput_ReturnsCorrectResult()
        {
            int n = 7;

            bool result = _calculator.IsPrime(n);

            Assert.True(result);
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(11, true)]
        public void IsPrime_MultipleInputs_ReturnsExpectedResults(int n,bool expectedResult)
        {
            bool result = _calculator.IsPrime(n);

            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void IsPrime_InvalidInput_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.IsPrime(-1));
        }
    }
}
