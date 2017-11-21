using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindModularFromEnd
    {
        Node head;
        public FindModularFromEnd()
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
                return;
            }
            while (currentNode.next != null)
                currentNode = currentNode.next;
            currentNode.next = newNode;
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
        //Returning single element from end which satisfy i%k == 0 condition
        private Node FindModuloFromEnd(int k)
        {
            Node currentNode = head;
            if (currentNode == null)
                return currentNode;

            if (k <= 0)
                return null;

            for (int i = 0; i < k; i++)
                currentNode = currentNode.next;

            Node moduloFromEnd = head;
            while (currentNode != null)
            {
                currentNode = currentNode.next;
                moduloFromEnd = moduloFromEnd.next;
            }
            return moduloFromEnd;
        }

        public static void Main(string[] args)
        {
            FindModularFromEnd findModulo = new FindModularFromEnd();
            findModulo.InsertAtEnd(1);
            findModulo.InsertAtEnd(2);
            findModulo.InsertAtEnd(3);
            findModulo.InsertAtEnd(4);
            findModulo.InsertAtEnd(5);
            findModulo.InsertAtEnd(6);
            findModulo.InsertAtEnd(7);
            findModulo.InsertAtEnd(8);
            findModulo.InsertAtEnd(9);
            findModulo.InsertAtEnd(10);
            findModulo.InsertAtEnd(11);
            findModulo.InsertAtEnd(12);

            findModulo.Display();
            Node result = findModulo.FindModuloFromEnd(3);
            if (result == null)
                Console.WriteLine("Unknown result");
            else
                Console.WriteLine("Modulo from end = " + result.data);

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
