//Implementation of basic functions of singly linked list. Example, Insert, Delete and length
using System;

namespace C__Data_Structure
{
    public class SinglyLinkedList
    {
        private int length;
        private Node head;
        
        public SinglyLinkedList(){
            length = 0;
            head = null;
        }

        private void InsertAtFirst(int value){
            if(head == null)
            {
                head = InitializeLinkedListElement(value);
            }   
            else
            {
                Node element = InitializeLinkedListElement(value);
                element.next = head;
                head = element;
            }
            length++;
        }

        private void InsertAtEnd(int value){
            Node currentNode = head;
            Node newNode = InitializeLinkedListElement(value);

            while(currentNode.next != null)
                currentNode = currentNode.next;

            currentNode.next = newNode;
            length++;
        }

        private void InsertAtPosition(int value, int position){
            int index = 1;
            Node previousNode = head;
            Node currentNode = head;
            Node newNode = InitializeLinkedListElement(value);

            if(position < 1)
            {
                Console.WriteLine("Error due to improper position to add new node");
                return;
            }
            else if(position == 1 || currentNode == null){
                    InsertAtFirst(value);
                    length++;
                    return;
            }

                while(currentNode != null && index < position){
                    index++;
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }
                previousNode.next = newNode;
                newNode.next = currentNode;
            length++;
        }

        private void DeleteFromFirst(){
            Node currentNode = head;
            if(head == null)
                return;
            else
            {
                Node temp = currentNode.next;
                head = temp;
                currentNode = null;
            }
            length--;
        }

        private void DeleteFromEnd(){
            Node currentNode = head;
            if(head == null)
                return;
            
            if(head.next == null)
            {
                head = null;
                length--;
                return;
            }
            
            while(currentNode.next.next != null)
                currentNode = currentNode.next;

            Node temp = currentNode.next;
            currentNode.next = null;
            temp = null;
            length--;
        }

        private void DeleteFromPosition(int position)
        {
            int index = 1;
            if(position < 1)
                return;
            
            if(position == 1){
                DeleteFromFirst();
                length--;
                return;
            }

            Node previousNode = head;
            Node currentNode = head;

            while(currentNode != null && index < position){
                index++;
                previousNode = currentNode;
                currentNode = currentNode.next;
            }
            Node temp = currentNode;
            previousNode.next = currentNode.next;
            temp = null;
            length--;
            
        }
        private void DisplayList()
        {
            Node currentNode = head;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }

        private int LengthOfList()
        {
            return length;
            
            ////Alternate way
            // Node currentNode = head;
            // int count = 0;
            // while(currentNode != null){
            //     count++;
            //     currentNode = currentNode.next;
            // }

            // return count;
        }

        private Node InitializeLinkedListElement(int value){
            return new Node(value);
        }
        public static void Main(string[] args)
        {
            SinglyLinkedList objSLL = new SinglyLinkedList();
            objSLL.InsertAtFirst(3);
            objSLL.InsertAtFirst(2);
            objSLL.InsertAtFirst(1);
            objSLL.InsertAtEnd(4);
            objSLL.InsertAtEnd(5);
            objSLL.InsertAtEnd(6);
            
            objSLL.InsertAtPosition(99, 3);
            
            int length1 = objSLL.LengthOfList();
            Console.WriteLine("Length of list :" +length1);
            
            objSLL.DeleteFromFirst();
            objSLL.DeleteFromEnd();
            
            length1 = objSLL.LengthOfList();
            Console.WriteLine("Length of list :" +length1);
            
            objSLL.DeleteFromPosition(3);


            length1 = objSLL.LengthOfList();
            Console.WriteLine("Length of list :" +length1);
            
            objSLL.DisplayList();            
            length1 = objSLL.LengthOfList();

            
        }
        
    private class Node
        {
            public int data = 0;
            public Node next = null;
            
            public Node(int data)
            {
            this.data = data;   
            this.next = null;
            }
        }
    }

}
