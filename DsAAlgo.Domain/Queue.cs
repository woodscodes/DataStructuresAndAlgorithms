﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.Domain
{
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _list = new LinkedList<T>();
        public int Count { get { return _list.Count;  } }

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
