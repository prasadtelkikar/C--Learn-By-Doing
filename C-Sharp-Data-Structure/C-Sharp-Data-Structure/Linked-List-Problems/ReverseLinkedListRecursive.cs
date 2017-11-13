using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ReverseLinkedListRecursive
    {
        Node head;

        public ReverseLinkedListRecursive()
        {
            head = null;
        }
        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = InitializeNode(value);
            Node currentNode = head;

            if (currentNode == null)
            {
                head = newNode;
                return;
            }   

            while (currentNode.next != null)
                currentNode = currentNode.next;

            currentNode.next = newNode;
        }

        //Need to read upon it thoroughly
        private Node RecursiveReverse(Node currentNode)
        {
            //Check list is empty or not || check current node is tail or not
            if (currentNode == null || currentNode.next == null)
                return currentNode;
            
            //Recursive: Travel till end of list
            Node nextNode = RecursiveReverse(currentNode.next);
            
            //TODO: Not understood perfectly
            currentNode.next.next = currentNode;
            currentNode.next = null;

            return nextNode;
            
        }
        public void Display()
        {
            Node currentNode = head;
            if (currentNode == null)
                return;
            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.Write("null");
        }

        public static void Main(string[] args)
        {
            ReverseLinkedListRecursive objRevLinkedList = new ReverseLinkedListRecursive();
            objRevLinkedList.InsertAtEnd(0);
            objRevLinkedList.InsertAtEnd(1);
            objRevLinkedList.InsertAtEnd(2);
            objRevLinkedList.InsertAtEnd(3);
            objRevLinkedList.InsertAtEnd(4);
            objRevLinkedList.InsertAtEnd(5);
            Console.WriteLine("-----------Display before reverse-------------");
            objRevLinkedList.Display();
            Console.WriteLine("\n-----------Display after reverse-------------");
            objRevLinkedList.head = objRevLinkedList.RecursiveReverse(objRevLinkedList.head);
            objRevLinkedList.Display();
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
