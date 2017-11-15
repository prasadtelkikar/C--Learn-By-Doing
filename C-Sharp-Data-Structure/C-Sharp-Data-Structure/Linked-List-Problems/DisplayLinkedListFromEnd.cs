using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class DisplayLinkedListFromEnd
    {
        Node head;
        int length;
        public DisplayLinkedListFromEnd()
        {
            head = null;
            length = 0;
        }

        public void InsertFromEnd(int value)
        {
            Node newNode = new Node(value);
            Node currentNode = head;

            if(head == null)
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

        //Function will print linked list from starting pointf
        public void Display()
        {
            Node currentNode = head;
            if (currentNode == null)
                Console.WriteLine("Error: List is empty");
            while(currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        //Function will print linked list from end
        private void DisplayReverse(Node head)
        {
            if (head == null)
                return;
            DisplayReverse(head.next);
            Console.Write(head.data + "-> ");
        }

        public static void Main(string[] args)
        {
            DisplayLinkedListFromEnd objDisFromEnd = new DisplayLinkedListFromEnd();
            objDisFromEnd.InsertFromEnd(1);
            objDisFromEnd.InsertFromEnd(2);
            objDisFromEnd.InsertFromEnd(3);
            objDisFromEnd.InsertFromEnd(4);
            objDisFromEnd.InsertFromEnd(5);

            objDisFromEnd.Display();
            Console.WriteLine("--------- Print Reverse list using recursion ----------");

            Node currentNode = objDisFromEnd.head;
            objDisFromEnd.DisplayReverse(currentNode);
            Console.WriteLine("null");
            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
        }
    }
}
