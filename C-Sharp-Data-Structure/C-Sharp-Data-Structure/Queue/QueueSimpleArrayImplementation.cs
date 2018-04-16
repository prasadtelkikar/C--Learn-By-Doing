using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue
{
    public class QueueSimpleArrayImplementation
    {
        private ArrayQueue head;
        public QueueSimpleArrayImplementation(int size)
        {
            head = new ArrayQueue(size);
        }

        public bool IsEmptyQueue()
        {
            return head.rear == -1;
        }
        public bool IsFullQueue()
        {
            return ((head.rear + 1) % head.capacity == head.front);
        }
        public int QueueSize()
        {
            return head.capacity - (head.front + head.rear + 1) % head.capacity;
        }

        public void EnQueue(int data)
        {
            //head.front = 0;
            if (IsFullQueue())
            {
                Console.WriteLine("Queue is full");
            }
            else
            {
                head.rear = (head.rear + 1) % head.capacity;
                head.array[head.rear] = data;
            }
        }

        public int DeQueue()
        {

            if (IsEmptyQueue())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            int value = head.array[head.front+1];
            if (head.front == head.rear)
                head.front = head.rear = -1;
            else
                head.front = (head.front + 1) % head.capacity;
            return value;
        }

        public void DisplayQueue()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                int frontIndex = head.front;
                int rearIndex = head.rear;
                Console.Write("Front ->");
                do
                {
                    frontIndex = frontIndex + 1;
                    Console.Write(head.array[frontIndex] + " ->");
                } while (frontIndex != rearIndex);
                Console.WriteLine("Rear");
            }
        }

        public static void Main(string[] args)
        {
            QueueSimpleArrayImplementation queue = new QueueSimpleArrayImplementation(10);
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.EnQueue(4);
            queue.EnQueue(5);
            queue.EnQueue(6);
            queue.EnQueue(7);
            queue.EnQueue(8);
            //front -> 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> rear
            queue.DeQueue(); //Dequeue 1
            queue.DeQueue(); //Dequeue 2
            queue.DeQueue(); //Dequeue 3
            //front -> 4 -> 5 -> 6 -> 7 -> 8 -> rear
            queue.DisplayQueue();
            Console.ReadKey();
        }
        private class ArrayQueue
        {
            public int front, rear;
            public int capacity;
            public int[] array;
            
            //Creating empty/default queue
            public ArrayQueue(int size)
            {
                array = new int[size];
                capacity = size;
                front = rear = -1;
            }
        }
    }
}
