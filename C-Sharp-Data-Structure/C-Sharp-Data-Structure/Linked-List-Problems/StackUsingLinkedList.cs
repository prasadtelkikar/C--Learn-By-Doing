using System;
namespace C_Sharp_Data_Structure.Linked_List_Problems
{
    public class StackUsingLinkedList
    {
        Node top;
        int length;

        public StackUsingLinkedList()
        {
            top = null;
            length = 0;
        }

        public void Push(int value)
        {
            Node newNode = new Node(value);
            if (top == null)
                top = newNode;
            else
            {
                newNode.next = top;
                top = newNode;
            }
            length++;
        }

        public int Pop()
        {
            Node topNode = null;
            if (top == null)
            {
                return int.MaxValue;
            }
            else
            {
                topNode = top;
                Node afterPop = top.next;
                top = afterPop;
                length--;
                return topNode.data;
            }
        }

        private Node Peek()
        {
            return top;
        }

        public bool isEmpty()
        {
            if (top == null || length == 0)
                return true;
            else
                return false;
        }

        // Need to work on ToArray function
        // public int[] this ToArray(){
        //     Node currentNode = head;
        //     int[] result = new int[length];
        //     Node head = top;
        //     int index = length;
        //     int i = 0;
        //     while(currentNode != null && index--){
        //         result[i] = currentNode.Pop();
        //         i++;
        //     }
        //     return result;
        // }

        public static void Main(string[] args)
        {
            StackUsingLinkedList objSLL = new StackUsingLinkedList();
            objSLL.Push(1);
            objSLL.Push(2);
            objSLL.Push(3);
            Console.WriteLine(objSLL.Pop());
            Console.WriteLine(objSLL.Peek().data);
            Console.WriteLine(objSLL.Pop());

        }

        private class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
        }
    }
}