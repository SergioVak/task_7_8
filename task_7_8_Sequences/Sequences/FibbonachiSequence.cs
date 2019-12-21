using System;
using System.Collections.Generic;

namespace Sequences
{
    public class FibbonachiSequence : Sequence
    {
        public int LeftBorder {get; private set;}
        public int RightBorder {get; private set;}

        public FibbonachiSequence(int leftBorder, int rightBorder)
        {
            if (leftBorder < 1 || rightBorder < 1)
            {
                throw new ArgumentException();
            }

            if (leftBorder > rightBorder)
            {
                RightBorder = leftBorder;
                LeftBorder = rightBorder;
            }
            else
            {
                LeftBorder = leftBorder;
                RightBorder = rightBorder;
            }
        }

        protected override IEnumerator<int> GetElement()
        {
            checked
            {
                int x = 0;
                int y = 1;

                for (int i = 0; i <= RightBorder; i = x)
                {
                    x = y;
                    y += i;

                    if (i >= LeftBorder)
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
