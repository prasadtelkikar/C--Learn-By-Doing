using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindHeightOfTreeNonRecursive
    {
        BSTNode rootNode;
        Queue head;

        public FindHeightOfTreeNonRecursive()
        {
            head = new Queue();
            head.front = null;
            head.rear = null;
        }

        #region QueueOperation
        private QueueNode CreateNewNode(BSTNode newNode)
        {
            return new QueueNode(newNode);
        }
        public bool IsQueueEmpty()
        {
            return (head.front == null);
        }
        private void EnQueue(BSTNode newNode)
        {
            QueueNode newQNode = CreateNewNode(newNode);
            if(IsQueueEmpty())
            {
                head.rear = newQNode;
                head.front = head.rear;
                return;
            }
            head.rear.nextNode = newQNode;
            head.rear = head.rear.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsQueueEmpty())
            {
                throw new Exception("Queue is empty");
            }
            BSTNode dQueueNode = head.front.data;
            head.front = head.front.nextNode;
            return dQueueNode;
        }
        #endregion QueueOperation

        #region TreeOperation
        //Logic behind this code(count null in queue) : 1 -> null -> 2 -> 3 -> null ->  4 -> 5 -> 6 -> 7 -> null
        private int FindHeight(BSTNode rootNode)
        {
            int levelCount = 0;
            EnQueue(rootNode);
            EnQueue(null);
            while (!IsQueueEmpty())
            {
                BSTNode frontNode = DeQueue();
                if (frontNode == null)
                {
                    if (!IsQueueEmpty())
                        EnQueue(null);
                    levelCount++;
                }
                else
                {
                    if (frontNode.leftNode != null)
                        EnQueue(frontNode.leftNode);
                    if (frontNode.rightNode != null)
                        EnQueue(frontNode.rightNode);
                }
            }
            return levelCount;
        }
        #endregion TreeOperation
        public static void Main(string[] args)
        {
            FindHeightOfTreeNonRecursive findHeight = new FindHeightOfTreeNonRecursive();
            findHeight.rootNode = new BSTNode(1);
            findHeight.rootNode.leftNode = new BSTNode(2);
            findHeight.rootNode.rightNode = new BSTNode(3);
            findHeight.rootNode.leftNode.leftNode = new BSTNode(4);
            findHeight.rootNode.leftNode.rightNode = new BSTNode(5);
            findHeight.rootNode.rightNode.leftNode = new BSTNode(6);
            findHeight.rootNode.rightNode.rightNode = new BSTNode(7);

            int result = findHeight.FindHeight(findHeight.rootNode);
            Console.WriteLine("Height of tree is : " + result);
            Console.ReadKey();
        }
        //TODO: Complete non recusive find height of tree function
        #region BST
        private class BSTNode
        {
            public int data;
            public BSTNode leftNode;
            public BSTNode rightNode;

            public BSTNode(int data)
            {
                this.data = data;
                leftNode = null;
                rightNode = null;
            }
        }
        #endregion BST

        #region Queue
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
            public QueueNode front;
            public QueueNode rear;
        }
        #endregion Queue
    }
}
