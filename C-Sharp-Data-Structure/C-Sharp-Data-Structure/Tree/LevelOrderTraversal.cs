using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree
{
    public class LevelOrderTraversal
    {
        private BinaryTreeNode rootNode;
        private Queue head;

        #region Queue Operations

        public bool IsEmptyQueue()
        {
            return (head.frontNode == null);
        }

        private void Enqueue(BinaryTreeNode newNode)
        {
            QueueNode newQueueNode = new QueueNode(newNode);
            if (IsEmptyQueue())
            {
                head.frontNode = newQueueNode;
                head.rearNode.data = newNode;
            }
            head.rearNode.nextNode = newQueueNode;
            head.rearNode = head.rearNode.nextNode;
        }

        private BinaryTreeNode DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is empty");
            BinaryTreeNode firstNode = head.frontNode.data;
            head.frontNode = head.frontNode.nextNode;
            return firstNode;
        }

        #endregion Queue Operations
        //TODO
        #region Tree
        #region Binary Tree node class
        private class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode leftNode;
            public BinaryTreeNode rightNode;
        }
        #endregion  Binary Tree node class

        #region Queue class
        private class QueueNode
        {
            public BinaryTreeNode data;
            public QueueNode nextNode;
            
            public QueueNode(BinaryTreeNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }
        
        private class Queue
        {
            public QueueNode frontNode;
            public QueueNode rearNode;
        }
        #endregion  Queue class
    }
}
