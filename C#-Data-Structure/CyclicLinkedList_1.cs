using System;

namespace C__Data_Structure
{
    public class CyclicLinkedList_1
    {
        Node head;


        private Node InitializeNode(int data){
            return new Node(data);
        }

        //Most efficient way to resolve Cyclic linked list program: Floyd cycle finding algorithm
        public void FindCyclic(){
            Node fastNode = head;
            Node slowNode = head;
            if(fastNode == null)
            {
                Console.WriteLine("Error: Empty Linked list");
                return;
            }
            while(slowNode != null && fastNode != null && fastNode.next != null){
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;

                if(fastNode == slowNode)
                {
                    Console.WriteLine("List is cyclic");
                    return;
                }
            }
            Console.WriteLine("List is not cyclic");
        }
        public static void Main(string[] args)
        {
            CyclicLinkedList_1 objCLL = new CyclicLinkedList_1();
            Node fstNode = objCLL.InitializeNode(1);
            Node SndNode = objCLL.InitializeNode(2);
            Node TrdNode = objCLL.InitializeNode(3);
            Node FrthNode = objCLL.InitializeNode(4);
            Node FvthNode = objCLL.InitializeNode(5);
            Node SxthNode = objCLL.InitializeNode(6);
            Node SvthNode = objCLL.InitializeNode(7);
            Node EthNode = objCLL.InitializeNode(8);

            objCLL.head = fstNode;
            fstNode.next = SndNode;
            SndNode.next = TrdNode;
            TrdNode.next = FrthNode;
            FrthNode.next = FvthNode;
            FvthNode.next = SxthNode;
            SxthNode.next = SvthNode;
            SvthNode.next = EthNode;

            EthNode.next = TrdNode; //Cyclic linkedList
            
            objCLL.FindCyclic();
        }

        private class Node{
            public int data;
            public Node next;

            public Node(int data){
                this.data = data;
                next = null;
            }
        }
    }
}
