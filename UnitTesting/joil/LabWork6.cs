using TestingLib.Math;

namespace UnitTesting.joil
{
    public class LabWork6
    {
        private readonly BasicCalc _calculator;

        public LabWork6()
        {
            _calculator = new BasicCalc();
        }

        [Fact]
        public void Sqrt_ShouldReturnCorrectSqrt()
        {
            double calc = _calculator.Sqrt(144);
            Assert.Equal(12, calc);
        }

        [Theory]
        [InlineData(144, 12)]
        [InlineData(0, 0)]
        [InlineData(3, 1.732)]
        public void Sqrt_Theory(double a, double expectedResult)
        {
            double calc = _calculator.Sqrt(a);
            Assert.Equal(expectedResult, calc, 0.001);
        }

        [Fact]
        public void Sqrt_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Sqrt(-25));
        }

        [Fact]
        public void IsPrime_ShouldReturnTrueIfPrime()
        {
            bool calc = _calculator.IsPrime(5);
            Assert.Equal(true, calc);
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

        [Fact]
        public void IsPrime_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.IsPrime(-2));
        }
    }
}
