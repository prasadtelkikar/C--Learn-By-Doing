using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindNthRootElement
    {
        Node head;
        int length;
        public FindNthRootElement()
        {
            head = null;
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

        private Node FindNthRoot()
        {
            if(length == 0 || head == null)
                return null;

            //TODO: As book suggested, length is unknown; that appoach need to look into
            //Converting double to support  all lengths of list
            int squreRoot = Convert.ToInt32(Math.Sqrt(length));
            Node currentNode = head;
            for (int i = 0; i < squreRoot - 1; i++)
            {
                currentNode = currentNode.next;
            }

            //Returning instance of new node to avoid changes in main linked list
            return new Node(currentNode.data);
        }

        public void Display()
        {
            Node currentNode = head;
            if(currentNode == null)
            {
                Console.WriteLine("Error: Empty Linked List");
                return;
            }
            while(currentNode!= null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        public static void Main(string[] args)
        {
            FindNthRootElement nthRoot = new FindNthRootElement();
            nthRoot.InsertAtEnd(1);
            nthRoot.InsertAtEnd(2);
            nthRoot.InsertAtEnd(3);
            nthRoot.InsertAtEnd(4);
            nthRoot.InsertAtEnd(5);
            nthRoot.InsertAtEnd(6);
            nthRoot.InsertAtEnd(7);
            nthRoot.InsertAtEnd(8);
            nthRoot.InsertAtEnd(9);
            //nthRoot.InsertAtEnd(10);

            nthRoot.Display();
            Node result = nthRoot.FindNthRoot();
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
