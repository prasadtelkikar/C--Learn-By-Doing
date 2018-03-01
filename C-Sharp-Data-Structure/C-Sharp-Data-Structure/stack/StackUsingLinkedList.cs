using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack
{
    public class StackUsingLinkedList
    {
        int top;
        private StackNode head;

        public StackUsingLinkedList()
        {
            top = -1;
        }

        private StackNode CreateStackNode(int data)
        {
            return new StackNode(data);
        }

        public bool IsEmptyStack()
        {
            return top == -1;
        }
        
        public void Push(int data)
        {
            StackNode oldHead = head;
            head = CreateStackNode(data);
            head.nextNode = oldHead;
            top++;
        }

        public int Pop()
        {
            if (head == null)
                throw new Exception("Underflow");
            int data = head.data;
            head = head.nextNode;
            top--;
            return data;
        }

        public int Size()
        {
            return top + 1;
        }
        
        public override string ToString()
        {
            if (top == -1)
                return "Stack = []";
            else
            {
                Console.WriteLine("****Stack from Top to Bottom****");
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                StackNode temp = head;
                while(temp.nextNode != null)
                {
                    sb.Append(temp.data + ", ");
                    temp = temp.nextNode;
                }
                sb.Append(temp.data + "]");
                return sb.ToString();
            }
        }

        public static void Main(string[] args)
        {
            StackUsingLinkedList stackLinkedList = new StackUsingLinkedList();
            stackLinkedList.Push(1);
            stackLinkedList.Push(2);
            stackLinkedList.Push(3);
            stackLinkedList.Push(4);
            stackLinkedList.Push(5);
            stackLinkedList.Push(6);

            Console.WriteLine("Poped element = " + stackLinkedList.Pop());
            Console.WriteLine("Poped element = " + stackLinkedList.Pop());

            Console.WriteLine(stackLinkedList.ToString());



        }

        private class StackNode
        {
            public int data;
            public StackNode nextNode;

            public StackNode(int data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
    }
}
