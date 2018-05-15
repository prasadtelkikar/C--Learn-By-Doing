using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class InsertNewElementToTree
    {
        Queue head;
        BSTNode rootNode;

        public InsertNewElementToTree()
        {
            head = new Queue();
            head.frontIndex = null;
            head.rearIndex = null;
        }

        public bool IsQueueEmpty()
        {
            return head.frontIndex == null;
        }

        private QueueNode CreateNode(BSTNode data)
        {
            return new QueueNode(data);
        }

        private void EnQueue(BSTNode newNode)
        {
            QueueNode newQNode = new QueueNode(newNode);
            if (IsQueueEmpty())
            {
                head.rearIndex = newQNode;
                head.frontIndex = head.rearIndex;
                return;
            }

            head.rearIndex.nextNode = CreateNode(newNode);
            head.rearIndex = head.rearIndex.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsQueueEmpty())
            {
                throw new Exception("Queue underflow");
            }
            BSTNode temp = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return temp;
        }

        public void InsertNewNode(int data)
        {
            BSTNode newNode = new BSTNode(data);

            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }
            EnQueue(rootNode);
            while (!IsQueueEmpty())
            {
                BSTNode temp = DeQueue();
                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);
                else
                {
                    temp.leftNode = newNode;
                    return;
                }

                if(temp.rightNode != null)
                    EnQueue(temp.rightNode);
                else
                {
                    temp.rightNode = newNode;
                    return;
                }
            }
        }

        public static void Main(string[] args)
        {
            InsertNewElementToTree insertToTree = new InsertNewElementToTree();
            insertToTree.rootNode = new BSTNode(1);
            insertToTree.rootNode.leftNode = new BSTNode(2);
            insertToTree.rootNode.rightNode = new BSTNode(3);
            insertToTree.rootNode.leftNode.leftNode = new BSTNode(4);
            insertToTree.rootNode.leftNode.rightNode = new BSTNode(5);
            insertToTree.rootNode.rightNode.leftNode = new BSTNode(6);
            insertToTree.rootNode.rightNode.rightNode = new BSTNode(7);

            insertToTree.InsertNewNode(10);
            insertToTree.DisplayTreeInfixOrder(insertToTree.rootNode);
            Console.WriteLine("End");
            Console.ReadKey();
        }

        private void DisplayTreeInfixOrder(BSTNode rootNode)
        {
            if(rootNode!= null)
            {
                DisplayTreeInfixOrder(rootNode.leftNode);
                Console.Write(rootNode.data + " ->");
                DisplayTreeInfixOrder(rootNode.rightNode);
            }
        }

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
    }
}
