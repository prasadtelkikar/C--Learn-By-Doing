using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class CountHalfNodes
    {
        BSTNode rootNode;
        Queue head;
        public CountHalfNodes()
        {
            head = new Queue();
        }

        #region Queue operations
        public bool IsEmptyQueue()
        {
            return head.frontNode == null;
        }

        private QueueNode CreateNewNode(BSTNode newNode)
        {
            return new QueueNode(newNode);
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

        #region Tree operation
        private int FindHalfNodes(BSTNode rootNode)
        {
            int count = 0;
            if (rootNode == null)
                return -1;
            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                BSTNode tempNode = DeQueue();
                if (tempNode.leftNode != null)
                    EnQueue(tempNode.leftNode);

                if (tempNode.rightNode != null)
                    EnQueue(tempNode.rightNode);

                if ((tempNode.leftNode != null && tempNode.rightNode == null) || (tempNode.leftNode == null && tempNode.rightNode != null))
                    count++;
            }
            return count;
        }
        #endregion Tree operation

        public static void Main(string[] args)
        {
            CountHalfNodes fNodes = new CountHalfNodes();
            fNodes.rootNode = new BSTNode(1);
            fNodes.rootNode.leftNode = new BSTNode(2);
            fNodes.rootNode.rightNode = new BSTNode(3);
            fNodes.rootNode.leftNode.leftNode = new BSTNode(4);
            //fNodes.rootNode.leftNode.rightNode = new BSTNode(5);
            //fNodes.rootNode.rightNode.leftNode = new BSTNode(6);
            fNodes.rootNode.rightNode.rightNode = new BSTNode(7);

            int fullNodes = fNodes.FindHalfNodes(fNodes.rootNode);
            Console.WriteLine(fullNodes == -1 ? "Empty tree" : string.Format("There are {0} half nodes", fullNodes));
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
            public QueueNode frontNode;
            public QueueNode rearNode;
        }
        #endregion Queue

    }
}
