using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class SuccessivePairInStack
    {
        private Stack stackHead;
        private Queue queueHead;
        public int top;
        public SuccessivePairInStack()
        {
            queueHead = new Queue();
            top = -1;
        }

        private Stack CreateNode(int data)
        {
            return new Stack(data);
        }
        
        public bool IsEmptyStack()
        {
            return (top == -1);
        }

        public bool IsEmptyQueue()
        {
            return (queueHead.frontIndex == null);
        }

        public void Push(int data)
        {
            Stack newNode = CreateNode(data);
            if (IsEmptyStack())
            {
                stackHead = newNode;
                top++;
                return;
            }
            newNode.nextNode = stackHead;
            stackHead = newNode;
            top++;
        }

        public int Pop()
        {
            if (IsEmptyStack())
                throw new Exception("Stack is empty");
            int data = stackHead.data;
            stackHead = stackHead.nextNode;
            top--;
            return data;
        }

        public void EnQueue(int data)
        {
            QueueIndex newNode = new QueueIndex(data);
            
            if (IsEmptyQueue())
            {
                queueHead.rearIndex = newNode;
                queueHead.frontIndex = queueHead.rearIndex;
                return;
            }
            queueHead.rearIndex.nextIndex = newNode;
            queueHead.rearIndex = queueHead.rearIndex.nextIndex;
        }

        public int DeQueue()
        {
            if (IsEmptyQueue())
            {
                throw new Exception("Queue is empty");
            }
            int data = queueHead.frontIndex.data;
            queueHead.frontIndex = queueHead.frontIndex.nextIndex;
            return data;
        }

        public bool IsSuccessivePairInStack()
        {
            bool isSuccessivePair = true;
            Queue newQueue = new Queue();
            while (!IsEmptyStack())
            {
                int data = Pop();
                EnQueue(data);
            }
            while (!IsEmptyQueue())
            {
                Push(DeQueue());
            }
            while (!IsEmptyStack())
            {
                if (top % 2 == 0)
                    EnQueue(Pop());
                else
                {
                    if (!IsEmptyStack())
                    {
                        int m = Pop();
                        EnQueue(m);
                        int n = Pop();
                        EnQueue(n);
                        if (Math.Abs(m - n) != 1)
                            isSuccessivePair = false;
                    }
                }
            }
            while (!IsEmptyQueue())
            {
                Push(DeQueue());
            }
            return isSuccessivePair;
        }
        public static void Main(string[] args)
        {
            SuccessivePairInStack successivePair = new SuccessivePairInStack();
            successivePair.Push(1);
            successivePair.Push(2);
            successivePair.Push(3);
            successivePair.Push(4);
            successivePair.Push(5);
            Console.WriteLine((successivePair.IsSuccessivePairInStack()) ? "Stack contains successive pairs" : "Stack doesn't contains successive pair");

  //          Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        private class Stack
        {
            public int data;
            public Stack nextNode;
            public Stack(int data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }

        private class Queue
        {
            public QueueIndex frontIndex;
            public QueueIndex rearIndex;
        }

        private class QueueIndex
        {
            public int data;
            public QueueIndex nextIndex;
            public QueueIndex(int data)
            {
                this.data = data;
                this.nextIndex = null;
            }
        }
    }
}
