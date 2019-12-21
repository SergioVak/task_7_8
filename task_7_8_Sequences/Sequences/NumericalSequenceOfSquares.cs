using System;
using System.Collections.Generic;

namespace Sequences
{
    public class NumericalSequenceOfSquares : Sequence
    {
        public double Border { get; private set; }

        public NumericalSequenceOfSquares(double border)
        {
            if (border < 1)
            {
                throw new ArgumentException("Border should be no less than 1 ");
            }

            Border = border;
        }

        protected override IEnumerator<int> GetElement()
        {
            for (int index = 1; index * index < Border; index++)
            {
                yield return index;
            }
        }
    }
}
