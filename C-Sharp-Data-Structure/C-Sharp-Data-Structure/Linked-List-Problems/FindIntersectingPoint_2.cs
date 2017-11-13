using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindIntersectingPoint_2
    {
        Node head;
        public FindIntersectingPoint_2()
        {
            head = null;
        }

        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        //Using List instead of HashTable. Time complexity: O(m)+ O(n)
        private Node FindIntersect(Node firstListHead, Node secondListHead)
        {
            List<Node> nodeList = new List<Node>();
            //n
            for (Node n1 = firstListHead; n1 != null; n1 = n1.next)
                nodeList.Add(n1);
            //m
            for (Node n2 = secondListHead; n2 != null; n2 = n2.next)
            {
                if (nodeList.Contains(n2))
                    return n2;
            }
            return null;
        }

        public static void Main()
        {
            FindIntersectingPoint_2 objFindInter = new FindIntersectingPoint_2();
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
                Console.WriteLine("Both the lists are paraller");
            else
                Console.WriteLine("List are intersecting at node: " + intersectingNode.data);

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
