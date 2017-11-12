using System;

namespace C__Data_Structure
{
    public class InsertInSortedList
    {
        Node head;
        int length;
        private Node InitializeNode(int data){
            return new Node(data);
        }
        
        public void InsertAtFirst(int data){
            Node newNode = InitializeNode(data);

            if(head == null){
                head = newNode;
                length++;
                return;
            }
            newNode.next = head;
            head = newNode;
            length++;
        }
        
        public void InsertNodeToSortedList(int data){
            Node newNode = InitializeNode(data);
            Node currentNode = head;
            Node previouseNode = null;

            if(head == null){
                head = newNode;
                length++;
                return;
            }
            while(currentNode != null && currentNode.data < data)
            {
                previouseNode = currentNode;
                currentNode = currentNode.next;
            }
            if(previouseNode != null){
                previouseNode.next = newNode;
                newNode.next = currentNode;
            }
            else{
                newNode.next = currentNode;
                head = newNode;
            }
            length++;
        }

        public void Display(){
            Node currentNode = head;
            if(currentNode == null){
                Console.WriteLine("Error: Empty Linked list");
                return;
            }
            while(currentNode!=null){
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }

        public static void Main(string[] args)
        {
            InsertInSortedList objISL = new InsertInSortedList();
            objISL.InsertAtFirst(14);
            objISL.InsertAtFirst(12);
            objISL.InsertAtFirst(8);
            objISL.InsertAtFirst(6);
            objISL.InsertAtFirst(4);
            objISL.InsertAtFirst(2);
            
            objISL.InsertNodeToSortedList(16);
            objISL.Display();
        
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
