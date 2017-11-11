using System;

namespace C__Data_Structure
{
    public class StartOfCyclicList
    {
        Node head;
        public StartOfCyclicList(){
            head = null;
        }

        private Node InitializeNode(int data){
            return new Node(data);
        }
        
        private Node FindConnNode(){
            Node fastNode = head;
            Node slowNode = head;
            if(head == null){
                return null;
            }

            while(slowNode != null &&fastNode != null && fastNode.next != null){
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
            StartOfCyclicList objSCL = new StartOfCyclicList();

            Node fstNode = objSCL.InitializeNode(1);
            Node sndNode = objSCL.InitializeNode(2);
            Node trdNode = objSCL.InitializeNode(3);
            Node frthNode = objSCL.InitializeNode(4);
            Node fvthNode = objSCL.InitializeNode(5);
            Node sxthNode = objSCL.InitializeNode(6);
            Node svthNode = objSCL.InitializeNode(7);
            Node ethNode = objSCL.InitializeNode(8);

            objSCL.head = fstNode;
            fstNode.next = sndNode;
            sndNode.next = trdNode;
            trdNode.next = frthNode;
            frthNode.next = fvthNode;
            fvthNode.next = sxthNode;
            sxthNode.next = svthNode;
            svthNode.next = ethNode;

            ethNode.next = trdNode; //Cyclic

            Node joiningNode = objSCL.FindConnNode();
            if(joiningNode == null){
                Console.WriteLine("Not connected or empty list");
            }
            else{
                Console.WriteLine("Cyclic list starts at node : "+joiningNode.data);
            }
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
