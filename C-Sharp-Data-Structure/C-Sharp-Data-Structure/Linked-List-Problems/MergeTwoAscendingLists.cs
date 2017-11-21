using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class MergeTwoAscendingLists
    {
        Node head;
        int length;

        public MergeTwoAscendingLists()
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
            while(currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        private Node AlternateMerge(Node head1, Node head2)
        {
            Node tail = null;
            Node currentNode1 = head1;
            Node currentNode2 = head2;
            Node tempStart=null;
            Node temp = null;

            if (currentNode1 == null && currentNode2 == null)
                return null;

            if (currentNode1 == null)
                return currentNode2;

            if (currentNode2 == null)
                return currentNode1;

            while (currentNode1 != null && currentNode2 != null)
            {
                if(tempStart == null)
                {
                    temp = new Node(currentNode1.data);
                    tempStart = temp;
                    temp = new Node(currentNode2.data);
                    tempStart.next = temp;
                    tail = tempStart.next;
                }
                else
                {
                    temp = new Node(currentNode1.data);
                    tail.next = temp;
                    tail = tail.next;
                    temp = new Node(currentNode2.data);
                    tail.next = temp;
                    tail = tail.next;
                }
                
                currentNode1 = currentNode1.next;
                currentNode2 = currentNode2.next;
            }

            if (currentNode1 != null)
                tail.next = currentNode1;
            else
                tail.next = currentNode2;

            return tempStart;
        }

        public static void Main(string[] args)
        {
            MergeTwoAscendingLists head1 = new MergeTwoAscendingLists();
            head1.InsertAtEnd(5);
            head1.InsertAtEnd(6);
            head1.InsertAtEnd(7);
            //head1.InsertAtEnd(8);
            //head1.InsertAtEnd(9);
            //head1.InsertAtEnd(10);

            MergeTwoAscendingLists head2 = new MergeTwoAscendingLists();
            head2.InsertAtEnd(1);
            head2.InsertAtEnd(2);
            head2.InsertAtEnd(3);
            head2.InsertAtEnd(4);
            head2.InsertAtEnd(5);
            head2.InsertAtEnd(6);
            head2.InsertAtEnd(7);
            head2.InsertAtEnd(8);



            head1.Display();
            head2.Display();
            Node result = head1.AlternateMerge(head1.head, head2.head);

            head1.head = result;
            head1.Display();

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
