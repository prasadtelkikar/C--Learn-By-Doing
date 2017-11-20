﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ArrangeEvenOdd
    {
        Node head;
        int length;

        public ArrangeEvenOdd()
        {
            head = null;
            length = 0;
        }

        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);
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

        public void Display()
        {
            Node currentNode = head;

            if(currentNode == null)
            {
                Console.WriteLine("Error: List is empty");
                return;
            }
            do
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            } while (currentNode != null);
            Console.WriteLine("null");
        }

        public void ArrangeOddEven()
        {

        }

        public static void Main(string[] args)
        {
            ArrangeEvenOdd arrangeEO = new ArrangeEvenOdd();
            arrangeEO.InsertAtEnd(1);
            arrangeEO.InsertAtEnd(2);
            arrangeEO.InsertAtEnd(3);
            arrangeEO.InsertAtEnd(4);
            arrangeEO.InsertAtEnd(5);
            arrangeEO.InsertAtEnd(6);
            arrangeEO.InsertAtEnd(7);
            arrangeEO.InsertAtEnd(8);

            arrangeEO.Display();
            arrangeEO.ArrangeOddEven();
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
