using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class ReverseKBlockOfNodes
    {
        Node head;
        int length;
        public ReverseKBlockOfNodes()
        {
            head = null;
        }

        public void InsertAtFron(int data)
        {
            Node newNode = new Node(data);
            if(head == null)
            {
                head = newNode;
                length++;
                return;
            }
            newNode.next = head;
            head = newNode;
            length++;
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

        //Reverse block of linked list
        private Node ReverseKBlock(int k)
        {
            //Empty condition
            if(head == null)
            {
                Console.WriteLine("Error: Empty Linked list");
                return head;
            }
            //Out of bound condition check
            if(k < 0 || k > length)
            {
                Console.WriteLine("Invalid : Invalid k value");
                return null;
            }
            //No change condition
            if(k == 0 || k == 1)
                return head;

            Node currentNode = head;
            //Move current node to k places
            while(k-- > 0)
                currentNode = currentNode.next;
            //Reverse k nodes
            Node reverseHead = ReverseList(head, currentNode);

            Node temp = reverseHead;
            while (temp.next != null)
                temp = temp.next;

            //Join reverse with rest of linked list
            temp.next = currentNode;
            return reverseHead;
        }

        private Node ReverseList(Node head, Node tail)
        {
            Node currentNode = head;
            Node previousNode = null, nextNode = null;

            while(currentNode != tail)
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
            int k = 4;
            ReverseKBlockOfNodes reverseBlock = new ReverseKBlockOfNodes();
            reverseBlock.InsertAtFron(10);
            reverseBlock.InsertAtFron(9);
            reverseBlock.InsertAtFron(8);
            reverseBlock.InsertAtFron(7);
            reverseBlock.InsertAtFron(6);
            reverseBlock.InsertAtFron(5);
            reverseBlock.InsertAtFron(4);
            reverseBlock.InsertAtFron(3);
            reverseBlock.InsertAtFron(2);
            reverseBlock.InsertAtFron(1);

            Console.WriteLine("\n--- Before reverse ---");
            reverseBlock.Display();
            Console.WriteLine("\n--- After reverse Block count : "+k+"---");
            reverseBlock.head = reverseBlock.ReverseKBlock(k);
            reverseBlock.Display();

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
