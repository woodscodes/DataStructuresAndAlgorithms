using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.Domain
{
    public class MyDoublyLinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddToBack(item);
        }

        public void AddToFront(Node<T> item)
        {
            Node<T> temp = Head;

            Head = item;

            Head.Next = temp;

            if (Count == 1)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddToBack(T item)
        {
            AddToBack(new Node<T>(item));
        }

        public void AddToBack(Node<T> item)
        {
            if (Count == 0)
            {
                Head = item;
            }
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
            }

            Tail = item;
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFromFront();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void RemoveFromFront()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }
            }
        }

        public void RemoveFromBack()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }
                Count--;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
