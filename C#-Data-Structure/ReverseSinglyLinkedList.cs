using System;

namespace C__Data_Structure
{
    public class ReverseSinglyLinkedList
    {
        Node head;
        int length;
        
        public ReverseSinglyLinkedList(){
            head = null;
        }
        
        private Node InitializeNode(int data){
            return new Node(data);
        }
        
        public void InsertAtFirst(int data){
            Node newNode = InitializeNode(data);

            if(head == null){
                head = newNode;
                return;
            }
            newNode.next = head;
            head = newNode;
            length++;
        }

        public void Display(){
            Node currentNode = head;

            if(currentNode == null){
                Console.WriteLine("Error: Empty List");
                return;
            }
            while(currentNode!= null){
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }

        public void ReverseLinkedList(){
            Node currentNode = head;
            Node nextNode = null, previousNode = null;

            if(currentNode == null){
                Console.WriteLine("Error: Empty linked list");
                return;
            }

            while(currentNode!= null){
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            head = previousNode;
        }

        public static void Main(string[] args)
        {
            ReverseSinglyLinkedList objRLL = new ReverseSinglyLinkedList();
            objRLL.InsertAtFirst(5);
            objRLL.InsertAtFirst(4);
            objRLL.InsertAtFirst(3);
            objRLL.InsertAtFirst(2);
            objRLL.InsertAtFirst(1);
            objRLL.InsertAtFirst(0);

            objRLL.Display();  //In forward direction

            Console.WriteLine("----Reverse linked list-----");
            objRLL.ReverseLinkedList();
            objRLL.Display(); //In reverse direction

        }

        private class Node{
            public int data;
            public Node next;

            public Node(int data){
                this.data = data;
            }
        }
    }
}
