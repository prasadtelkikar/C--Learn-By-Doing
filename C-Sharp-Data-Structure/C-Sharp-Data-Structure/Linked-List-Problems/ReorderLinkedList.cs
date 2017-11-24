using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Problem - 54 : Reorder A1, An, A2, An-2,... */
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
            Node fastNode = head;

            Node slowNode = head;

            if(currentNode == null)
            {
                return currentNode;
            }

            while(currentNode!= null && currentNode.next != null)
            {
                currentNode = currentNode.next.next;
                slowNode = slowNode.next;
            }

            Node reverseList = ReverseList(slowNode.next);
            currentNode = new Node(0);

            //TODO: Error: Last element is going into loop, so loop is going into infinity
            while(fastNode != null || reverseList != null)
            {
                if(fastNode != null)
                {
                    currentNode.next = fastNode;
                    currentNode = currentNode.next;
                    fastNode = fastNode.next;
                }
                if(reverseList != null)
                {
                    currentNode.next = reverseList;
                    currentNode = currentNode.next;
                    reverseList = reverseList.next;
                }
            }
            currentNode = currentNode.next;
            return currentNode;
        }

        private Node ReverseList(Node slowNode)
        {
            Node currentNode = slowNode;
            Node previousNode = null;
            Node nextNode = null;

            while(currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            return previousNode;
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
            Node result = reorderList.ReorderList();
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



