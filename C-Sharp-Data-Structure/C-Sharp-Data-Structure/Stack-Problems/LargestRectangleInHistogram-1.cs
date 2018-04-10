using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    //http://k2code.blogspot.in/2013/11/maximum-area-rectangle-in-histogram.html
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
                return 0;
            }
            int value = head.data;
            head = head.nextData;
            top--;
            return value;
        }

        public int Peek()
        {
            if (IsEmptyStack())
            {
                Console.WriteLine("Stack underflow");
                return int.MinValue;
            }
            return head.data;
        }

        private int FindMaxArea(int[] input)
        {
            int maxArea = 0;
            foreach (int inp in input)
            {
                if (IsEmptyStack() || inp > Peek())
                    Push(inp);
                else
                {
                    int count = 0;
                    while(!IsEmptyStack() && Peek() > inp)
                    {
                        count++;
                        int value = Pop();
                        maxArea = Math.Max(maxArea, (value * count));
                    }
                    for (int i = 0; i <= count; i++)
                    {
                        Push(inp);
                    }
                }
            }

            int countLast = 0;
            while (!IsEmptyStack())
            {
                countLast++;
                maxArea = Math.Max(maxArea, Pop() * countLast);
            }
            return maxArea;
        }

        public static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            LargestRectangleInHistogram_1 largestRect = new LargestRectangleInHistogram_1();
            int maxArea = largestRect.FindMaxArea(input);
            Console.WriteLine("Area of largest rectangle in histogram = " + maxArea);
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
