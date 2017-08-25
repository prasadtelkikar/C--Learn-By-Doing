using System;
using System.Collections.Generic;
/* Check for cyclic linked list: Brute force technique
 * Iterate through linked list using two loops and check next node 
 * "I am not able to create a proper inputs for testcases this code might contain bugs "
 */
namespace LinkedList.Exercise
    {
    public class CyclicListBruteForce
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
            bool isCyclic = CheckCyclicList(linkedList.First);
            Console.WriteLine(isCyclic? "Yes : " : "Not : " + "Cyclic list");
            }

        private static bool CheckCyclicList (LinkedListNode<int> firstNode)
        {
            LinkedListNode<int> temp = firstNode;
            do
            {
                LinkedListNode<int> rotating = temp;
                do
                    {
                    //Not sure it checks whole node or just a value it checks value then there is bug
                    if ( firstNode.Equals(rotating.Next) )  
                        {
                        return true;
                        }
                    rotating = rotating.Next;
                    } while ( rotating != null );
                firstNode = firstNode.Next;
                } while ( firstNode != null );
            return false;
            }
        }
    }
