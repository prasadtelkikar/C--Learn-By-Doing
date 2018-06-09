using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class NumberOfLeavesNonRecursive
    {
        private Queue head;
        private BSTNode rootNode;
        public NumberOfLeavesNonRecursive()
        {
            head = new Queue();
            head.frontNode = null;
            head.rearNode = null;
        }

        #region Queue operations
        public bool IsEmptyQueue()
        {
            return head.frontNode == null;
        }
        private QueueNode CreateNewNode(BSTNode node)
        {
            return new QueueNode(node);
        }

        private void EnQueue(BSTNode node)
        {
            QueueNode newNode = CreateNewNode(node);
            if (IsEmptyQueue())
            {
                head.rearNode = newNode;
                head.frontNode = head.rearNode;
                return;
            }
            head.rearNode.nextNode = newNode;
            head.rearNode = head.rearNode.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is empty");

            BSTNode frontNode = head.frontNode.data;
            head.frontNode = head.frontNode.nextNode;
            return frontNode;
        }
        #endregion Queue operations

        #region BST Operation
        private int CountLeaves(BSTNode rootNode)
        {
            int count = 0;
            if (rootNode == null)
                return -1;
            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                BSTNode temp = DeQueue();
                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);
                if (temp.rightNode != null)
                    EnQueue(temp.rightNode);
                if (temp.leftNode == null && temp.rightNode == null)
                    count++;
                    
            }
            return count;
        }
        #endregion BST Operation
        public static void Main(string[] args)
        {
            NumberOfLeavesNonRecursive noLeaves = new NumberOfLeavesNonRecursive();
            noLeaves.rootNode = new BSTNode(1);
            noLeaves.rootNode.leftNode = new BSTNode(2);
            noLeaves.rootNode.rightNode = new BSTNode(3);
            noLeaves.rootNode.leftNode.leftNode = new BSTNode(4);
            noLeaves.rootNode.leftNode.rightNode = new BSTNode(5);
            noLeaves.rootNode.rightNode.leftNode = new BSTNode(6);
            noLeaves.rootNode.rightNode.rightNode = new BSTNode(7);

            int noOfLeaves = noLeaves.CountLeaves(noLeaves.rootNode);
            Console.WriteLine(noOfLeaves == -1 ? "Empty tree" : string.Format("There are {0} leaf nodes",noOfLeaves));
            Console.ReadKey();
        }

        #region BST
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
        #endregion BST

        #region Queue
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
            public QueueNode frontNode = null;
            public QueueNode rearNode = null;
        }
        #endregion Queue
    }
}
