using System.Collections;
using System.Collections.Generic;

namespace ShapesGraphics.List
{
    public class CustomList<T> : IEnumerable<T> where T : class
    {
        private Node<T> _head = null;

        public CustomList()
        {
        }

        public CustomList(List<T> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public CustomList(CustomList<T> list)
        {
            _head = list._head;
        }

        public void Add(T value)
        {
            var node = new Node<T> { Value = value };

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

        public void Remove(T value)
        {
            if (_head == null)
            {
                return;
            }

            if (_head.Value == value)
            {
                _head = _head.Next;
            }

            var current = _head;

            while (current?.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next?.Next;
                    break;
                }

                current = current.Next;
            }
        }

        public IEnumerator<T> Enumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Enumerator();
        }
    }
}
