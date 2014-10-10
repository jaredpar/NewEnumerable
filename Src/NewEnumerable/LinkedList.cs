using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEnumerable
{
    public sealed class LinkedList<T> : IEnumerable<T, LinkedList<T>.Node>
    {
        public sealed class Node
        {
            internal T Value;
            internal Node Next;
        }

        private Node _head;

        public LinkedList()
        {

        }

        public void Add(T value)
        {
            var node = new Node() { Value = value };
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }
        }

        public Node Start
        {
            get { return _head; }
        }

        public bool TryGetNext(ref Node node, out T value)
        {
            if (node != null)
            {
                value = node.Value;
                node = node.Next;
                return true;
            }

            value = default(T);
            return false;
        }

        public static explicit operator Enumerable<T>(LinkedList<T> list)
        {
            return new Enumerable<T>(new Enumerable<T>.CommonEnumeratorImpl<Node>(list));
        }
    }


}
