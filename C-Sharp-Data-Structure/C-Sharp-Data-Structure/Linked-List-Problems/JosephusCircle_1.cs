using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class JosephusCircle_1
    {
        Node head;
        int length;

        public JosephusCircle_1()
        {
            head = null;
            length = 0;
        }

        private Node InitializeNode(int data)
        {
            length++;
            return new Node(data);
        }

        public void Display()
        {
            Node currentNode = head;
            if(currentNode == null)
            {
                Console.WriteLine("Error: List is empty");
                return;
            }

            do
            {
                Console.Write(currentNode.data + "-> ");
                currentNode = currentNode.next;
            } while (currentNode != head);
            Console.WriteLine("null");
        }

        //Easier than recursion: Time complexity O(m.n)
        public int FindWinner(int k)
        {
            Node currentNode = head;
            Node previousNode = null;
            if (k == 0 || currentNode == null)
            {
                Console.WriteLine("Invalid inputs");
                return 0;
            }
            //n : Loop over list till length is 1
            while(length > 0)
            {
                //m : Move sword to kth position as we are eliminating kth man so looping till k - 1
                for (int i = 0; i < k - 1; i++)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }
                //Console.WriteLine("Executed number : "+ currentNode.data)
                //Removing currentNode i.e. Kth man from linked list
                previousNode.next = currentNode.next;
                currentNode = currentNode.next;
                length--;
            }
            return currentNode.data;
        }


        public static void Main(string[] args)
        {
            JosephusCircle_1 jCircle = new JosephusCircle_1();
            Node z0 = jCircle.InitializeNode(0);
            Node z1 = jCircle.InitializeNode(1);
            Node z2 = jCircle.InitializeNode(2);
            Node z3 = jCircle.InitializeNode(3);
            Node z4 = jCircle.InitializeNode(4);
            Node z5 = jCircle.InitializeNode(5);

            Node z6 = jCircle.InitializeNode(6);
            Node z7 = jCircle.InitializeNode(7);
            Node z8 = jCircle.InitializeNode(8);
            Node z9 = jCircle.InitializeNode(9);
            Node z10 = jCircle.InitializeNode(10);
            Node z11 = jCircle.InitializeNode(11);

            Node z12 = jCircle.InitializeNode(12);
            Node z13 = jCircle.InitializeNode(13);
            Node z14 = jCircle.InitializeNode(14);
            Node z15 = jCircle.InitializeNode(15);
            Node z16 = jCircle.InitializeNode(16);
            Node z17 = jCircle.InitializeNode(17);

            Node z18 = jCircle.InitializeNode(18);
            Node z19 = jCircle.InitializeNode(19);
            Node z20 = jCircle.InitializeNode(20);
            Node z21 = jCircle.InitializeNode(21);
            Node z22 = jCircle.InitializeNode(22);
            Node z23 = jCircle.InitializeNode(23);

            Node z24 = jCircle.InitializeNode(24);
            Node z25 = jCircle.InitializeNode(25);
            Node z26 = jCircle.InitializeNode(26);
            Node z27 = jCircle.InitializeNode(27);
            Node z28 = jCircle.InitializeNode(28);
            Node z29 = jCircle.InitializeNode(29);

            int k = 4;
            z0.next = z1;
            z1.next = z2;
            z2.next = z3;
            z3.next = z4;
            z4.next = z5;
            z5.next = z6;
            z6.next = z7;
            z7.next = z8;
            z8.next = z9;
            z9.next = z10;
            z10.next = z11;
            z11.next = z12;
            z12.next = z13;
            z13.next = z14;
            z14.next = z15;
            z15.next = z16;
            z16.next = z17;
            z17.next = z18;
            z18.next = z19;
            z19.next = z20;
            z20.next = z21;
            z21.next = z22;
            z22.next = z23;
            z23.next = z24;
            z24.next = z25;
            z25.next = z26;
            z26.next = z27;
            z27.next = z28;
            z28.next = z29;
            z29.next = z0;

            jCircle.head = z0; //Circular list

            //int k = 2;
            //Node zrth = jCircle.InitializeNode(0);
            //Node fstNode = jCircle.InitializeNode(1);
            //Node sndNode = jCircle.InitializeNode(2);
            //Node trdNode = jCircle.InitializeNode(3);
            //Node fthNode = jCircle.InitializeNode(4);
            //Node fvthNode = jCircle.InitializeNode(5);

            //zrth.next = fstNode;
            //fstNode.next = sndNode;
            //sndNode.next = trdNode;
            //trdNode.next = fthNode;
            //fthNode.next = fvthNode;
            //fvthNode.next = zrth;//Circular list

            //jCircle.head = zrth;
            jCircle.Display();
            int result = jCircle.FindWinner(k);

            Console.WriteLine("Winner is = " + result);
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
