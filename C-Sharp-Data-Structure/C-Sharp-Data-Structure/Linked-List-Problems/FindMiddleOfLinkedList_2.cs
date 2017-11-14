using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindMiddleOfLinkedList_2
    {
        Node head;
        int length;
        public FindMiddleOfLinkedList_2()
        {
            head = null;
            length = 0;
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = new Node(value);
            Node currentNode = head;

            if(currentNode == null)
            {
                head = currentNode;
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
            while(currentNode!= null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
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
