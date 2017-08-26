using System;
using System.Collections.Generic;
/* Problem 14 : Length of cyclic linked list
 * when slow and fast pointer meets each other then move one pointer by one and count 
 * the steps and check escape condition with other pointer
 */
namespace LinkedList.Exercise
    {
    public class LengthOfCycle
        {
        public static void Main (string[] args)
            {
            Console.WriteLine("Enter size of list");
            int size = Convert.ToInt32(Console.ReadLine());
            LinkedList<int> linkedList = new LinkedList<int>();
            for ( int i = 0; i < size; i++ )
                {
                int element = Convert.ToInt32(Console.ReadLine());
                linkedList.AddLast(element); //Not able to create a circular linkedlist
                }
            int lengthOfCycle = FindCycleLength(linkedList.First);
            Console.WriteLine(lengthOfCycle == 0 ? "Not Cyclic list" : $"Cyclic Length: {lengthOfCycle} ");
            Console.ReadKey();
            }

        private static int FindCycleLength (LinkedListNode<int> head)
            {
            LinkedListNode<int> slowNode = head;
            LinkedListNode<int> fastNode = head;
            bool isCycleExist = false;
            int count = 0;
            while ( slowNode != null && fastNode != null && fastNode.Next != null )
                {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
                if ( slowNode == fastNode )
                    {
                    isCycleExist = true;
                    break;
                    }
                }
            while ( isCycleExist )
                {
                fastNode = fastNode.Next;
                if ( fastNode == slowNode )
                    {
                    count++;
                    fastNode = fastNode.Next;
                    }
                }
            return count;
            }
        }
    }
