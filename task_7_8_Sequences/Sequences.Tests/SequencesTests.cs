using Xunit;
using System;

namespace Sequences.Tests
{
    public class SequencesTests
    {
        [Theory] 
        [InlineData(-130)]
        [InlineData(0)]
        [InlineData(-2)]
        public void ConstructorThowArgumentExeptionTest(double border)
        {
            NumericalSequenceOfSquares sequence;

            Assert.Throws<ArgumentException>(() => sequence = new NumericalSequenceOfSquares(border));
        }

        [Theory]
        [InlineData(10,10)]
        [InlineData(15,15)]
        [InlineData(230,230)]
        public void ConstructorAcceptParameterTest(double border, double expected)
        {
            NumericalSequenceOfSquares sequence = new NumericalSequenceOfSquares(border);

            double actual = sequence.Border;

            Assert.Equal(expected, actual);
        }
    }
}
