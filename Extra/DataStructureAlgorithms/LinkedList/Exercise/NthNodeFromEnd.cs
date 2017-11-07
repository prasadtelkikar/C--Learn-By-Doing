using System;
using System.Collections.Generic;

namespace LinkedList.Exercise
    {
    public class NthNodeFromEnd
        {
        public static void Main (string[] args)
            {
            LinkedList<int> linkedList = new LinkedList<int>();
            char ch = ' ';
            do
                {
                Console.WriteLine("Enter element: ");
                int element = Convert.ToInt32(Console.ReadLine());
                linkedList.AddLast(element);

                Console.WriteLine("Do you want to continue: ");
                ch = Convert.ToChar(Console.ReadLine());
                } while ( ch == 'Y' || ch == 'y' );

            Console.WriteLine("Enter nth node from the end of list");
            int index = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            LinkedListNode<int> node = linkedList.First;
            
            //Find length of node.
            while ( node != null )
                {
                count++;
                node = node.Next;
                }
            //Nth from end = length of list - index(input from list);
            if ( index > count )
                {
                Console.WriteLine("Fewer numbers of nodes in the list");
                return;
                }
            else
                {
                int nEnd = count - index;
                LinkedListNode<int> firstNode = linkedList.First;
                while ( nEnd-- > 0 )
                    {
                    firstNode = firstNode.Next;
                    }
                Console.WriteLine($"Found at location {index} from last and value is {firstNode.Value}");
                }
            Console.ReadKey();
            }
        }
    }
