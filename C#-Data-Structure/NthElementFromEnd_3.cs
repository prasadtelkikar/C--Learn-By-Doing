using System;

namespace C__Data_Structure
{
    public class NthElementFromEnd_3
    {
        Node head;
        int length;
        public NthElementFromEnd_3(){
            head = null;
            length = 0;
        }
        public void InsertAtFirst(int value){
            Node newNode = new Node(value);
            if(head == null){
                head = newNode;
                length++;
                return;
            }
            newNode.next = head;
            head = newNode;
            length++;
        }

        public void Display(){
            Node currentNode = head;
            if(currentNode == null){
                Console.WriteLine("Error: list is empty");
                return;
            }
            while(currentNode != null){
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }
        
        public void FindNthNode(int position){
            Node forwardNode = head;
            Node currentNode = head;
            int index = position;
            if(position > length || position < 1){
                Console.WriteLine("Fewer nodes present in the list");
                return;
            }
            if(head == null){
                Console.WriteLine("Error: Empty list");
                return;
            }
            while(index-- > 0)
                forwardNode = forwardNode.next;
            
            while(forwardNode != null){
                currentNode = currentNode.next;
                forwardNode = forwardNode.next;
            }

            Console.WriteLine("CurrentNode: "+currentNode.data);
        }

        public static void Main(string[] args)
        {
            NthElementFromEnd_3 objNthNode = new NthElementFromEnd_3();
            objNthNode.InsertAtFirst(5);
            objNthNode.InsertAtFirst(4);
            objNthNode.InsertAtFirst(3);
            objNthNode.InsertAtFirst(2);
            objNthNode.InsertAtFirst(1);
            objNthNode.InsertAtFirst(0);

            //objNthNode.Display();
            objNthNode.FindNthNode(7);
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
