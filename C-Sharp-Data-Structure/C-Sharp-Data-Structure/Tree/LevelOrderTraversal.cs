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

        #region constructor
        public LevelOrderTraversal()
        {
            head = new Queue();
            head.frontNode = null;
            head.rearNode = null;
        }
        #endregion constructor
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
                head.rearNode = head.frontNode;
                return;
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

        #region Binary tree operations
        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        public void AddNewNode(int data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(data);
            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }
            BinaryTreeNode previousNode = null;
            BinaryTreeNode currentNode = rootNode;
            while (currentNode != null)
            {
                previousNode = currentNode;
                if (currentNode.data > data)
                    currentNode = currentNode.leftNode;
                else
                    currentNode = currentNode.rightNode;
            }
            if (previousNode.data > data)
                previousNode.leftNode = newNode;
            else
                previousNode.rightNode = newNode;
        }

        public void DisplayLevelOrderTraversal()
        {
            if (head.frontNode != null)
                return;

            BinaryTreeNode temp = rootNode;
            Enqueue(temp);
            while (!IsEmptyQueue())
            {
                BinaryTreeNode deQueuedElement = DeQueue();
                Console.Write(deQueuedElement.data + " ");

                if (deQueuedElement.leftNode != null)
                {
                    //temp = deQueuedElement.
                    Enqueue(deQueuedElement.leftNode);
                }
                if (deQueuedElement.rightNode != null)
                    Enqueue(deQueuedElement.rightNode);
            }
        }
        #endregion Binary tree operations

        #region Main function
        public static void Main(string[] args)
        {
            LevelOrderTraversal levelOrder = new LevelOrderTraversal();
            levelOrder.AddNewNode(50);
            levelOrder.AddNewNode(30);
            levelOrder.AddNewNode(20);
            levelOrder.AddNewNode(40);
            levelOrder.AddNewNode(70);
            levelOrder.AddNewNode(80);
            levelOrder.AddNewNode(60);

            levelOrder.DisplayLevelOrderTraversal();
            Console.ReadKey();
            /* inOrderInstance.InsertNewNode(50);
             inOrderInstance.InsertNewNode(30);
             inOrderInstance.InsertNewNode(20);
             inOrderInstance.InsertNewNode(40);
             inOrderInstance.InsertNewNode(70);
             inOrderInstance.InsertNewNode(80);
             inOrderInstance.InsertNewNode(60);*/
        }
        #endregion Main function

        #region Binary Tree node class
        private class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode leftNode;
            public BinaryTreeNode rightNode;

            public BinaryTreeNode(int data)
            {
                this.data = data;
                leftNode = null;
                rightNode = null;
            }
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
