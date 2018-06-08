using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class DeleteNodeFromBST
    {
        BSTNode rootNode;
        Queue head;

        public DeleteNodeFromBST()
        {
            head = new Queue();
        }

        #region Queue Operations
        public bool IsEmptyQueue()
        {
            return head.front == null;
        }

        private QueueNode CreateNewNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        private void EnQueue(BSTNode node)
        {
            QueueNode newNode = CreateNewNode(node);
            if (IsEmptyQueue())
            {
                head.rear = newNode;
                head.front = head.rear;
                return;
            }
            head.rear.nextNode = newNode;
            head.rear = head.rear.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is empty");

            BSTNode frontNode = head.front.data;
            head.front = head.front.nextNode;
            return frontNode;
        }
        #endregion Queue Operations

        //TODO: Fix issues for this program
        #region BST Operation
        private bool DeleteNode(BSTNode rootNode, int value)
        {
            BSTNode deepestNode = FindDeepNode(rootNode);
            BSTNode nodeToBeDeleted = FindNode(rootNode, value);
            if (nodeToBeDeleted == null)
                return false;

            SwapData(deepestNode, nodeToBeDeleted);
            //Free deepest node
            deepestNode = null;
            return true;
        }

        private void SwapData(BSTNode deepestNode, BSTNode nodeToBeDeleted)
        {
            int temp = deepestNode.data;
            deepestNode.data = nodeToBeDeleted.data;
            nodeToBeDeleted.data = temp;
        }

        private BSTNode FindNode(BSTNode rootNode, int value)
        {
            BSTNode tempNode = null;
            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                tempNode = DeQueue();
                if (tempNode.data == value)
                    return tempNode;

                if (tempNode.leftNode != null)
                    EnQueue(tempNode.leftNode);
                if (tempNode.rightNode != null)
                    EnQueue(tempNode.rightNode);

            }
            return tempNode;
        }

        private BSTNode FindDeepNode(BSTNode rootNode)
        {
            BSTNode tempNode = rootNode;
            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                tempNode = DeQueue();
                if (tempNode.leftNode != null)
                    EnQueue(tempNode.leftNode);
                if (tempNode.rightNode != null)
                    EnQueue(tempNode.rightNode);
            }
            return tempNode;
        }
        #endregion BST Operation

        public static void Main(string[] args)
        {
            DeleteNodeFromBST deleteBST = new DeleteNodeFromBST();
            deleteBST.rootNode = new BSTNode(1);
            deleteBST.rootNode.leftNode = new BSTNode(2);
            deleteBST.rootNode.rightNode = new BSTNode(3);
            deleteBST.rootNode.leftNode.leftNode = new BSTNode(4);
            deleteBST.rootNode.leftNode.rightNode = new BSTNode(5);
            deleteBST.rootNode.rightNode.leftNode = new BSTNode(6);
            deleteBST.rootNode.rightNode.rightNode = new BSTNode(7);

            deleteBST.DeleteNode(deleteBST.rootNode, 4);
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
            public QueueNode front = null;
            public QueueNode rear = null;
        }
        #endregion Queue
    }
}
