using System.Collections;
using System.Collections.Generic;

namespace Sequences
{
    public abstract class Sequence : IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            IEnumerator<int> enumerator = this.GetElement();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        protected abstract IEnumerator<int> GetElement();

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
