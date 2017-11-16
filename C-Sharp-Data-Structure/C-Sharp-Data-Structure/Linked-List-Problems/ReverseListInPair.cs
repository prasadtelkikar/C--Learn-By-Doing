using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ReverseListInPair
    {
        Node head;
        int length;
        public ReverseListInPair()
        {
            head = null;
            length = 0;
        }

        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);
            Node currentNode = head;

            if(currentNode == null)
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
            if(currentNode == null)
            {
                Console.WriteLine("Error: Empty linked list");
                return;
            }
            
            while(currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        private Node PrintPairReverse(Node head)
        {
            Node temp = null;
            if (head == null || head.next == null)
                return null;
            else
            {
                temp = head.next;
                head.next = temp.next;
                temp.next = head;
                head = temp;

                head.next.next = PrintPairReverse(head.next.next);
            }
            return head;
        }

        public static void Main(string[] args)
        {
            ReverseListInPair reversePair = new ReverseListInPair();
            reversePair.InsertAtEnd(1);
            reversePair.InsertAtEnd(2);
            reversePair.InsertAtEnd(3);
            reversePair.InsertAtEnd(4);
            reversePair.InsertAtEnd(5);
            reversePair.InsertAtEnd(6);

            reversePair.Display();
            reversePair.head = reversePair.PrintPairReverse(reversePair.head);

            Console.WriteLine("-----Display results in pair reverse order -----");
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
