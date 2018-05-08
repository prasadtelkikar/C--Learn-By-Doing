using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindElementNonRecursion
    {
        private BSTNode rootNode;
        private Queue head;
        public FindElementNonRecursion()
        {
            head = new Queue();
            head.frontIndex = null;
            head.rearIndex = null;
        }
        #region BST functions
        public int FindMax()
        {

            int max = int.MinValue;
            //If rootNode is empty means tree is empty return int.MinValue
            if (rootNode != null)
            {
                //Enqueue first element
                EnQueue(rootNode);
                while (!IsQueueEmpty())
                {
                    //Dequeue element
                    BSTNode deQueuedElement = DeQueue();
                    //Compare with max element
                    if (max < deQueuedElement.data)
                        max = deQueuedElement.data;

                    //Enqueue left node
                    if (deQueuedElement.leftNode != null)
                        EnQueue(deQueuedElement.leftNode);

                    //Enqueque right node
                    if (deQueuedElement.rightNode != null)
                        EnQueue(deQueuedElement.rightNode);
                }
            }
            return max;
        }
        #endregion BST functions

        public static void Main(string[] args)
        {
            FindElementNonRecursion findElement = new FindElementNonRecursion();
            
            findElement.rootNode = new BSTNode(1);
            findElement.rootNode.leftNode = new BSTNode(2);
            findElement.rootNode.rightNode = new BSTNode(3);
            findElement.rootNode.leftNode.leftNode = new BSTNode(4);
            findElement.rootNode.leftNode.rightNode = new BSTNode(5);
            findElement.rootNode.rightNode.leftNode = new BSTNode(6);
            findElement.rootNode.rightNode.rightNode = new BSTNode(7);

            int maxValue = findElement.FindMax();
            Console.WriteLine("Max value from tree: " + maxValue);
            //Console.WriteLine("Hello world; TODO: Input binary tree and testing of functions");
            Console.ReadKey();
        }

        #region Queue Operations
        private QueueNode CreateNewNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        public bool IsQueueEmpty()
        {
            return (head.frontIndex == null);
        }

        private void EnQueue(BSTNode data)
        {
            QueueNode newNode = new QueueNode(data);
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
            if (IsQueueEmpty())
            {
                throw new Exception("Empty Queue");
            }
            BSTNode frontNode = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return frontNode;
        }
        #endregion

        #region Queue class
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
        #endregion Queue class

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
    }
}
