using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class CheckListEvenOdd
    {
        Node head;
        int length;

        public CheckListEvenOdd()
        {
            head = null;
            length = 0;
        }

        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);
            Node currentNode = head;

            if (currentNode == null)
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
                Console.WriteLine("Error: Linked list is empty");
                return;
            }

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }

            Console.WriteLine("null");
        }

        public void IsEvenOrNot()
        {
            Node currentNode = head;

            if (currentNode == null)
            {
                Console.WriteLine("Error: Linked list is empty");
                return;
            }

            while (currentNode != null && currentNode.next != null)
                currentNode = currentNode.next.next;

            if (currentNode != null)
                Console.WriteLine("Linked list contains odd number of nodes");
            else
                Console.WriteLine("Linked list contains even number of nodes");
        }

        public static void Main(string[] args)
        {
            CheckListEvenOdd objCheckEvenOdd = new CheckListEvenOdd();
            objCheckEvenOdd.InsertAtEnd(1);
            objCheckEvenOdd.InsertAtEnd(2);
            objCheckEvenOdd.InsertAtEnd(3);
            objCheckEvenOdd.InsertAtEnd(4);
            objCheckEvenOdd.InsertAtEnd(5);
            objCheckEvenOdd.InsertAtEnd(6);
            objCheckEvenOdd.InsertAtEnd(7);

            objCheckEvenOdd.Display();
            Console.WriteLine("---- List is even or odd -----");

            objCheckEvenOdd.IsEvenOrNot();
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
