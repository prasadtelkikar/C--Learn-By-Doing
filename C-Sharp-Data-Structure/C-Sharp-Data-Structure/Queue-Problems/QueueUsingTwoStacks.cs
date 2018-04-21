using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    public class QueueUsingTwoStacks
    {
        private StackNode stack1Head;
        private StackNode stack2Head;
        public QueueUsingTwoStacks()
        {
            stack1Head = null;
            stack2Head = null;
        }
        
        public bool IsStackEmpty(StackNode head)
        {
            return (head == null);
        }

        private StackNode Push(StackNode head, int data)
        {
            StackNode newNode = new StackNode(data);
            if (IsStackEmpty(head))
            {
                head = newNode;
                return head;
            }
            newNode.nextNode = head;
            head = newNode;
            return head;
        }

        private StackNode Pop(StackNode head)
        {
            if (IsStackEmpty(head))
            {
                throw new Exception("Stack is empty");
            }
            head = head.nextNode;
            return head;
        }

        public void EnQueue(int data)
        {
            stack1Head = Push(stack1Head, data);
        }

        public int DeQueue()
        {
            if (IsStackEmpty(stack1Head))
                throw new Exception("Queue is empty");

            StackNode temp = stack1Head;
            int value = 0;
            if (!IsStackEmpty(stack2Head))
            {
                value = stack2Head.data;
                stack2Head = Pop(stack2Head);
                return value;
            }
            else
            {
                while(temp!= null)
                {
                    stack2Head = Push(stack2Head, temp.data);
                    temp = temp.nextNode;
                }
            }
            value = stack2Head.data;
            stack2Head = Pop(stack2Head);
            return value;
        }

        public static void Main(string[] args)
        {
            QueueUsingTwoStacks qUsingStacks = new QueueUsingTwoStacks();
            qUsingStacks.EnQueue(1);
            qUsingStacks.EnQueue(2);
            qUsingStacks.EnQueue(3);
            qUsingStacks.EnQueue(4);
            qUsingStacks.EnQueue(5);

            Console.WriteLine("First popped = " + qUsingStacks.DeQueue());
            Console.WriteLine("Second popped = " + qUsingStacks.DeQueue());
            Console.WriteLine("third popped = " + qUsingStacks.DeQueue());
            Console.WriteLine("fourth popped = " + qUsingStacks.DeQueue());
            Console.WriteLine("fifth popped = " + qUsingStacks.DeQueue());
            //Queue is circular so, it will return 1 as dequeued element
            Console.WriteLine("sixth popped = " + qUsingStacks.DeQueue());
            Console.ReadKey();
        }
        
        public class StackNode
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
