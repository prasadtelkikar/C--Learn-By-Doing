using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ReverseListInPairs_1
    {
        Node head;
        public ReverseListInPairs_1()
        {
            head = null;
        }

        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);
            Node currentNode = head;

            if(currentNode == null)
            {
                head = newNode;
                return;
            }
            while (currentNode.next != null)
                currentNode = currentNode.next;

            currentNode.next = newNode;
        }

        public void Display()
        {
            if(head == null)
            {
                Console.WriteLine("Error: Empty linked list");
                return;
            }
            for (Node currentNode = head; currentNode != null; currentNode = currentNode.next)
                Console.Write(currentNode.data + "-> ");

            Console.WriteLine("null");
        }

        private Node ReverseInPair(Node head)
        {
            Node temp1 = null, temp2 = null;
            Node currentNode = head;

            while(currentNode!= null && currentNode.next != null)
            {
                if (temp1 != null)
                    temp1.next.next = currentNode.next;

                temp1 = currentNode.next;
                currentNode.next = temp1.next;
                temp1.next = currentNode;

                if (temp2 == null)
                    temp2 = temp1;
                currentNode = currentNode.next;
            }
            return temp2;
        }
        public static void Main(string[] args)
        {
            ReverseListInPairs_1 reversePair = new ReverseListInPairs_1();
            reversePair.InsertAtEnd(1);
            reversePair.InsertAtEnd(2);
            reversePair.InsertAtEnd(3);
            reversePair.InsertAtEnd(4);
            reversePair.InsertAtEnd(5);
            reversePair.InsertAtEnd(6);

            reversePair.Display();
            Console.WriteLine("----Display list in pair reverse order----");
            reversePair.head = reversePair.ReverseInPair(reversePair.head);

            reversePair.Display();
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
