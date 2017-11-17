using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class CheckForPalindrome
    {
        Node head;
        int length;
        public CheckForPalindrome()
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

            if (currentNode == null)
            {
                Console.WriteLine("Error: List is empty");
                return;
            }

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        private Node ReverseLinkedList(Node head)
        {
            Node currentNode = head;
            Node previousNode = null;
            Node nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            return previousNode;
        }

        private bool IsPalindrome(Node head)
        {
            Node fastNode = head;
            Node slowNode = head;
            //Node head1 = null;
            Node head2 = null;

            if (head == null)
            {
                Console.WriteLine("Error: Empty Linked list");
                return false;
            }
            //Get the middle of the linked list
            while (fastNode.next != null && fastNode.next.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;
            }

            //Reverse the second half of the linked list
            Node head1 = ReverseLinkedList(slowNode.next);

            //Compare first half and second half
            Node temp = head;
            while (head1 != null)
            {
                if (temp.data != head1.data)
                    return false;
                temp = temp.next;
                head1 = head1.next;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            CheckForPalindrome palindrome = new CheckForPalindrome();
            palindrome.InsertAtEnd(1);
            palindrome.InsertAtEnd(2);
            palindrome.InsertAtEnd(3);
            palindrome.InsertAtEnd(4);
            palindrome.InsertAtEnd(4);
            palindrome.InsertAtEnd(3);
            palindrome.InsertAtEnd(2);
            palindrome.InsertAtEnd(1);

            bool isPalindrome = palindrome.IsPalindrome(palindrome.head);

            Console.WriteLine(isPalindrome ? "Yes list is palindrom" : "No list is not palindrome");
            //palindrome.Display();
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
