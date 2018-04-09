using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class LargestRectangleInHistogram_1
    {
        int top;
        Node head;

        public LargestRectangleInHistogram_1()
        {
            top = -1;
        }

        private Node CreateStackNode(int data)
        {
            return new Node(data);
        }

        public bool IsEmptyStack()
        {
            return top == -1;
        }

        public void Push(int data)
        {
            Node newNode = CreateStackNode(data);
            if (IsEmptyStack())
                head = newNode;
            else
            {
                newNode.nextData = head;
                head = newNode;
            }
            top++;
        }

        public int Pop()
        {
            if (IsEmptyStack())
            {
                Console.WriteLine("Stack underflow");
                return int.MinValue;
            }
            int value = head.data;
            head = head.nextData;
            return value;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        private class Node
        {
            public int data;
            public Node nextData;
            public Node(int data)
            {
                this.data = data;
                this.nextData = null;
            }
        }
    }
}
