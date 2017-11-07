using System;
using System.Collections.Generic;
/*
 * Problem solved by FLOYD. It uses two pointers moving at different speeds to walk the linked list.
 * Once they inter the loop they are expected to meet, which denotes that there is a loop
 */
namespace LinkedList.Exercise
    {
    public class CyclicListFloyd
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

            bool isCyclic = CheckListCyclic(linkedList);
            Console.WriteLine(isCyclic ? "Yes cyclic" : "Not cyclic");
            Console.ReadKey();
            }

        private static bool CheckListCyclic (LinkedList<int> linkedList)
            {
            LinkedListNode<int> fastNode = linkedList.First;
            LinkedListNode<int> slowNode = linkedList.First;
            while ( slowNode != null && fastNode != null && fastNode.Next != null )
                {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;

                if ( slowNode == fastNode )
                    return true;
                }
            return false;
            }
        }
    }
