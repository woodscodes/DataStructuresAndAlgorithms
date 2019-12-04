using DsAAlgo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> first = new Node<int>(3);
            Node<int> middle = new Node<int>(5);
            Node<int> last = new Node<int>(6);

            /*
            first.Next = middle;
            middle.Next = last;
            */

            //NodeChain.EnumerateNodes(first);

            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();

            /* AddToFrontTesting
            myLinkedList.AddToFront(first);
            myLinkedList.AddToFront(middle);
            myLinkedList.AddToFront(last);
            */

            myLinkedList.AddToBack(first);
            myLinkedList.AddToBack(middle);
            myLinkedList.AddToBack(last);

            /*
            myLinkedList.RemoveFromFront();
            myLinkedList.RemoveFromFront();
            */

            myLinkedList.Contains(5);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
