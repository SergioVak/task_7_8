using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    class NumericalSequenceOfSquares : Sequence
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
