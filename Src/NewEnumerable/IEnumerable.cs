using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    public interface IEnumerable<TElement, TEnumerator>
    {
        TEnumerator Start { get; }

        bool TryGetNext(ref TEnumerator current, out TElement value);
    }
}
