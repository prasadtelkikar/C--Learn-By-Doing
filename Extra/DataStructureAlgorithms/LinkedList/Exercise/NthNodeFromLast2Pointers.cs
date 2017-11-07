using System;
using System.Collections.Generic;

namespace LinkedList.Exercise
    {
    public class NthNodeFromLast2Pointers
        {
        public static void Main (string[] args)
            {
            char ch = ' '; 
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> firstNode;
            LinkedListNode<int> secondNode;
            do
                {
                Console.WriteLine("Enter element: ");
                int element = Convert.ToInt32(Console.ReadLine());
                linkedList.AddLast(element);

                Console.WriteLine("Do you want to continue: ");
                ch = Convert.ToChar(Console.ReadLine());
                } while ( ch == 'Y' || ch == 'y' );

            firstNode = linkedList.First;
            secondNode = null;

            Console.WriteLine("Enter nth node from the end of list");
            int index = Convert.ToInt32(Console.ReadLine());
            int temp = index;

            if ( index > linkedList.Count || index < 0 )
                {
                Console.WriteLine("Wrong input");
                Console.ReadKey();
                return;
                }

            while ( temp-- > 0 )
                firstNode = firstNode.Next;

            while ( firstNode != null )
                {
                if ( secondNode == null )
                    secondNode = linkedList.First;

                secondNode = secondNode.Next;
                firstNode =firstNode.Next;
                }
            Console.WriteLine($"nth node from last found = {secondNode.Value}");
            Console.ReadKey();
            }
        }
    }
