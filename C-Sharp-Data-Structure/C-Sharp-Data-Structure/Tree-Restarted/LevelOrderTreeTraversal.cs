using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class LevelOrderTreeTraversal
    {
        private BSTNode rootNode;
        private Queue head;

        public LevelOrderTreeTraversal()
        {
            rootNode = null;
            head = new Queue();
            head.frontNode = null;
            head.rearNode = null;
        }


        #region Queue Operations
        public bool IsQueueEmpty()
        {
            return head.frontNode == null;
        }

        private QueueNode CreateNewNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        private void Enqueue(BSTNode data)
        {
            QueueNode newQueueNode = CreateNewNode(data);

            if (IsQueueEmpty())
            {
                head.frontNode = newQueueNode;
                head.rearNode = head.frontNode;
                return;
            }

            head.rearNode.nextNode = newQueueNode;
            head.rearNode = head.rearNode.nextNode;

        }

        private BSTNode DeQueue()
        {
            if (IsQueueEmpty())
                throw new Exception("Queue is empty");

            BSTNode currentNode = head.frontNode.data;
            head.frontNode = head.frontNode.nextNode;
            return currentNode;
        }
        #endregion Queue Operations

        #region Binary Search Tree Operation
        private BSTNode CreateNewNode(int data)
        {
            return new BSTNode(data);
        }

        public bool IsEmptyTree()
        {
            return rootNode == null;
        }

        private void AddNewNodeToTree(int data)
        {
            BSTNode newNode = CreateNewNode(data);

            if (IsEmptyTree())
            {
                rootNode = newNode;
                return;
            }

            BSTNode currentNode = rootNode;
            BSTNode previousNode = null;

            while(currentNode != null)
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

            BSTNode currentNode = rootNode;
            Enqueue(currentNode);

            while (!IsQueueEmpty())
            {
                BSTNode latestNode = DeQueue();
                Console.Write(latestNode.data + "-> ");

                if (latestNode.leftNode != null)
                    Enqueue(latestNode.leftNode);

                if (latestNode.rightNode != null)
                    Enqueue(latestNode.rightNode);
            }
            
        }
        #endregion Binary Search Tree Operation

        public static void Main(string[] args)
        {
            LevelOrderTreeTraversal levelOrder = new LevelOrderTreeTraversal();

            levelOrder.AddNewNodeToTree(50);
            levelOrder.AddNewNodeToTree(30);
            levelOrder.AddNewNodeToTree(70);
            levelOrder.AddNewNodeToTree(20);
            levelOrder.AddNewNodeToTree(40);
            levelOrder.AddNewNodeToTree(60);
            levelOrder.AddNewNodeToTree(80);
            levelOrder.DisplayLevelOrderTraversal();

            Console.ReadLine();
        }

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
        }
    }
}
