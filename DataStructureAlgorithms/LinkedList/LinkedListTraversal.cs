using System;
using System.Collections.Generic;
/* Handson with C# linked list
 */
namespace LinkedList
    {
    public class LinkedListTraversal
        {
        public static void Main (string[] args)
            {

            LinkedList<int> list = new LinkedList<int>();
            Console.WriteLine("Enter number of elements in linked list: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            //1 -> 2 -> 3 -> NULL
            while ( numberOfElements-- > 0 )
                {
                Console.WriteLine("Enter element: ");
                int element = Convert.ToInt32(Console.ReadLine());
                list.AddLast(element);
                }
            //4 -> 1 -> 2 -> 3 -> NULL
            Console.WriteLine("Enter element to add at first position: ");
            int firstElement = Convert.ToInt32(Console.ReadLine());
            list.AddFirst(firstElement);
            //4 -> 1 -> 2 -> 3 ->NULL
            Console.WriteLine("Enter element to add at end of list:");
            int lastElement = Convert.ToInt32(Console.ReadLine());
            list.AddLast(lastElement);
            
            Console.WriteLine("Enter location to add a node: ");
            int index = Convert.ToInt32(Console.ReadLine());
            LinkedListNode<int> node = list.First;
            while ( index-- > 0 )
                {
                node = node.Next;
                }
            list.AddAfter(node, 8888);

            Console.WriteLine("Elements in List");
            foreach ( int element in list )
                {
                Console.WriteLine(element);
                }

            Console.WriteLine($"Number of elements in list : {list.Count}");
            node = list.Find(8888);
            if ( node != null )
                list.Remove(node);

            //list.RemoveFirst();
            //list.RemoveLast();
            Console.WriteLine("Elements in List");
            foreach ( int element in list )
                {
                Console.WriteLine(element);
                }

            Console.WriteLine($"Number of elements in list : {list.Count}");
            Console.ReadKey();
            }
        }
    }
