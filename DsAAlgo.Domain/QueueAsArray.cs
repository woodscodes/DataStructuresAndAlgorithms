using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.Domain
{
    public class QueueAsArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size = 0;
        private int _head = 0;
        private int _tail = -1;

        public int Count { get { return _size; } }

        public void Enqueue(T item)
        {
            if (_items.Length == _size)
            {
                int newLength = (_size == 0) ? 4 : _size * 2;

                T[] newArray = new T[newLength];

                if(_size > 0)
                {
                    int targetIndex = 0;

                    if(_tail < _head)
                    {
                        // copying from where the head is ... copy _items[head] .. _items[endOfCurrentArray] -> newArray[0] .. newArray[N]
                        for (int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        // wrapping from 0 copy _items[0].. _items[tail] -> newArray[N+1]
                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // head is greater than tail
                        // copy the _items[_head] ... _items[tail] -> newArray[0] ... new Array[N]
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }

                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = newArray;
                
            }

            if(_tail == _items.Length -1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _items[_head];

            if(_head == _items.Length -1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;

            return value;
        }

        public T Peek()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[_head];
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            if(_size > 0)
            {
                if(_tail < _head)
                {
                    // head - endOfArray
                    for (int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }

                    // 0 - tail
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    // head - tail
                    for (int index = _head; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
