using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindMiddleOfLinkedList_1
    {
        Node head;
        int length;

        public FindMiddleOfLinkedList_1()
        {
            head = null;
            length = 0;
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = new Node(value);
            Node currentNode = head;

            if (head == null)
            {
                head = newNode;
                length++;
                return;
            }

            while (currentNode.next != null)
                currentNode = currentNode.next;

            currentNode.next = newNode;
            length++;
        }

        public void Display()
        {
            Node currentNode = head;
            if (currentNode == null)
            {
                Console.WriteLine("Error: Empty linked list");
                return;
            }
            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        public void FindMiddle()
        {
            Node currentNode = head;
            Dictionary<int, Node> dictionary = new Dictionary<int, Node>();
            int index = 1;
            if (currentNode == null)
            {
                Console.WriteLine("Error: Empty linked list");
                return;
            }

            while (currentNode != null)
            {
                dictionary.Add(index, currentNode);
                currentNode = currentNode.next;
                index++;
            }


            int middleIndex = index / 2;
            Console.WriteLine("Middle of linked list: " + dictionary[middleIndex].data);
        }

        public static void Main(string[] args)
        {
            FindMiddleOfLinkedList_1 objFind = new FindMiddleOfLinkedList_1();
            objFind.InsertAtEnd(1);
            objFind.InsertAtEnd(2);
            objFind.InsertAtEnd(3);
            objFind.InsertAtEnd(4);
            objFind.InsertAtEnd(5);
            objFind.InsertAtEnd(6);
            objFind.InsertAtEnd(7);

            objFind.Display();

            objFind.FindMiddle();
            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        }
    }
}
