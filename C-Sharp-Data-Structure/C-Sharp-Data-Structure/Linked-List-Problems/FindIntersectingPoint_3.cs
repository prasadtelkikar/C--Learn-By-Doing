using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindIntersectingPoint_3
    {
        Node head;
        public FindIntersectingPoint_3()
        {
            head = null;
        }

        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        private int FindLength(Node head)
        {
            int index = 0;
            Node currentHead = head;
            
            while (currentHead != null)
            {
                currentHead = currentHead.next;
                index++;
            }
            return index;
        }

        private Node FindIntersection(Node firstListHead, Node secondListHead)
        {
            Node firstListNode = firstListHead;
            Node secondListNode = secondListHead;

            int firstListLength = FindLength(firstListHead);
            int secondListLength = FindLength(secondListHead);
            int diff = 0;
            bool isFirstLonger = (firstListLength > secondListLength) ? true : false;

            if (isFirstLonger)
                diff = firstListLength - secondListLength;
            else
                diff = secondListLength - firstListLength;

            if (isFirstLonger)
            {
                while (diff-- > 0)
                    firstListNode = firstListNode.next;
            }
            else
            {
                while (diff-- > 0)
                    secondListNode = secondListNode.next;
            }

            while (firstListNode != null || secondListNode != null)
            {
                if (secondListNode == firstListNode)
                    return secondListNode;

                firstListNode = firstListNode.next;
                secondListNode = secondListNode.next;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            FindIntersectingPoint_3 objFindInter = new FindIntersectingPoint_3();
            Node fstNode = objFindInter.InitializeNode(1);
            Node sndNode = objFindInter.InitializeNode(2);
            Node trdNode = objFindInter.InitializeNode(3);
            Node frthNode = objFindInter.InitializeNode(4);
            Node fvthNode = objFindInter.InitializeNode(5);
            Node sxthNode = objFindInter.InitializeNode(6);
            Node svthNode = objFindInter.InitializeNode(7);

            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = frthNode;
            frthNode.next = null; //End of fist list;

            fvthNode.next = sxthNode;
            sxthNode.next = svthNode;

            svthNode.next = trdNode; //trdNode is intersecting point

            Node temp = objFindInter.FindIntersection(fstNode, fvthNode);
            if (temp == null)
                Console.WriteLine("Both the lists are parallel");
            else
                Console.WriteLine("Both the list intersects at : " + temp.data);
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
