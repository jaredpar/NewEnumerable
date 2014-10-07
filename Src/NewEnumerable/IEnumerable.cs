using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    public interface IEnumerable<TElement, TIterator>
    {
        TIterator Start { get; }

        bool TryGetNext(ref TIterator current, out TElement value);
    }
}
