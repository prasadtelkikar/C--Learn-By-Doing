using System;

namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class LengthOfCyclicLoop
    {
        Node head;

        public LengthOfCyclicLoop(){
            head = null;
        }

        private Node InitializeNode(int value){
            return new Node(value);
        }

        public int FindLengthOfCycle(){
            int length = 0;
            Node connectingNode = FindEntryOfCyclicList();    
            Node temp = connectingNode;

            if(temp == null){
                Console.WriteLine("Either list is empty or not cyclic in nature");
                return length;
            }
            do{
                connectingNode = connectingNode.next;
                length++;
            }while(connectingNode != temp);
        return length;
        }

        private Node FindEntryOfCyclicList(){
            Node fastNode = head;
            Node slowNode = head;

            if(fastNode == null)
                return null;
            
            while(fastNode != null && slowNode != null && fastNode.next != null){
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;

                if(fastNode == slowNode){
                    return fastNode;
                }
            }
            return null;
        }

        public static void Main(string[] args)
        {
            LengthOfCyclicLoop objLCL = new LengthOfCyclicLoop();
            Node fstNode = objLCL.InitializeNode(1);
            Node sndNode = objLCL.InitializeNode(2);
            Node trdNode = objLCL.InitializeNode(3);
            Node fthNode = objLCL.InitializeNode(4);
            Node fvthNode = objLCL.InitializeNode(5);
            Node sxthNode = objLCL.InitializeNode(6);
            Node svthNode = objLCL.InitializeNode(7);
            Node ethNode = objLCL.InitializeNode(8);

            objLCL.head = fstNode;
            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = fthNode;
            fthNode.next = fvthNode;
            fvthNode.next = sxthNode;
            sxthNode.next = svthNode;
            svthNode.next = ethNode;

            ethNode.next = trdNode; // Cyclic
            
            int length = objLCL.FindLengthOfCycle();

            Console.WriteLine("Length of Cyclic list: "+length);
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
