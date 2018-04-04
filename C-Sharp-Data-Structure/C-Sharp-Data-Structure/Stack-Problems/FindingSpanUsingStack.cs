using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class FindingSpanUsingStack
    {
        StackNode head;
        int top;
        public FindingSpanUsingStack()
        {
            top = -1;
        }

        private StackNode CreateNode(int data)
        {
            return new StackNode(data);
        }

        public bool IsStackEmpty()
        {
            return top == -1;
        }

        public void Push(int data)
        {
            StackNode currentNode = CreateNode(data);
            if (IsStackEmpty())
                head = currentNode;
            else
            {
                currentNode.nextNode = head;
                head = currentNode;
            }
            top++;
        }

        public int Pop()
        {
            if (IsStackEmpty())
            {
                Console.WriteLine("Stack is empty");
                return int.MinValue;
            }
            int value = head.data;
            head = head.nextNode;
            top--;
            return value;
        }

        public int Peek()
        {
            if (IsStackEmpty())
            {
                Console.WriteLine("Stack is emtpy");
                return int.MinValue;
            }
            return head.data;
        }

        public int[] FindingSpan(int[] input)
        {
            int[] span = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int high =-1;
                while (!IsStackEmpty() && input[i] > input[Peek()]) //Storing index into stack so using input[peek]
                    high = Pop();

                if (IsStackEmpty())
                    high = -1;
                else
                    high = Peek();

                span[i] = i - high;
                Push(i);
            }
            return span;
        }

        public static void Main(string[] args)
        {
            FindingSpanUsingStack fsusingStack = new FindingSpanUsingStack();
            Console.WriteLine("Enter an array");
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] result = fsusingStack.FindingSpan(input);
            fsusingStack.Display(input, result);
            Console.ReadKey();
        }

        private void Display(int[] input, int[] result)
        {
            Console.WriteLine("Input \t Result");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i] + "\t" + result[i]);
            }
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
