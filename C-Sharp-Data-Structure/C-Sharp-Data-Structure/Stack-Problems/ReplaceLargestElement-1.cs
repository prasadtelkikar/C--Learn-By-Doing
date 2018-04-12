using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class ReplaceLargestElement_1
    {
        int top;
        Node head;
        ReplaceLargestElement_1()
        {
            top = -1;
        }

        private Node CreateNode(int data)
        {
            return new Node(data);
        }

        public bool IsEmptyStack()
        {
            return top == -1;
        }

        public void Push(int data)
        {
            Node newNode = CreateNode(data);
            if (IsEmptyStack())
                head = newNode;
            else
            {
                newNode.next = head;
                head = newNode; 
            }
            top++;
        }

        public int Pop()
        {
            if (IsEmptyStack())
            {
                Console.WriteLine("Stackunderflow");
                return int.MinValue;
            }
            int value = head.data;
            head = head.next;
            top--;
            return value;
        }

        private void FindNearestLargestNumber(int[] input)
        {
            Push(input[0]);
            for (int i = 0; i < input.Length; i++)
            {
                int element = 0;
                int nextGreatestNo = input[i];
                if (!IsEmptyStack())
                {
                    element = Pop();
                    while (element < nextGreatestNo)
                    {
                        Console.WriteLine("Nearest greatest element of " + element + " is = " + nextGreatestNo);
                        if (IsEmptyStack())
                            break;
                        element = Pop();
                    }
                    if (element > nextGreatestNo)
                    {
                        Push(element);
                    }
                }
                Push(nextGreatestNo);
            }
            //For least number in an array
            while (!IsEmptyStack())
            {
                int value = Pop();
                int minValue = int.MinValue;
                Console.WriteLine("Nearest greatest element of " + value + " is = " + minValue);
            }
        }


        public static void Main(string[] args)
        {
            ReplaceLargestElement_1 replaceElement = new ReplaceLargestElement_1();
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            replaceElement.FindNearestLargestNumber(input);

            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        }
    }
}
