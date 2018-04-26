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

            //Stack = (top) 15 ->14 ->13 -> 12 -> 11 Queue = (front) 16 -> 17 -> 18 -> 19 -> 20 
            for (int i = 0; i < halfSize; i++)
                Push(DeQueue());

            //Queue = 16 ->17 ->18 ->19 ->20 ->15 ->14 ->13 ->12 ->11
            while (!IsEmptyStack())
                EnQueue(Pop());

            //Queue 15 ->14 ->13 ->12 ->11 ->16 ->17 ->18 ->19 ->20
            for (int i = 0; i < halfSize; i++)
                EnQueue(DeQueue());
            
            //Stack 11 -> 12 ->13 ->14 ->15 Queue 16 ->17 ->18 ->19 ->20
            for (int i = 0; i < halfSize; i++)
                Push(DeQueue());

            //Resultant Queue = 11 ->16 ->12 ->17 ->13 ->18 ->19 ->20
            while (!IsEmptyStack())
            {
                //For 11, 12, 13, 14, 15
                EnQueue(Pop());
                //For 16, 17, 18, 19, 20
                EnQueue(DeQueue());
            }
        }

        public void Display()
        {
            QueueIndex iterator = headQueue.frontIndex;
            if (IsEmptyQueue())
            {
                throw new Exception("Empty queue");
            }
            Console.Write("Front ->");
            while(iterator != null)
            {
                Console.Write(iterator.data + " ->");
                iterator = iterator.nextNode;
            }
            Console.Write("End");
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
            sequence.Display();
            //Console.WriteLine("Hello world");
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
