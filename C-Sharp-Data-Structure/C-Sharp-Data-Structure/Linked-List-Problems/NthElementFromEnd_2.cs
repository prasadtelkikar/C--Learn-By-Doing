using System;
using System.Collections.Generic;
//Efficient appoarch to first implementation: NthElementFromEnd_1.cs
namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class NthElementFromEnd_2
    {
        Node head;
        Dictionary<int, Node> nodesWithPos = new Dictionary<int, Node>();
        public NthElementFromEnd_2(){
            head = null;
        }

        public void InsertAtFirst(int value){
            Node newNode = new Node(value);

            if(head == null){
                head = newNode;
                return;
            }
            newNode.next = head;
            head = newNode;
        }

        public void Display(){
            Node currentNode = head;
            if(currentNode == null){
                Console.WriteLine("Error: Empty List");
                return;
            }
            while(currentNode!= null){
                Console.Write(currentNode.data+"-> ");
                currentNode = currentNode.next;
            }
            Console.Write("null");
        }

        public int TraverseList(){
            int index = 0;
            Node currentNode = head;
            if(currentNode == null){
                return 0;
            }
            while(currentNode != null){
                nodesWithPos.Add(index + 1, currentNode);
                index++;
                currentNode = currentNode.next;
            }
            return index;
        }
        public void FindNthElement(int position){
            int length = TraverseList();
            if(length == 0){
                Console.WriteLine("List is empty");
                return;
            }
            if(length < position){
                Console.WriteLine("Fewer number of nodes in the list");
                return;
            }
            int nthFromFront = (length - position + 1);
            if(nodesWithPos.ContainsKey(nthFromFront))
                Console.WriteLine(nodesWithPos[nthFromFront].data);
            else
                Console.WriteLine("Not found");
        }
        public static void Main(string[] args)
        {
            NthElementFromEnd_2 nthObj = new NthElementFromEnd_2();
            nthObj.InsertAtFirst(4);
            nthObj.InsertAtFirst(3);
            nthObj.InsertAtFirst(2);
            nthObj.InsertAtFirst(1);
            nthObj.InsertAtFirst(0);
            
            nthObj.FindNthElement(99);
            //nthObj.Display();

            Console.ReadKey();
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
