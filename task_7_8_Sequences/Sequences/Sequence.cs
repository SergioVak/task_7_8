using System.Collections;
using System.Collections.Generic;

namespace Sequences
{
    public abstract class Sequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            IEnumerator<int> enumerator = this.GetElement();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        protected abstract IEnumerator<int> GetElement();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
