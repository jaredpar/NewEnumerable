using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    public sealed class ArrayList<T> : IEnumerable<T, int>
    {
        public const int DefaultSize = 4;

        private T[] _array;
        private int _count;

        public T this[int index]
        {
            get
            {
                Contract.Requires(index < _count);
                return _array[index];
            }
            set
            {
                Contract.Requires(index < _count);
                _array[index] = value;
            }
        }

        public int Count
        {
            get { return _count; }
        }

        public ArrayList(int count = DefaultSize)
        {
            _array = new T[count]; 
        }

        public void Add(T value)
        {
            CheckSize(_count + 1);
            _array[_count] = value;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        private void CheckSize(int newCount)
        {
            if (newCount >= _array.Length)
            {
                var temp = new T[newCount * 2];
                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _array[i];
                }

                _array = temp;
            }
        }
        public int Start
        {
            get { return 0; }
        }

        public bool TryGetNext(ref int current, out T value)
        {
            if (current >= _count)
            {
                value = default(T);
                return false;
            }

            value = _array[current];
            current++;
            return true;
        }
    }
}
