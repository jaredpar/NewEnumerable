using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    public struct Enumerable<TElement> : IEnumerable<TElement, Enumerable<TElement>.CommonEnumerator>
    {
        public abstract class CommonEnumerator
        {
            internal abstract CommonEnumerator GetEnumeratorForConsumption();

            internal abstract bool TryGetNext(out TElement value);
        }

        public sealed class CommonEnumeratorImpl<TEnumerator> : CommonEnumerator
        {
            private readonly IEnumerable<TElement, TEnumerator> _enumerable;
            private TEnumerator _enumerator;
            private bool _canReuse;

            public CommonEnumeratorImpl(IEnumerable<TElement, TEnumerator> enumerable)
            {
                _enumerable = enumerable;
                _canReuse = true;
            }

            internal override CommonEnumerator GetEnumeratorForConsumption()
            {
                var enumerator = _canReuse
                    ? this
                    : new CommonEnumeratorImpl<TEnumerator>(_enumerable);

                enumerator._enumerator = _enumerable.Start;
                enumerator._canReuse = false;
                return enumerator;
            }

            internal override bool TryGetNext(out TElement value)
            {
                if (_enumerable.TryGetNext(ref _enumerator, out value))
                {
                    return true;
                }

                _enumerator = default(TEnumerator);
                _canReuse = true;
                value = default(TElement);
                return false;
            }
        }

        private readonly CommonEnumerator _commonEnumerator;

        public Enumerable(CommonEnumerator commonEnumerator)
        {
            _commonEnumerator = commonEnumerator;
        }

        public CommonEnumerator Start
        {
            get { return _commonEnumerator.GetEnumeratorForConsumption(); }
        }

        public bool TryGetNext(ref CommonEnumerator enumerator, out TElement value)
        {
            return enumerator.TryGetNext(out value);
        }
    }
}
