using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue
{
    public class QueueDynamicArrayImplementation
    {
        DynamicQueue head;
        public QueueDynamicArrayImplementation(int size)
        {
            head = new DynamicQueue(size);
        }
        public bool IsEmptyQueue()
        {
            return head.rear == -1;
        }
        public bool IsFullQueue()
        {
            return ((head.rear + 1) % head.array.Length == head.front);
        }

        public void EnQueue(int data)
        {
            if (IsFullQueue())
            {
                ResizeQueue();
            }
            head.rear = (head.rear + 1) % head.array.Length;
            head.array[head.rear] = data;
            if (head.front == -1)
                head.front = head.rear;
        }
        
        public int DeQueue()
        {
            if(IsEmptyQueue())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            int data = head.array[head.front];
            if (head.front == head.rear)
                head.front = head.rear = -1;
            else
                head.front = (head.front + 1) % head.array.Length;
            return data;
        }
        private void ResizeQueue()
        {
            int size = head.array.Length;
            int capacity = (head.array.Length*2);
            int[] temp = (int[])head.array.Clone();
            head.array = new int[capacity];

            if(head.front < head.rear)
            {
                for (int i = 0; i <= head.rear; i++)
                {
                    head.array[i + size] = temp[i];
                }
                head.front = size;
                head.rear += size;
            }
        }

        public static void Main(string[] args)
        {
            QueueDynamicArrayImplementation queueDynamic = new QueueDynamicArrayImplementation(3);
            //Will Print Size of queue
            Console.WriteLine("Initial size queue = "+queueDynamic.head.array.Length);
            queueDynamic.EnQueue(1);
            queueDynamic.EnQueue(2);
            queueDynamic.EnQueue(3);
            //Will resize size of array
            queueDynamic.EnQueue(4);
            queueDynamic.EnQueue(5);
            Console.WriteLine("size queue after resize= " + queueDynamic.head.array.Length);
            //Will Print Size of queue
            Console.Write("Front-> "+queueDynamic.DeQueue());
            Console.Write("-> "+ queueDynamic.DeQueue());
            Console.WriteLine("-> " + queueDynamic.DeQueue());
            Console.ReadKey();
        }

        private class DynamicQueue
        {
            public int front, rear;
            public int[] array;
            public DynamicQueue(int size)
            {
                front = rear = -1;
                array = new int[size];
            }
        }
    }

}
