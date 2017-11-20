using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class Josephus_Circle
    {
        Node head;
        int length;
        public Josephus_Circle()
        {
            head = null;
            length = 0;
        }

        private Node InitializeNode(int data)
        {
            length++;
            return new Node(data);
        }
        

        //Recursive call to find winner
        private int FindWinner(int n, int k)
        {
            if (n == 1)
                return 0;

            //As in every turn one get executed, so n -1, always k will remain same. Jumping k positions so + k and 
            // %n as it is circular and we need to get back to position in between 0 to n
            return (FindWinner(n - 1, k) + k) % n;
        }

        public void Display()
        {
            Node currentNode = head;

            if(currentNode == null)
            {
                Console.WriteLine("Error: list is empty");
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
            Josephus_Circle jcircle = new Josephus_Circle();
            Node fstNode = jcircle.InitializeNode(1);
            Node sndNode = jcircle.InitializeNode(2);
            Node trdNode = jcircle.InitializeNode(3);
            Node fthNode = jcircle.InitializeNode(4);
            Node fvthNode = jcircle.InitializeNode(5);
            Node sxthNode = jcircle.InitializeNode(6);
            int k = 2;

            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = fthNode;
            fthNode.next = fvthNode;
            fvthNode.next = sxthNode;

            sxthNode.next = fstNode;
            jcircle.head = fstNode;

            jcircle.Display();

            int winner = jcircle.FindWinner(jcircle.length, k);
            //int winner = jcircle.FindWinner(30, 4);  // winner = 5
            Console.WriteLine("Length of List: " + jcircle.length);
            Console.WriteLine("Winner is = " + winner);
            Console.ReadKey();
            //jcircle.InsertAtFirst(*);
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
