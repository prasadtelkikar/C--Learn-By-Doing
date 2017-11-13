using System;

namespace C_Sharp_Data_Structure.Linked_List
{
    public class CircularLinkedList
    {
        Node head = null;
        int length = 0;

        private Node InitializeNewNode(int value)
        {
            return new Node(value);
        }

        public void InsertAtFirst(int value)
        {
            Node newNode = InitializeNewNode(value);

            if (head == null)
            {
                head = newNode;
                head.next = head;
            }
            else
            {
                Node tailNode = head;

                while (tailNode.next != head)
                {
                    tailNode = tailNode.next;
                };

                newNode.next = head;
                tailNode.next = newNode;
                head = newNode;
            }
            length++;
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = InitializeNewNode(value);
            if (head == null)
            {
                head = newNode;
                head.next = newNode;
            }
            else
            {
                Node tailNode = head;
                while (tailNode.next != head)
                    tailNode = tailNode.next;

                tailNode.next = newNode;
                newNode.next = head;
            }
            length++;
        }

        private void DeleteFromFront()
        {
            Node currentNode = head;
            if (head == null)
                return;
            if (currentNode.next == currentNode)
            {
                head = null;
            }
            else
            {
                while (currentNode.next != head)
                    currentNode = currentNode.next;

                Node firstNode = head;
                Node secNode = head.next;
                currentNode.next = secNode;
                head = secNode;
                firstNode = null;
            }
            length--;
        }

        private void DeleteFromEnd()
        {
            Node currentNode = head;
            Node prevNode = head;

            if (head == null)
                return;

            if (head.next == head)
            {
                head = null;
                length--;
                return;
            }

            while (currentNode.next != head)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
            }

            prevNode.next = head;
            currentNode = null;
            length--;
        }

        public void Display()
        {
            if (head == null)
                Console.WriteLine("List is empty");
            else
            {
                Node currentNode = head;
                do
                {
                    Console.Write(currentNode.data + "-> ");
                    currentNode = currentNode.next;
                } while (currentNode != head);
                Console.Write("null");
            }
        }

        public static void Main(string[] args)
        {
            CircularLinkedList objCLL = new CircularLinkedList();
            objCLL.InsertAtFirst(3);
            objCLL.InsertAtFirst(2);
            objCLL.InsertAtFirst(1);
            objCLL.InsertAtEnd(4);
            objCLL.InsertAtEnd(5);
            objCLL.InsertAtEnd(6);

            objCLL.DeleteFromFront();
            objCLL.DeleteFromEnd();

            objCLL.Display();

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