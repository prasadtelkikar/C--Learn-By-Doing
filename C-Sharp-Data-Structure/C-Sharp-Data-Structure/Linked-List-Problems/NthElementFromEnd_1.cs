using System;

namespace C_Sharp_Data_Structure.Linked_List_Problems
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

        private int LenghOfList(Node headList){
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
            
            if(length < position || position <= 0){
                Console.WriteLine("Fewer number of nodes in the list");
                return;
            }
                
            //Time Complexity: O(n^2): Brute-Force Method
            while(currentNode != null){ //n
                length = LenghOfList(currentNode);
                int index = 0;
                movingNode = currentNode;
                if(length > position - 1){
                    while(movingNode != null){ //n
                        index++;
                        movingNode = movingNode.next;
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
            nthElement.FindNthElement(3);

            //Console.WriteLine(nthElement.LenghOfList(nthElement.head));
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
