using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class Josephus_Circle
    {
        Node head;
        int length;
        public Josephus_Circle()
        {
            head = null;
            length = 0;
        }

        public void InsertAtFirst(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                length++;
            }

            newNode.next = head;
            head = newNode;
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

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        public static void Main(string[] args)
        {
            Josephus_Circle jcircle = new Josephus_Circle();
            jcircle.InsertAtFirst(*);
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
