using Xunit;
using System;

namespace Sequences.Tests
{
    public class GetSequenceTests
    {
        [Theory]
        [InlineData(10, "1 2 3 ")]
        [InlineData(20, "1 2 3 4 ")]
        [InlineData(100, "1 2 3 4 5 6 7 8 9 ")]
        [InlineData(100, "1 2 3 4 5 6 7 8 9 10 ")]
        public void NotEmptySequnceTest(int border, string expected)
        {
            string actual = string.Empty;

            Sequence sequence = new NumericalSequenceOfSquares(border);
            SequenceUI userInterface = new SequenceUI();

            actual = userInterface.ConvertSequenceToString(sequence);

            Assert.Equal(expected, actual);
        }
    }
}
