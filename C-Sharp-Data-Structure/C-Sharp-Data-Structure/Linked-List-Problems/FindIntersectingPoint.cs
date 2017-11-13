using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class FindIntersectingPoint
    {
        Node head;
        public FindIntersectingPoint()
        {
            head = null;
        }
        
        private Node InitializeNode(int data)
        {
            return new Node(data);
        }

        //Time complexity: O(n^2)
        private Node FindIntersecting(Node headFirstList, Node headSecondList)
        {
            //n
            for (Node n1 = headFirstList; n1 != null ; n1 = n1.next)
            {
                //n
                for (Node n2 = headSecondList; n2!= null; n2 = n2.next)
                {
                    if (n1 == n2)
                        return n1;
                }
            }
            return null;
        }

        public static void Main(string[] args)
        {
            FindIntersectingPoint objFindInter = new FindIntersectingPoint();
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

            Node result = objFindInter.FindIntersecting(fstNode, fvthNode);

            if (result == null)
                Console.WriteLine("Both lists are parallel");
            else
                Console.WriteLine("List intersects at point: " + result.data);

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
