using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.Domain
{
    public class StackAsArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size;

        public int Count { get { return _size; } }
        
        public void Push(T item)
        {
            if(_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;

                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            _items[_size] = item;
            _size++;
        }


        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            _size--;
            return _items[_size];
        }

        public T Peek()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[_size - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
