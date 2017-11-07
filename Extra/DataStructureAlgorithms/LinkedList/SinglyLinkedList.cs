using System;
using System.Collections.Generic;
/* Handson with C# singly linked list */
namespace LinkedList
    {
    public class SinglyLinkedList
        {
        public static void Main (string[] args)
            {
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine("Enter number of elements in linked list: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            
            //Create operations
            //1 -> 2 -> 3 -> NULL
            CreateList(linkedList,numberOfElements);
            DisplayLinkedList(linkedList);
            //Create new linked list node.
            LinkedListNode<int> firstNode = CreateNewLinkedListNode();
            //4 -> 1 -> 2 -> 3 -> NULL
            InsertNodeAtBeginning(linkedList, firstNode);
            DisplayLinkedList(linkedList);

            Console.Write("Enter the position for new node (indexing starts from 0): ");
            int position = Convert.ToInt32(Console.ReadLine());
            InsertNodeAtPosition(linkedList, position);
            DisplayLinkedList(linkedList);

            //Delete operations
            //Delete first element
            DeleteFirstElement(linkedList);
            DisplayLinkedList(linkedList);
            //Delete last element
            DeleteLastElement(linkedList);
            DisplayLinkedList(linkedList);
            //Delete intermediate node
            Console.WriteLine("Enter position of node to delete (indexing starts from 0): ");
            position = Convert.ToInt32(Console.ReadLine());
            DeleteIntermediateNode(linkedList, position);
            DisplayLinkedList(linkedList);

            Console.ReadKey();
            }

        #region Create new linked list
        /// <summary>
        /// Add new node to the end of list.
        /// </summary>
        /// <param name="linkedList">instance of linked list</param>
        /// <param name="numberOfElements">Number of nodes in a list</param>
        private static void CreateList (LinkedList<int> linkedList, int numberOfElements)
            {
            while ( numberOfElements-- > 0 )
                {
                Console.Write("Enter a number: ");
                int value = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                linkedList.AddLast(value);
                }
            }
        #endregion

        #region Create new node
        /// <summary>
        /// To Create new linked list node
        /// </summary>
        /// <returns>Instance of Linked list node</returns>
        private static LinkedListNode<int> CreateNewLinkedListNode ()
            {
            Console.Write("Enter value for new node: ");
            int value = Convert.ToInt32(Console.ReadLine());
            return new LinkedListNode<int>(value);
            }
        #endregion

        #region Insert
        /// <summary>
        /// Add new node at the beginning of the list
        /// </summary>
        /// <param name="linkedList">instance of linked list</param>
        /// <param name="value">New linked list node</param>
        private static void InsertNodeAtBeginning (LinkedList<int> linkedList, LinkedListNode<int> value)
            {
            linkedList.AddFirst(value);
            }

        /// <summary>
        /// Insert new node at the given position
        /// </summary>
        /// <param name="linkedList"></param>
        /// <param name="position"></param>
        private static void InsertNodeAtPosition (LinkedList<int> linkedList, int position)
            {
            LinkedList<int> temp = linkedList;
            LinkedListNode<int> newNode = CreateNewLinkedListNode();
            if ( temp == null )
                {
                Console.WriteLine("Empty linked list");
                return;
                }
            else
                {
                LinkedListNode<int> head = linkedList.First;
                while ( head != null && position-- > 0 )
                    head = head.Next;

                if ( head != null )
                    linkedList.AddBefore(head, newNode);
                else
                    Console.WriteLine("Wrong input");
                }
            }
        #endregion

        #region Delete
        /// <summary>
        /// Delete first node from list
        /// </summary>
        /// <param name="linkedList">Instance of linked list</param>
        private static void DeleteFirstElement (LinkedList<int> linkedList)
            {
            linkedList.RemoveFirst();
            }

        /// <summary>
        /// Delete a node from given position
        /// </summary>
        /// <param name="linkedList">Linked list</param>
        /// <param name="position">index of element to delete</param>
        private static void DeleteIntermediateNode (LinkedList<int> linkedList, int position)
            {
            LinkedListNode<int> head = linkedList.First;
            while ( head != null && position-- > 0 )
                head = head.Next;
            if ( head != null )
                linkedList.Remove(head);
            else
                Console.WriteLine("Wrong inputs");
            }

        /// <summary>
        /// Delete last node from list
        /// </summary>
        /// <param name="linkedList">Instance of linked list</param>
        private static void DeleteLastElement (LinkedList<int> linkedList)
            {
            linkedList.RemoveLast();
            }
        #endregion

        #region Display List
        /// <summary>
        /// Traversal through linked list and print the elements of linked list
        /// </summary>
        /// <param name="linkedList">Instance of linked list</param>
        private static void DisplayLinkedList (LinkedList<int> linkedList)
            {
            Console.WriteLine("Display LinkedList: ");
            foreach ( int element in linkedList )
                Console.WriteLine(element);
            }
        #endregion
        }
    }
