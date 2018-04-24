using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class SequenceOfInterleavePairs
    {
        private Queue headQueue;
        private Stack headStack;
        public int count;
        public int top;

        public int Length
        {
            get
            {
                return count;
            }
        }

        public SequenceOfInterleavePairs()
        {
            count = 0;
            top = -1;
            headQueue = new Queue();
        }

        public bool IsEmptyQueue()
        {
            return (count == 0);
        }

        public bool IsEmptyStack()
        {
            return (top == -1);
        }

        public void EnQueue(int data)
        {
            QueueIndex newNode = new QueueIndex(data);
            if (IsEmptyQueue())
            {
                headQueue.rearIndex = newNode;
                headQueue.frontIndex = headQueue.rearIndex;
                count++;
                return;
            }
            headQueue.rearIndex.nextNode = newNode;
            headQueue.rearIndex = headQueue.rearIndex.nextNode;
            count++;
            return;
        }

        public int DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is empty");
            int data = headQueue.frontIndex.data;
            count--;
            headQueue.frontIndex = headQueue.frontIndex.nextNode;
            return data;
        }

        public void Push(int data)
        {
            Stack newNode = new Stack(data);
            if (IsEmptyStack())
            {
                headStack = newNode;
                top++;
                return;
            }
            newNode.nextNode = headStack;
            headStack = newNode;
            top++;
        }

        public int Pop()
        {
            if (IsEmptyStack())
                throw new Exception("Stack is empty");
            int data = headStack.data;
            headStack = headStack.nextNode;
            top--;
            return data;
        }

        public void SequenceOfInterleavePair()
        {
            if (Length % 2 != 0)
                return;
            int halfSize = Length / 2;

            for (int i = 0; i < halfSize; i++)
                Push(DeQueue());

            while (!IsEmptyStack())
                EnQueue(Pop());

            for (int i = 0; i < halfSize; i++)
                EnQueue(DeQueue());

            while (!IsEmptyStack())
            {
                EnQueue(Pop());
                EnQueue(DeQueue());
            }
        }
        public static void Main(string[] args)
        {
            SequenceOfInterleavePairs sequence = new SequenceOfInterleavePairs();
            sequence.EnQueue(11);
            sequence.EnQueue(12);
            sequence.EnQueue(13);
            sequence.EnQueue(14);
            sequence.EnQueue(15);
            sequence.EnQueue(16);
            sequence.EnQueue(17);
            sequence.EnQueue(18);
            sequence.EnQueue(19);
            sequence.EnQueue(20);

            //TODO: Need to work on this function
            sequence.SequenceOfInterleavePair();

            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        private class Queue
        {
            public QueueIndex frontIndex;
            public QueueIndex rearIndex;
        }

        private class QueueIndex
        {
            public int data;
            public QueueIndex nextNode;
            public QueueIndex(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }

        private class Stack
        {
            public int data;
            public Stack nextNode;
            public Stack(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }
    }
}
