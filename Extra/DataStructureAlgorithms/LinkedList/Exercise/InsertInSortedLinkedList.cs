using System;
using System.Collections.Generic;
/* Problem - 15
 * Inserting node in a sorted linked list
 */
namespace LinkedList.Exercise
    {
    public class InsertInSortedLinkedList
        {
        public static void Main (string[] args)
            {
            Console.WriteLine("Enter size :");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a sorted linked list");
            LinkedList<int> linkedList = new LinkedList<int>();
            for ( int i = 0; i < size; i++ )
                {
                Console.WriteLine("Element : ");
                int element = Convert.ToInt32(Console.ReadLine());
                linkedList.AddLast(element);
                }

            Console.WriteLine("Enter node to be inserted: ");
            int value = Convert.ToInt32(Console.ReadLine());

            LinkedListNode<int> node = new LinkedListNode<int>(value);
            LinkedListNode<int> currentNode = linkedList.First;

            do
                {
                //if linked list is empty
                if ( linkedList.Count == 0 )
                    {
                    linkedList.AddLast(node);
                    break;
                    }
                //if new node value is smaller than first node value
                if ( linkedList.First.Value > node.Value )
                    {
                    linkedList.AddFirst(node);
                    break;
                    }
                //if new node value is greater than last node value
                if ( linkedList.Last.Value < node.Value )
                    {
                    linkedList.AddLast(node);
                    break;
                    }
                //Add new node inbetween the list
                if ( node.Value > currentNode.Value && node.Value < currentNode.Next.Value )
                    {
                    //node.Next = currentNode.Next;
                    //currentNode.Next = node;
                    linkedList.AddAfter(currentNode, node);
                    break;
                    }

                currentNode = currentNode.Next;
                } while ( currentNode != null && currentNode.Next != null );

            Console.WriteLine("Sorted linkedlist with newly inserted item");
            foreach ( int element in linkedList )
                {
                Console.WriteLine(element);
                }
            Console.ReadKey();
            }
        }
    }
