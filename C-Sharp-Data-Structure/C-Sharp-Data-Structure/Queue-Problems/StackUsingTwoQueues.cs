using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class StackUsingTwoQueues
    {
        private Stack headStack; 
        public StackUsingTwoQueues()
        {
            headStack = new Stack();
        }

        private bool IsEmptyQueue(Queue head)
        {
            return (head.frontIndex == null);
        }

        private Queue EnQueue(Queue head, int data)
        {
            QueueNode node = new QueueNode(data);
            if (IsEmptyQueue(head))
            {
                head.rearIndex = node;
                head.frontIndex = head.rearIndex;
                return head;
            }
            head.rearIndex.nextNode = node;
            head.rearIndex = head.rearIndex.nextNode;
            return head;
        }
        
        private int DeQueue(Queue head)
        {
            if (IsEmptyQueue(head))
            {
                throw new Exception("Empty queue");
            }
            int data = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return data;
        }
        public void Push(int data)
        {
            if (IsEmptyQueue(headStack.firstQueueHead))
                headStack.secondQueueHead = EnQueue(headStack.secondQueueHead, data);
            else
                headStack.firstQueueHead = EnQueue(headStack.firstQueueHead, data);
        }

        private int Pop(Stack stackElement)
        {
            if (IsEmptyQueue(stackElement.secondQueueHead))
            {
                int size = SizeOfQueue(stackElement.firstQueueHead);
                for (int i = 0; i < size; i++)
                {
                    stackElement.secondQueueHead = EnQueue(stackElement.secondQueueHead, DeQueue(stackElement.firstQueueHead));
                }
                return DeQueue(stackElement.secondQueueHead);
            }
            else
            {
                int size = SizeOfQueue(stackElement.secondQueueHead);
                for (int i = 0; i < size; i++)
                {
                    stackElement.firstQueueHead = EnQueue(stackElement.firstQueueHead, DeQueue(stackElement.secondQueueHead));
                }
                return DeQueue(stackElement.firstQueueHead);
            }
        }
        private int SizeOfQueue(Queue head)
        {
            if (IsEmptyQueue(head))
                return 0;

            QueueNode temp = head.frontIndex;
            int length = 0;
            while(temp!= null)
            {
                temp = temp.nextNode;
                length++;
            }
            return length;
        }

        public static void Main(string[] args)
        {
            StackUsingTwoQueues stack2Queue = new StackUsingTwoQueues();
            stack2Queue.Push(1);
            stack2Queue.Push(2);
            stack2Queue.Push(3);
            stack2Queue.Push(4);

            //4 ->3 ->2 ->1
            Console.WriteLine("First popped element: "+stack2Queue.Pop(stack2Queue.headStack));
            Console.WriteLine("Second popped element: " + stack2Queue.Pop(stack2Queue.headStack));
            Console.WriteLine("Third popped element: " + stack2Queue.Pop(stack2Queue.headStack));
            Console.WriteLine("Fourth popped element: " + stack2Queue.Pop(stack2Queue.headStack));
            
            Console.WriteLine("Fifth popped element: " + stack2Queue.Pop(stack2Queue.headStack));

            Console.ReadKey();
        }

        private class Stack
        {
            public Queue firstQueueHead;
            public Queue secondQueueHead;
            public Stack()
            {
                firstQueueHead = new Queue();
                secondQueueHead = new Queue();
            }
        }
        private class Queue
        {
            public QueueNode frontIndex;
            public QueueNode rearIndex;
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
    }
}
