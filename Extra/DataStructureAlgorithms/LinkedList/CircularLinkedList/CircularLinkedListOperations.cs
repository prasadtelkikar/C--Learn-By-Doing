using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.CircularLinkedList
    {
    public class CircularLinkedListOperations
        {
        public static void Main (string[] args)
            {
            CircularLinkedList<int> circularLinkedList = new CircularLinkedList<int>();
            Console.WriteLine("Enter number of element: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());

            CreateCircularLinkedList(circularLinkedList, numberOfElements);
            DisplayCircularLinkedList(circularLinkedList);

            Console.WriteLine("Enter number to be added at last:");
            numberOfElements = Convert.ToInt32(Console.ReadLine());
            InsertNodeAtLast(circularLinkedList, numberOfElements);
            DisplayCircularLinkedList(circularLinkedList);

            Console.WriteLine("Delete last node:");
            DeleteLastNode(circularLinkedList);
            DisplayCircularLinkedList(circularLinkedList);
            
            Console.WriteLine("Delete first node:");
            DeleteFirstNode(circularLinkedList);
            DisplayCircularLinkedList(circularLinkedList);
            Console.ReadLine();
            }

        private static void DeleteFirstNode(CircularLinkedList<int> circularLinkedList)
        {
            circularLinkedList.RemoveFirst();
        }

        private static void DeleteLastNode(CircularLinkedList<int> circularLinkedList)
        {
            circularLinkedList.RemoveLast();
        }

        private static void InsertNodeAtLast(CircularLinkedList<int> circularLinkedList, int numberOfElements)
        {
            circularLinkedList.AddFirst(numberOfElements);
        }

        private static void CreateCircularLinkedList (CircularLinkedList<int> circularLinkedList, int numberOfElements)
            {
            for ( int i = 0; i < numberOfElements; i++ )
                {
                Console.WriteLine("Enter element: ");
                int element = Convert.ToInt32(Console.ReadLine());
                circularLinkedList.AddLast(element);
                }
            }

        private static void DisplayCircularLinkedList (CircularLinkedList<int> circularLinkedList)
            {
            foreach ( int element in circularLinkedList )
                {
                Console.WriteLine(element);
                }
            }
        }
    }
