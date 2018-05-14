using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class InsertNewElementToTree
    {
        Queue head;
        BSTNode rootNode;

        public InsertNewElementToTree()
        {
            head = new Queue();
            head.frontIndex = null;
            head.rearIndex = null;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        public bool IsQueueEmpty()
        {
            return head.frontIndex == null;
        }

        private QueueNode CreateNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        private void EnQueue(BSTNode newNode)
        {
            if (IsQueueEmpty())
            {
                head.rearIndex.data = newNode;
                head.frontIndex = head.rearIndex;
                return;
            }

            head.rearIndex.nextNode = CreateNode(newNode);
            head.rearIndex = head.rearIndex.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsQueueEmpty())
            {
                throw new Exception("Queue underflow");
            }
            BSTNode temp = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return temp;
        }
        public void InsertNewNode(int data)
        {

        }
        private class QueueNode
        {
            public BSTNode data;
            public QueueNode nextNode;
            public QueueNode(BSTNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }

        private class Queue
        {
            public QueueNode frontIndex;
            public QueueNode rearIndex;
        }

        private class BSTNode
        {
            public int data;
            public BSTNode nextNode;
            public BSTNode(int data)
            {
                this.data = data;
                nextNode = null;
            }
        }
    }
}
