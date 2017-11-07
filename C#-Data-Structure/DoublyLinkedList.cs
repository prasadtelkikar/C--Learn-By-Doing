using System;

namespace C__Data_Structure
{
    public class DoublyLinkedList
    {
        Node head = null;
        int length;

        private Node InitializeElement(int value){
            return new Node(value);
        }

        public void InsertAtFirst(int value){
            Node newNode = InitializeElement(value);
            if(head == null){
                head = newNode;
            }
            else{
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
            }
            length++;
        }

        public void InsertAtEnd(int value){
            Node newNode = InitializeElement(value);
            Node currentNode = head;
            if(head == null){
                head = newNode;
            }
            else{
                while(currentNode.next != null)
                    currentNode = currentNode.next;

                    currentNode.next = newNode;
                    newNode.prev = currentNode;
            }
            length++;
        }
        
        public void InsertAtPosition(int value, int position){
            Node newNode = InitializeElement(value);
            int index = 1;
            Node currentNode = head;
            if(position < 1){
                Console.WriteLine("Error!");
                return;
            }
            while(currentNode != null && index < position){
                currentNode = currentNode.next;
                index++;
            }

            currentNode.prev.next = newNode;
            newNode.prev = currentNode;

            currentNode.next.prev = newNode;
            newNode.next = currentNode;
            length++;
        }
        
        public void DeleteFromFront(){
            if(head == null)
                return;

            Node currentNode = head;
            Node nextNode = currentNode.next;
            nextNode.prev = null;
            head = nextNode;
            currentNode = null;
            length--;
        }
        
        public void DeleteFromEnd(){
            if(head == null)
                return;
            if(head.next == null){
                head = null;
                length--;
                return;
            }
                
            Node currentNode = head;
            while(currentNode.next.next != null)
                currentNode = currentNode.next;

            Node freeNode = currentNode.next;
            freeNode.prev = null;
            currentNode.next = null;
            freeNode = null;
            length--;
        }

        public void DeleteFromPosition(int position){
            int index = 1;
            if(position < 1)
            {
                Console.WriteLine("Error!");
                return;
            }
            if(position == 1){
                DeleteFromFront();
                length--;
            }
            else{
                Node currentNode = head;
                while(currentNode!=null && index < position){
                    currentNode = currentNode.next;
                    index++;
                }
                Node previousNode = currentNode.prev;
                Node nextNode = currentNode.next;
                if(nextNode == null)
                    previousNode.next = null;

                if(previousNode == null)
                    nextNode.prev = null;

                if(nextNode != null && previousNode!= null)    {
                previousNode.next = nextNode;
                nextNode.prev = previousNode;
                }
                currentNode = null;
            }
        }
        public void Display(){
            Node currentNode = head;
            
            if(head == null){
                Console.WriteLine("Empty list");
            }

            while(currentNode != null){
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }

        public static void Main(string[] args)
        {
            DoublyLinkedList objDll = new DoublyLinkedList();

            objDll.InsertAtFirst(3);
            objDll.InsertAtFirst(2);
            objDll.InsertAtFirst(1);

            objDll.InsertAtEnd(6);
            objDll.InsertAtEnd(5);
            objDll.InsertAtEnd(4);

            objDll.InsertAtPosition(99, 3);

            objDll.DeleteFromFront();
            objDll.DeleteFromFront();

            objDll.DeleteFromEnd();
            objDll.DeleteFromEnd();

            //TODO: Fix issue.
            objDll.DeleteFromPosition(3);
            objDll.Display();

        }

    private class Node
        {
            public int data;
            public Node next = null;
            public Node prev = null;

            public Node(int data){
                this.data = data;
                this.next = null;
                this.prev = null;
            }
        }
    }

}
