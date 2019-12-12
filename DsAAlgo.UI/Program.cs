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

            var stc = new PostFixCalculatorUsingAStack();

            string[] arg = new string[] { "5", "6", "7", "*", "+", "1", "-" };
            stc.GetPostfixedAnswer(arg);

            var stcL = new DsAAlgo.Domain.Stack<int>();

            stcL.Push(1);
            stcL.Push(2);
            stcL.Push(3);

            foreach (var item in stcL)
            {
                Console.WriteLine(item);
            }

            stcL.Pop();
            var bleh = stcL.Peek();

            Console.WriteLine(bleh);

            var stcA = new StackAsArray<string>();

            stcA.Push("Hi");
            stcA.Push("there");
            stcA.Push("mate");

            foreach (var item in stcA)
            {
                Console.WriteLine(item);
            }

            var blerr = stcA.Pop();
            Console.WriteLine(blerr);
            var bleh2 = stcA.Peek();
            Console.WriteLine(bleh2);

            var q = new DsAAlgo.Domain.Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            q.Dequeue();

            var bleh3 = q.Peek();

            Console.WriteLine(bleh3);

            var qA = new QueueAsArray<string>();

            qA.Enqueue("Oright");
            qA.Enqueue("There");
            qA.Enqueue("mate");

            foreach (var item in qA)
            {
                Console.WriteLine(item);
            }

            var bleh5 = qA.Dequeue();
            Console.WriteLine(bleh5);
            var bleh4 = qA.Peek();
            Console.WriteLine(bleh4);

        }
    }
}
