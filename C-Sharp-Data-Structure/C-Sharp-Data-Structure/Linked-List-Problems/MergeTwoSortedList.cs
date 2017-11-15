using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class MergeTwoSortedList
    {
        public MergeTwoSortedList()
        {
        }

        private Node InitializeNode(int value)
        {
            return new Node(value);
        }

        //Source: StackOverflow - https://stackoverflow.com/questions/10707352/interview-merging-two-sorted-singly-linked-list
        private Node MergeingOfTwoList(Node firstListHead, Node secondListHead)
        {
            if (firstListHead == null)
                return secondListHead;
            if (secondListHead == null)
                return firstListHead;

            Node head;
            //If first node of first list is small then make head as first list
            if (firstListHead.data < secondListHead.data)
                head = firstListHead;
            else
            {
                //If first node of second list is small then swap first and second list with each other using head
                head = secondListHead;
                secondListHead = firstListHead;
                firstListHead = head;
            }

            //Now first list is going to be sorted
            while (firstListHead.next != null && secondListHead != null)
            {
                //If next element data of first list is greater than second list data then
                if (firstListHead.next.data > secondListHead.data)
                {
                    //Take next node of first list into temp
                    Node temp = firstListHead.next;
                    //Attach smallest element to first list
                    firstListHead.next = secondListHead;
                    //move larger data to the second list
                    secondListHead = temp;
                }
                //Keep moving**
                firstListHead = firstListHead.next;
            }
            firstListHead.next = secondListHead;
            return head;
        }

        private void Display(Node head)
        {
            Node currentNode = head;
            if (currentNode == null)
                Console.WriteLine("Error: Empty linked list");

            while (currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        public static void Main(string[] args)
        {
            MergeTwoSortedList objSortedList = new MergeTwoSortedList();
            Node fstNode = objSortedList.InitializeNode(5);
            Node sndNode = objSortedList.InitializeNode(10);
            Node trdNode = objSortedList.InitializeNode(15);

            Node fthNode = objSortedList.InitializeNode(2);
            Node fvthNode = objSortedList.InitializeNode(3);
            Node sxthNode = objSortedList.InitializeNode(20);

            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = null;

            fthNode.next = fvthNode;
            fvthNode.next = sxthNode;
            sxthNode.next = null;

            Node result = objSortedList.MergeingOfTwoList(fstNode, fthNode);

            objSortedList.Display(result);
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
