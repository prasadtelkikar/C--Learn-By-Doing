using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class GetMinimumFromStack
    {
        int topMain;
        int topMin;
        private StackNode mainHead;
        private StackNode minHead;

        public GetMinimumFromStack()
        {
            topMain = -1;
            topMin = -1;
        }

        private StackNode CreateStack(int data)
        {
            return new StackNode(data);
        }
        public bool IsEmptyStack()
        {
            return (topMain == -1 || topMin == -1);
        }

        public void Push(int data)
        {
            StackNode oldNode = mainHead;
            StackNode newNode = CreateStack(data);
            newNode.nextNode = oldNode;
            mainHead = newNode;
            StackNode oldMinNode = minHead;
            StackNode newMinNode;
            if (IsEmptyStack() || MinPeek()>= data)
                newMinNode = CreateStack(data);
            else
            {
                newMinNode = CreateStack(MinPeek());
                newMinNode.nextNode = oldMinNode;
            }

            newMinNode.nextNode = oldMinNode;
            minHead = newMinNode;
            topMain++;
            topMin++;
        }

        public int Pop()
        {
            if (IsEmptyStack())
                return -1;
            int temp = mainHead.data;
            mainHead = mainHead.nextNode;
            minHead = minHead.nextNode;
            topMin--;
            topMain--;
            return temp;
        }

        public int MinPeek()
        {
            if (IsEmptyStack())
                return int.MaxValue;

            return minHead.data;
        }

        public int GetMinimum()
        {
            return minHead.data;
        }

        public static void Main(string[] args)
        {
            GetMinimumFromStack getMin = new GetMinimumFromStack();
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
