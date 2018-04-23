using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class KElementReverse
    {
        private Stack headStack;
        private Queue headQueue;
        private int top;
        public KElementReverse()
        {
            top = -1;
            headQueue = new Queue();
        }
        
        public bool IsEmptyStack()
        {
            return (top == -1);
        }

        public bool IsEmptyQueue()
        {
            return (headQueue.frontIndex == null);
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

        public void EnQueue(int data)
        {
            QueueIndex newNode = new QueueIndex(data);
            if (IsEmptyQueue())
            {
                headQueue.rearIndex = newNode;
                headQueue.frontIndex = headQueue.rearIndex;
            }

            headQueue.rearIndex.nextNode = newNode;
            headQueue.rearIndex = headQueue.rearIndex.nextNode;
        }

        public int DeQueue()
        {
            if (IsEmptyQueue())
            {
                throw new Exception("Empty queue");
            }
            int data = headQueue.frontIndex.data;
            headQueue.frontIndex = headQueue.frontIndex.nextNode;
            return data;
        }
        
        public static void Main(string[] args)
        {
            KElementReverse kthElement = new KElementReverse();
            Console.WriteLine("Enter array as a queue");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < arr.Length; i++)
            {
                kthElement.EnQueue(arr[i]);
            }
            Console.WriteLine("Enter size to reverse from front");
            int kthLength = Convert.ToInt32(Console.ReadLine());
            //Need to complete function over here
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
            public QueueIndex nextNode;
            public QueueIndex(int data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
    }
}
