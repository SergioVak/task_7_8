using System.Collections.Generic;

namespace Sequences
{
    public class NumericalSequenceOfSquares : Sequence
    {
        public double Border { get; private set; }

        public NumericalSequenceOfSquares(double border)
        {
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
