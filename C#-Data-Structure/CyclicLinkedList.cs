using System;
using System.Collections.Generic;

namespace C__Data_Structure
{
    public class CyclicLinkedList
    {
        Node head;
        public CyclicLinkedList(){
            head = null;
        }
        private Node InitializeNode(int value){
            return new Node(value);
        }
        
        //Using list instead of Hashtable
        public void FindCyclic(){
            Node currentNode = head;
            List<Node> visitedNodes = new List<Node>();

            if(currentNode == null){
                Console.WriteLine("Error: Empty list");
                return;
            }
            while(currentNode!= null){

                if(visitedNodes.Contains(currentNode)){
                    Console.WriteLine("Cyclic List");
                    return;
                }
                visitedNodes.Add(currentNode);
                currentNode = currentNode.next;
            }
            Console.WriteLine("List is not cyclic");
        }
        public static void Main(string[] args)
        {
            CyclicLinkedList objCLL = new CyclicLinkedList();
            Node fstNode = objCLL.InitializeNode(1);
            Node SndNode = objCLL.InitializeNode(2);
            Node TrdNode = objCLL.InitializeNode(3);
            Node FthNode = objCLL.InitializeNode(4);
            Node FivthNode = objCLL.InitializeNode(5);
            Node SixthNode = objCLL.InitializeNode(6);
            Node SevethNode = objCLL.InitializeNode(7);
            Node EthNode = objCLL.InitializeNode(8);

            objCLL.head = fstNode;
            fstNode.next = SndNode;
            SndNode.next = TrdNode;
            TrdNode.next = FthNode;
            FthNode.next = FivthNode;
            FivthNode.next = SixthNode;
            SixthNode.next = SevethNode;
            SevethNode.next = EthNode;

            EthNode.next = TrdNode; //Cyclic node

            objCLL.FindCyclic();
        }

        private class Node{
            public int data;
            public Node next;
            
            public Node(int data){
                this.data = data;
                this.next = null;
            }
        }
    }
}
