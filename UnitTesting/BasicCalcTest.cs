using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Math;

namespace UnitTesting
{
    public class BasicCalcTest
    {
        private readonly BasicCalc _calculator;

        public BasicCalcTest()
        {
            _calculator = new BasicCalc();
        }


        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.Equal(5, result);
        }


        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]
        public void Add_Theory(int a, int b, int expectedResult)
        {
            int result = _calculator.Add(a, b);
            Assert.Equal(expectedResult, result);
        }
     
    }
}
