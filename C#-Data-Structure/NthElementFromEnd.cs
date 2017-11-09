using System;

namespace C__Data_Structure
{
    public class NthElementFromEnd
    {
        Node head;
        public NthElementFromEnd(){
            head = null;
        }

        public void InsertAtFront(int value){
            Node newNode = new Node(value);

            if(head == null){
                head = newNode;
                return;
            }
            Node oldHead = head;
            newNode.next = head;
            head = newNode;
        }

        //GeeksforGeeks: from end: length - position = element from end
        public void FindNthNode(int position){
            Node currentNode = head;
            int temp = position;
            
            if(currentNode == null){
                Console.WriteLine("Empty list");
                return;
            }

            int length = LengthOfList();
            if(length < position){
                Console.WriteLine("fewer numbers of nodes in the list");
                return;
            }
            
            int indexFromFront = length - position;

            for(int i = 0; i < indexFromFront; i++){
                currentNode = currentNode.next;
            }
            Console.WriteLine(currentNode.data);
        }
        
        public int LengthOfList(){
            Node currentNode = head;
            int count = 0;
            if(currentNode == null)
                return 0;
            while(currentNode != null){
                count++;
                currentNode = currentNode.next;
            }    
            return count;
        }

        public void Display(){
            Node currentNode = head;
            if(currentNode == null){
                    Console.WriteLine("Empty list");
                    }
                else{
                 do{
                     Console.WriteLine(currentNode.data);
                     currentNode = currentNode.next;
                 }while(currentNode!= null);
                }
        }

        public static void Main(string[] args)
        {
            NthElementFromEnd nth = new NthElementFromEnd();
            nth.InsertAtFront(6);
            nth.InsertAtFront(5);
            nth.InsertAtFront(4);
            nth.InsertAtFront(3);
            nth.InsertAtFront(2);
            nth.InsertAtFront(1);
            nth.FindNthNode(7);
        }
        
        private class Node
        {
            public int data;
            public Node next;
            public Node(int data){
                this.data = data;
            }
        }
    }
}
