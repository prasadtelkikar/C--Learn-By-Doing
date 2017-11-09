using System;

namespace C__Data_Structure
{
    public class NthElementFromEnd_1
    {  
        private Node head;
        public NthElementFromEnd_1(){
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
                Console.WriteLine("Error: Empty list");
                return;
            }
            while(currentNode != null){
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.next;
            }
        }
        public int LenghOfList(Node headList){
            int length = 0;
            Node currentNode = headList;

            while(currentNode != null){
                length++;
                currentNode = currentNode.next;
            }
            return length;
        }

        public void FindNthElement(int position){
            int length = LenghOfList(head);
            Node currentNode = head;
            Node movingNode = head;
            if(currentNode == null)
                {
                    return;
                }

            if(length < position)  
                Console.WriteLine("Fewer number of nodes in the list");

            while(currentNode != null){
                length = LenghOfList(currentNode);
                int index = 0;
                Node movingNode = currentNode;
                if(length > position - 1){
                    while(movingNode != null){
                        index++;
                        movingNode = movingNode.newNode;
                    }
                    if(index == position){
                        Console.WriteLine("Value at "+position+" is : "+ currentNode.data);
                        return;
                    }
                    else{
                        currentNode = currentNode.next;
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            NthElementFromEnd_1 nthElement = new NthElementFromEnd_1();
            nthElement.InsertAtFirst(3);
            nthElement.InsertAtFirst(2);
            nthElement.InsertAtFirst(1);
            nthElement.InsertAtFirst(0);
            //nthElement.FindNthElement(3);
            Console.WriteLine(nthElement.LenghOfList());
            //nthElement.Display();
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
