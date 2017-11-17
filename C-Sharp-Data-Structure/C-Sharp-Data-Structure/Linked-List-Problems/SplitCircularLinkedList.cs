using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    class SplitCircularLinkedList
    {
        Node head;
        public SplitCircularLinkedList()
        {
            head = null;
        }
        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        private void GetLastNode(Node fastNode, Node slowNode)
        {
            if (fastNode == null || slowNode == null)
                return;

            /*For odd number of nodes fastNode.next becomes head & for even number of nodes fastNode.next.next becomes head*/
            while(fastNode.next != head && fastNode.next.next != head)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;
            }

            //If list contains even number of nodes, then move fast node one step above
            if (fastNode.next.next == head)
                fastNode = fastNode.next;

            //Here you will get heads of two different lists.
            Node head1 = fastNode.next;
            Node head2 = slowNode.next;

            //Connect end of first list i.e. middle of main list to the head
            slowNode.next = head1;

            //Connect end of second list i.e. end of list to the second head
            fastNode.next = head2;
            Console.WriteLine("\n---First half of Linked list ---");
            Display(head1);
            Console.WriteLine("\n---Second half of Linked list ---");
            Display(head2);
        }
        
        private void Display(Node head)
        {
            Node currentNode = head;

            if(currentNode == null)
            {
                Console.WriteLine("Error: Empty list");
                return;
            }
            do
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            } while (currentNode != head);
            Console.WriteLine("null");
        }

        public static void Main(string[] args)
        {
            SplitCircularLinkedList splitCLL = new SplitCircularLinkedList();
            Node fstNode = splitCLL.InitializeNode(1);
            Node sndNode = splitCLL.InitializeNode(2);
            Node trdNode = splitCLL.InitializeNode(3);
            Node fthNode = splitCLL.InitializeNode(4);
            Node fvthNode = splitCLL.InitializeNode(5);
            Node sxthNode = splitCLL.InitializeNode(6);
            Node svthNode = splitCLL.InitializeNode(7);
            Node ethNode = splitCLL.InitializeNode(8);

            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = fthNode;
            fthNode.next = fvthNode;
            fvthNode.next = sxthNode;
            sxthNode.next = svthNode;
            svthNode.next = ethNode;

            ethNode.next = fstNode;

            splitCLL.head = fstNode;
            Node fastNode = fstNode;
            Node slowNode = fstNode;

            Console.WriteLine("----Full Linked list-----");
            splitCLL.Display(splitCLL.head);
            splitCLL.GetLastNode(slowNode, fastNode);
            
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
