using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindMiddleOfLinkedList
    {
        Node head;
        int length;

        public FindMiddleOfLinkedList()
        {
            length = 0;
            head = null;
        }

        private Node InitializeNode(int value)
        {
            return new Node(value);
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = InitializeNode(value);
            Node currentNode = head;

            if (head == null)
            {
                head = newNode;
                length++;
                return;
            }

            while(currentNode.next != null)
                currentNode = currentNode.next;

            currentNode.next = newNode;
            length++;
        }

        public void Display()
        {
            Node currentNode = head;

            if (currentNode == null)
                Console.WriteLine("Error: List is empty");

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
            Console.WriteLine();

            if (currentNode == null)
                Console.WriteLine("Error: List is empty");

            int ceil = length / 2;
            while (ceil-- > 0)
                currentNode = currentNode.next;

            Console.WriteLine("Middle of Linked list :" + currentNode.data);
        }

        public static void Main(string[] args)
        {
            FindMiddleOfLinkedList objFindMiddle = new FindMiddleOfLinkedList();
            objFindMiddle.InsertAtEnd(1);
            objFindMiddle.InsertAtEnd(2);
            objFindMiddle.InsertAtEnd(3);
            objFindMiddle.InsertAtEnd(4);
            objFindMiddle.InsertAtEnd(5);
            //objFindMiddle.InsertAtEnd(6);

            objFindMiddle.Display();
            objFindMiddle.FindMiddle();
            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node next;

            public  Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        }
    }
}
