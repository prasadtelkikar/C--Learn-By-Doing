using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindDeepestNode
    {
        Queue head;
        BSTNode rootNode;
        public FindDeepestNode()
        {
            head = new Queue();
            head.front = null;
            head.rear = null;
        }

        #region QueueOperations
        private QueueNode CreateNewNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        public bool IsEmptyQueue()
        {
            return head.front == null;
        }

        private void EnQueue(BSTNode newNode)
        {
            QueueNode newQNode = CreateNewNode(newNode);
            if (IsEmptyQueue())
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
            if (IsEmptyQueue())
                throw new Exception("Empty queue");

            BSTNode frontNode = head.front.data;
            head.front = head.front.nextNode;
            return frontNode;
        }
        #endregion QueueOperations

        #region TreeOperations
        private int FindDeepNode(BSTNode rootNode)
        {
            int deepestNode = rootNode.data;
            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                var temp = DeQueue();
                deepestNode = temp.data;
                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);
                if (temp.rightNode != null)
                    EnQueue(temp.rightNode);
            }
            return deepestNode;
        }
        #endregion TreeOpeations
        public static void Main(string[] args)
        {
            FindDeepestNode findDeepNode = new FindDeepestNode();
            findDeepNode.rootNode = new BSTNode(1);
            findDeepNode.rootNode.leftNode = new BSTNode(2);
            findDeepNode.rootNode.rightNode = new BSTNode(3);
            findDeepNode.rootNode.leftNode.leftNode = new BSTNode(4);
            findDeepNode.rootNode.leftNode.rightNode = new BSTNode(5);
            findDeepNode.rootNode.rightNode.leftNode = new BSTNode(6);
            findDeepNode.rootNode.rightNode.rightNode = new BSTNode(7);

            int deepestNode = findDeepNode.FindDeepNode(findDeepNode.rootNode);
            Console.WriteLine("DeepestNode in tree = " + deepestNode);
            Console.ReadKey();
        }

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
            public QueueNode front;
            public QueueNode rear;
        }
        #endregion Queue

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
        #endregion
    }
}
