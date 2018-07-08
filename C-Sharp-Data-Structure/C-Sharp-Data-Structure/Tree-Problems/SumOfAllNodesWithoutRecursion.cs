using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class SumOfAllNodesWithoutRecursion
    {
        BSTNode rootNode;
        Queue queue;
        public SumOfAllNodesWithoutRecursion()
        {
            queue = new Queue();
        }

        #region Queue operations
        private QueueNode CreateNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        public bool IsEmptyQueue()
        {
            return queue.frontNode == null;
        }

        private void Enqueue(BSTNode node)
        {
            QueueNode newNode = CreateNode(node);
            if (IsEmptyQueue())
            {
                queue.rearNode = newNode;
                queue.frontNode = queue.rearNode;
            }
            else
            {
                queue.rearNode.nextNode = newNode;
                queue.rearNode = queue.rearNode.nextNode;
            }
        }

        private BSTNode Dequeue()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Queue is empty");
                return null;
            }
            BSTNode firstOut = queue.frontNode.data;
            queue.frontNode = queue.frontNode.nextNode;

            return firstOut;
        }
        #endregion Queue operations

        private int FindSum(BSTNode root)
        {
            int sum = 0;
            if (root == null)
                return sum;
            else
            {
                Enqueue(root);
                while (!IsEmptyQueue())
                {
                    BSTNode currentNode = Dequeue();
                    sum += currentNode.data;

                    if (currentNode.leftNode != null)
                        Enqueue(currentNode.leftNode);

                    if (currentNode.rightNode != null)
                        Enqueue(currentNode.rightNode);
                }
            }
            return sum;
        }

        public static void Main(string[] args)
        {

            SumOfAllNodesWithoutRecursion sumAllNodeWORecusion = new SumOfAllNodesWithoutRecursion();
            sumAllNodeWORecusion.rootNode = new BSTNode(1);

            sumAllNodeWORecusion.rootNode.leftNode = new BSTNode(2);
            sumAllNodeWORecusion.rootNode.rightNode = new BSTNode(3);

            sumAllNodeWORecusion.rootNode.leftNode.leftNode = new BSTNode(4);
            sumAllNodeWORecusion.rootNode.leftNode.rightNode = new BSTNode(5);

            sumAllNodeWORecusion.rootNode.rightNode.leftNode = new BSTNode(6);
            sumAllNodeWORecusion.rootNode.rightNode.rightNode = new BSTNode(7);

            int result = sumAllNodeWORecusion.FindSum(sumAllNodeWORecusion.rootNode);
            Console.WriteLine("Sum of all node without recursion: " + result);
            
            Console.ReadKey();
        }

        #region BSTNode and Queue Classes
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

        private class QueueNode
        {
            public BSTNode data;
            public QueueNode nextNode;

            public QueueNode(BSTNode data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }

        private class Queue
        {
            public QueueNode frontNode;
            public QueueNode rearNode;

            public Queue()
            {
                frontNode = null;
                rearNode = null;
            }
        }
        #endregion BSTNode and Queue Classes
    }
}
