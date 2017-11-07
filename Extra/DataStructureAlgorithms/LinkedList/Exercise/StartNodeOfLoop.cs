using System;
using System.Collections.Generic;
/* Problem 11: Starting point of loop
 * Here when slow pointer and fast pointer meets each other then assign fast pointer as a head 
 * and move both the pointers by one step. finally both pointers will meet at starting point of
 * loop
 */
namespace LinkedList.Exercise
    {
    public class StartNodeOfLoop
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

            LinkedListNode<int> firstInLoop = FindBeginOfLoop(linkedList.First);
            if(firstInLoop != null)
                Console.WriteLine("First node in loop : "+firstInLoop.Value);
            else
                Console.WriteLine("No loop found");
                Console.ReadKey();
            }

        private static LinkedListNode<int> FindBeginOfLoop (LinkedListNode<int> head)
            {
            bool isLoopExist = false;
            LinkedListNode<int> slowNode = head;
            LinkedListNode<int> fastNode = head;

            while ( slowNode != null && fastNode != null && fastNode.Next != null )
                {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
                if ( slowNode == fastNode )
                    {
                    isLoopExist = true;
                    break;
                    }
                }
            if ( isLoopExist )
                {
                slowNode = head;
                while ( slowNode != fastNode )
                    {
                    slowNode = slowNode.Next;
                    fastNode = fastNode.Next;
                    }
                return slowNode;
                }
            return null;
            }
        }
    }
