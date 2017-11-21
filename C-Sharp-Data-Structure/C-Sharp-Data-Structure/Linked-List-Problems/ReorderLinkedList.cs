using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ReorderLinkedList
    {
        Node head;
        int length;
        public ReorderLinkedList()
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
                Console.WriteLine("Error: Linked list is empty");
                return;
            }
            while(currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        //Order into A1, An, A2, An-2,...
        private Node ReorderList()
        {
            Node currentNode = head;

            if(currentNode == null)
            {
                return currentNode;
            }
        }

        public static void Main(string[] args)
        {
            ReorderLinkedList reorderList = new ReorderLinkedList();
            reorderList.InsertAtEnd(1);
            reorderList.InsertAtEnd(2);
            reorderList.InsertAtEnd(3);
            reorderList.InsertAtEnd(4);
            reorderList.InsertAtEnd(5);

            reorderList.Display();
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



