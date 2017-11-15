using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class MergeTwoSortedListRecursion
    {

        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        private void Display(Node head)
        {
            Node currentNode = head;

            if(currentNode == null)
            {
                Console.WriteLine("Error: List is empty");
            }
            while(currentNode != null)
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("null");
        }

        //Merging of list using recursion
        private Node MergeingOfSortedList(Node HeadOfFirstList, Node HeadOfSecondList)
        {
            if (HeadOfFirstList == null)
                return HeadOfSecondList;

            if (HeadOfSecondList == null)
                return HeadOfFirstList;

            if(HeadOfFirstList.data < HeadOfSecondList.data)
            {
                HeadOfFirstList.next = MergeingOfSortedList(HeadOfFirstList.next, HeadOfSecondList);
                return HeadOfFirstList;
            }
            else
            {
                HeadOfSecondList.next = MergeingOfSortedList(HeadOfSecondList.next, HeadOfFirstList);
                return HeadOfSecondList;
            }
                
        }

        public static void Main(string[] args)
        {
            MergeTwoSortedListRecursion objSortedList = new MergeTwoSortedListRecursion();
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

            Node result = objSortedList.MergeingOfSortedList(fstNode, fthNode);
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
