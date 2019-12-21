using Xunit;
using System;

namespace Sequences.Tests
{
    public class SequencesTests
    {
        [Theory] 
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2)]
        public void ConstructorThowArgumentExeptionTest(double border)
        {
            NumericalSequenceOfSquares sequence;

            Assert.Throws<ArgumentException>(() => sequence = new NumericalSequenceOfSquares(border));
        }
    }
}
