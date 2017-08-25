using System;
using System.Collections.Generic;
/* Store node one by one into a list and check node is already present in that list or not
 * if present then list is cyclic otherwise no
 */
namespace LinkedList.Exercise
    {
    public class CyclicListDictionary
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

            bool isCyclic = CheckListCyclic(linkedList.First, size);
            Console.WriteLine(isCyclic ? "Yes cyclic" : "Not cyclic");
            }

        private static bool CheckListCyclic (LinkedListNode<int> first, int size = 999)
            {
            List<LinkedListNode<int>> list = new List<LinkedListNode<int>>(size);
            do
                {
                if ( list.Contains(first) )
                    return true;

                list.Add(first);
                first = first.Next;
                } while ( first != null );
            return false;
            }
        }
    }
