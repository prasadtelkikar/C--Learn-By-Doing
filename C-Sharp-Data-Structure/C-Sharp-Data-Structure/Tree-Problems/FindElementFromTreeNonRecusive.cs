using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindElementFromTreeNonRecusive
    {
        Queue head;
        BSTNode rootNode;
        public FindElementFromTreeNonRecusive()
        {
            head = new Queue();
            head.frontIndex = null;
            head.rearIndex = null;
        }

        private void EnQueue(BSTNode data)
        {
            QueueNode newNode = CreateNode(data);
            if (IsQueueEmpty())
            {
                head.rearIndex = newNode;
                head.frontIndex = head.rearIndex;
                return;
            }
            head.rearIndex.nextNode = newNode;
            head.rearIndex = head.rearIndex.nextNode;
        }

        private BSTNode DeQueue()
        {
            if(IsQueueEmpty())
            {
                throw new Exception("Stack is empty");
            }
            BSTNode element = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return element;
        }

        public bool IsQueueEmpty()
        {
            return head.frontIndex == null;
        }

        private QueueNode CreateNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        public bool FindGivenElement(int data)
        {
            if (rootNode == null)
                return false;

            EnQueue(rootNode);
            while (!IsQueueEmpty())
            {
                BSTNode dQueuedElement = DeQueue();
                if (dQueuedElement.data == data)
                    return true;

                if (dQueuedElement.leftNode != null)
                    EnQueue(dQueuedElement.leftNode);

                if (dQueuedElement.rightNode != null)
                    EnQueue(dQueuedElement.rightNode);
            }
            return false;
        }

        public static void Main(string[] args)
        {
            FindElementFromTreeNonRecusive findElement = new FindElementFromTreeNonRecusive();
            findElement.rootNode = new BSTNode(1);
            findElement.rootNode.leftNode = new BSTNode(2);
            findElement.rootNode.rightNode = new BSTNode(3);
            findElement.rootNode.leftNode.leftNode = new BSTNode(4);
            findElement.rootNode.leftNode.rightNode = new BSTNode(5);
            findElement.rootNode.rightNode.leftNode = new BSTNode(6);
            findElement.rootNode.rightNode.rightNode = new BSTNode(7);

            Console.WriteLine(findElement.FindGivenElement(5) ? "5 is present in tree" : "5 is not present in tree");
            Console.ReadKey();
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
            public BSTNode leftNode;
            public BSTNode rightNode;

            public BSTNode(int data)
            {
                this.data = data;
                this.leftNode = null;
                this.rightNode = null;
            }
        }
    }
}
