using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindIntersectingPoint_1
    {
        Node head;

        public FindIntersectingPoint_1()
        {
            head = null;
        }

        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        //Time complexity : O(m + n)
        private Node FindIntersect(Node firstListHead, Node secondListHead)
        {
            Node temp = null;
            Stack<Node> firstStack = new Stack<Node>();
            Stack<Node> secondStack = new Stack<Node>();

            //m
            for (Node n1 = firstListHead; n1 != null; n1 = n1.next)
                firstStack.Push(n1);

            //n
            for (Node n2 = secondListHead; n2 != null; n2 = n2.next)
                secondStack.Push(n2);

            while (firstStack.Count > 0 || secondStack.Count > 0)
            {
                Node firstTop = firstStack.Pop();
                Node secondTop = secondStack.Pop();
                if (firstTop == secondTop)
                    temp = firstTop;
                else
                    break;
            }
            return temp;
        }
        public static void Main(string[] args)
        {
            FindIntersectingPoint_1 objFindInter = new FindIntersectingPoint_1();
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

            Node intersectingNode = objFindInter.FindIntersect(fstNode, fvthNode);
            if (intersectingNode == null)
                Console.WriteLine("Both lists are parallel");
            else
                Console.WriteLine("Intersection point of both the lists are: " + intersectingNode.data);

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
