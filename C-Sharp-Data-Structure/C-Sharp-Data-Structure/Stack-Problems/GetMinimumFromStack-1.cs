using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class GetMinimumFromStack_1
    {
        int mainTop;
        int minTop;
        StackNode mainHead;
        StackNode minHead;

        public GetMinimumFromStack_1()
        {
            mainTop = -1;
            minTop = -1;
        }
        private StackNode CreateNode(int data)
        {
            return new StackNode(data);
        }
        public bool IsEmptyMainStack()
        {
            return (mainTop == -1);
        }
        public bool IsEmptyMinStack()
        {
            return (minTop == -1);
        }

        public void Push(int data)
        {
            StackNode oldMainHead = mainHead;
            StackNode newNode = CreateNode(data);
            newNode.nextNode = mainHead;
            mainHead = newNode;
            StackNode oldMinHead;
            StackNode newMinNode;

            if (IsEmptyMinStack() || minHead.data >= data)
            {
                oldMinHead = minHead;
                newMinNode = CreateNode(data);
                newMinNode.nextNode = oldMinHead;
                minHead = newMinNode;
                minTop++;
            }
            mainTop++;
        }

        public int Pop()
        {
            int temp;
            if(IsEmptyMainStack())
            {
                Console.WriteLine("Underflow");
                return -1;
            }
            else
            {
                temp = mainHead.data;
                if(temp == minHead.data)
                {
                    minHead = minHead.nextNode;
                    minTop--;
                }
                mainHead = mainHead.nextNode;
                mainTop--;
            }
            return temp;
        }

        public int GetMinimum()
        {
            if (IsEmptyMinStack())
            {
                Console.WriteLine("Min stack is empty");
                return int.MaxValue; //Returning garbage value if stack is null
            }
            return minHead.data;
        }
        public static void Main(string[] args)
        {
            GetMinimumFromStack_1 getMin = new GetMinimumFromStack_1();
            getMin.Push(2);
            getMin.Push(6);
            getMin.Push(4);
            getMin.Push(1);
            getMin.Push(5);

            Console.WriteLine(getMin.GetMinimum());
            getMin.Pop();
            getMin.Pop();
            Console.WriteLine(getMin.GetMinimum());
            Console.ReadKey();
        }
        private class StackNode
        {
            public int data;
            public StackNode nextNode;

            public StackNode(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }
    }
}
