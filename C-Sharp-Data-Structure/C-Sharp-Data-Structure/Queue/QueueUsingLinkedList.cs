using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue
{
    public class QueueUsingLinkedList
    {
        Queue head;
        public QueueUsingLinkedList()
        {
            head = new Queue();
            head.front = null;
            head.rear = null;
        }
        public bool IsEmptyQueue()
        {
            return (head.front == null);
        }

        public void EnQueue(int data)
        {
            QueueNode newNode = new QueueNode(data);
            
            //If queue is empty
            if (IsEmptyQueue())
            {
                head.rear = newNode;
                head.front = head.rear;
            }
            else
            {
                head.rear.nextNode = newNode;
                head.rear = head.rear.nextNode;
            }
        }

        public int DeQueue()
        {
            int data;
            //If queue is empty
            if (IsEmptyQueue())
            {
                Console.WriteLine("Queue is empty");
                return int.MinValue;
            }
            data = head.front.data;
            head.front = head.front.nextNode;
            return data;
        }

        public void Display()
        {
            QueueNode temp = head.front;
            if (IsEmptyQueue())
            {
                Console.WriteLine("Empty queue");
                return;
            }
            Console.Write("\nFront");
            do
            {
                Console.Write(" ->" + temp.data);
                temp = temp.nextNode;
            } while (temp != head.rear);
            Console.Write(" ->"+ temp.data + " -> Rear");
        }

        public static void Main(string[] args)
        {
            QueueUsingLinkedList queueLinkedList = new QueueUsingLinkedList();
            queueLinkedList.EnQueue(1);
            queueLinkedList.EnQueue(2);
            queueLinkedList.EnQueue(3);
            queueLinkedList.EnQueue(4);
            queueLinkedList.EnQueue(5);
            queueLinkedList.EnQueue(6);
            
            //Front -> 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> Rear
            queueLinkedList.Display();
            int dq1 = queueLinkedList.DeQueue();
            int dq2 = queueLinkedList.DeQueue();

            //Front -> 3 -> 4 -> 5 -> 6 -> Rear
            queueLinkedList.Display();
            Console.ReadKey();
        }

        private class QueueNode
        {
            public int data;
            public QueueNode nextNode;
            public QueueNode(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }
        private class Queue
        {
            public QueueNode front;
            public QueueNode rear;
        }
    }
}
