using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindModularNodeFromBegin
    {
        Node head;
        public FindModularNodeFromBegin()
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

        private void FindNodeFromBegin(int index)
        {
            int i = 0;
            if(index <= 0)
            {
                Console.WriteLine("Error: Wrong input");
            }

            for (Node currentNode = head; currentNode != null; currentNode = currentNode.next)
            {
                if (i % index == 0)
                {
                    //For returning only single node return from here.
                    Console.WriteLine("Element at location " + i + " is =" + currentNode.data);
                }
                i++;
            }
        }

        public static void Main(string[] args)
        {
            FindModularNodeFromBegin findModular = new FindModularNodeFromBegin();
            findModular.InsertAtEnd(1);
            findModular.InsertAtEnd(2);
            findModular.InsertAtEnd(3);
            findModular.InsertAtEnd(4);
            findModular.InsertAtEnd(5);
            findModular.InsertAtEnd(6);
            findModular.InsertAtEnd(7);
            findModular.InsertAtEnd(8);
            findModular.InsertAtEnd(9);
            findModular.InsertAtEnd(10);
            findModular.InsertAtEnd(11);
            findModular.InsertAtEnd(12);

            findModular.Display();
            int k = 3;
            findModular.FindNodeFromBegin(k);
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
