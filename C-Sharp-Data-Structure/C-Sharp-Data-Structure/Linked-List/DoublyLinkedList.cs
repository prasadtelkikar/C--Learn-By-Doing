using System;

namespace C_Sharp_Data_Structure.Linked_List
{
    public class DoublyLinkedList
    {
        Node head = null;
        int length;

        private Node InitializeElement(int value)
        {
            return new Node(value);
        }

        public void InsertAtFirst(int value)
        {
            Node newNode = InitializeElement(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            length++;
        }

        public void InsertAtEnd(int value)
        {
            Node newNode = InitializeElement(value);
            Node currentNode = head;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                while (currentNode.next != null)
                    currentNode = currentNode.next;

                currentNode.next = newNode;
                newNode.prev = currentNode;
            }
            length++;
        }

        public void InsertAtPosition(int value, int position)
        {
            Node newNode = InitializeElement(value);
            int index = 1;
            Node currentNode = head;
            if (position < 1)
            {
                Console.WriteLine("Error!");
                return;
            }
            if (position > length)
                position = length;

            if (position == 1)
            {
                InsertAtFirst(value);
                return;
            }
            while (currentNode != null && index < position)
            {
                currentNode = currentNode.next;
                index++;
            }

            currentNode.prev.next = newNode;
            newNode.prev = currentNode;

            currentNode.next.prev = newNode;
            newNode.next = currentNode;
            length++;
        }

        public void DeleteFromFront()
        {
            if (head == null)
                return;

            Node currentNode = head;
            Node nextNode = currentNode.next;
            nextNode.prev = null;
            head = nextNode;
            currentNode = null;
            length--;
        }

        public void DeleteFromEnd()
        {
            if (head == null)
                return;
            if (head.next == null)
            {
                head = null;
                length--;
                return;
            }

            Node currentNode = head;
            Node prevNode = head;
            while (currentNode.next != null)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            currentNode.prev = null;
            prevNode.next = null;
            currentNode = null;

            length--;
        }

        public void DeleteFromPosition(int position)
        {
            Node currentNode = head;
            Node prevNode = head;
            int index = 1;
            if (currentNode == null || position < 1)
                return;
            if (position == 1)
            {
                DeleteFromFront();
                return;
            }
            if (position > length || position == length)
            {
                DeleteFromEnd();
                return;
            }

            while (currentNode != null && index < position)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
                index++;
            }

            prevNode.next = currentNode.next;
            currentNode.next.prev = prevNode;
            currentNode = null;
            length--;
        }

        public void Display()
        {
            Node currentNode = head;

            if (head == null)
            {
                Console.WriteLine("Empty list");
                return;
            }

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.Write("null");
        }

        private int Length()
        {
            return length;
        }

        private void DisplayReverse()
        {
            Node currentNode = head;
            if (currentNode == null)
            {
                Console.WriteLine("Empty list");
                return;
            }
            while (currentNode.next != null)
                currentNode = currentNode.next;

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.prev;
            }
            Console.Write("null");
        }

        public static void Main(string[] args)
        {
            DoublyLinkedList objDll = new DoublyLinkedList();

            objDll.InsertAtFirst(3);
            objDll.InsertAtFirst(2);
            objDll.InsertAtFirst(1);

            objDll.InsertAtEnd(4);
            objDll.InsertAtEnd(5);
            objDll.InsertAtEnd(6);

            objDll.InsertAtPosition(99, 3);
            objDll.DeleteFromPosition(10);
            objDll.DeleteFromFront();
            objDll.DeleteFromFront();

            objDll.DeleteFromEnd();
            objDll.DeleteFromEnd();

            objDll.DeleteFromPosition(3);
            //objDll.DisplayReverse();
            objDll.Display();

            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node next = null;
            public Node prev = null;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }
        }
    }

}
