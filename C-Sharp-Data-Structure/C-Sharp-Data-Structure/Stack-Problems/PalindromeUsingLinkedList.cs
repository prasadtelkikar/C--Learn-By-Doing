using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class PalindromeUsingLinkedList
    {
        Node head;
        int length;

        public PalindromeUsingLinkedList()
        {
            length = 0;
        }

        private Node CreateNode(int data)
        {
            return new Node(data);
        }

        public bool IsEmptyList()
        {
            return (head == null);
        }

        public void AddToLast(int data)
        {
            Node newNode = CreateNode(data);
            if (IsEmptyList())
                head = newNode;
            else
            {
                Node temp = head;
                while (temp.nextNode != null)
                    temp = temp.nextNode;

                temp.nextNode = newNode;
            }
        }

        public void AddToFirst(int data)
        {
            Node newNode = CreateNode(data);
            if (IsEmptyList())
                head = newNode;
            else
            {
                Node temp = head;
                newNode.nextNode = head;
            }
        }

        public bool IsPalindrome()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("Empty linked list");
                return false;
            }
            Node fastNode = head;
            Node slowNode = head;

            while(fastNode.nextNode != null && fastNode.nextNode.nextNode != null)
            {
                fastNode = fastNode.nextNode.nextNode;
                slowNode = slowNode.nextNode;
            }

            Console.WriteLine("Middle node: " + slowNode.data);
            return true;
        }

        public void print()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("Empty list");
                return;
            }
            Node temp = head;
            do
            {
                Console.Write(temp.data + "-> ");
                temp = temp.nextNode;

            } while (temp.nextNode != null);
            Console.WriteLine(temp.data);
        }
        public static void Main(string[] args)
        {
            PalindromeUsingLinkedList linkedList = new PalindromeUsingLinkedList();
            linkedList.AddToLast(1);
            linkedList.AddToLast(2);
            linkedList.AddToLast(3);
            linkedList.AddToLast(4);
            linkedList.AddToLast(5);
            //linkedList.AddToLast(6);

            linkedList.print();

            bool b = linkedList.IsPalindrome();
            //Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node nextNode;
            public Node(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }
    }
}
