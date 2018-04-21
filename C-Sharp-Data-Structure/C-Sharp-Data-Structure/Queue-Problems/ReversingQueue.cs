using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class ReversingQueue
    {
        private Queue headQueue;
        private StackNode headStack;
        public ReversingQueue()
        {
            headQueue = new Queue();
            headStack = null;
            headQueue.frontNode = null;
            headQueue.rearNode = null;
        }

        public bool IsEmptyStack()
        {
            return (headStack == null);
        }

        public bool IsEmptyQueue()
        {
            return (headQueue.frontNode == null);
        }

        public void EnQueue(int data)
        {
            QueueNode newNode = new QueueNode(data);
            if (IsEmptyQueue())
            {
                headQueue.rearNode = newNode;
                headQueue.frontNode = headQueue.rearNode;
            }
            else
            {
                headQueue.rearNode.nextNode = newNode;
                headQueue.rearNode = headQueue.rearNode.nextNode;
            }
        }
        
        public int DeQueue()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Empty queue");
                return 0;
            }
            int data = headQueue.frontNode.data;
            headQueue.frontNode = headQueue.frontNode.nextNode;
            return data;
        }

        public void Push(int data)
        {
            StackNode oldHead = headStack;
            headStack = new StackNode(data);
            headStack.nextNode = oldHead;
        }

        public int Pop()
        {
            if (IsEmptyStack())
            {
                Console.WriteLine("Empty stack");
                return 0;
            }
            int data = headStack.data;
            headStack = headStack.nextNode;
            return data;
        }

        private void ReverseQueue(QueueNode qNode)
        {
            while (!IsEmptyQueue())
            {
                int dqElement = DeQueue();
                Push(dqElement);
            }
            while (!IsEmptyStack())
            {
                int topStack = Pop();
                EnQueue(topStack);
            }
        }

        public void Display()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Empty queue");
                return;
            }
            Console.Write("Front -> ");
            QueueNode temp = headQueue.frontNode;
            do
            {
                Console.Write(temp.data + " -> ");
                temp = temp.nextNode;
            } while (temp != null);
            Console.WriteLine("Rear");
        }

        public static void Main(string[] args)
        {
            ReversingQueue revQueue = new ReversingQueue();
            revQueue.EnQueue(1);
            revQueue.EnQueue(2);
            revQueue.EnQueue(3);
            revQueue.EnQueue(4);
            revQueue.EnQueue(5);
            revQueue.EnQueue(6);

            //Front -> 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> Rear
            revQueue.Display();

            int dq1 = revQueue.DeQueue();
            int dq2 = revQueue.DeQueue();

            //Front -> 3 -> 4 -> 5 -> 6 -> Rear
            revQueue.Display();

            revQueue.ReverseQueue(revQueue.headQueue.frontNode);
            
            //Front -> 6 -> 5 -> 4 -> 3 -> Rear
            revQueue.Display();
            Console.ReadKey();
        }
        private class QueueNode
        {
            public int data;
            public QueueNode nextNode;
            public QueueNode(int data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
        private class Queue
        {
            public QueueNode frontNode;
            public QueueNode rearNode;
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
