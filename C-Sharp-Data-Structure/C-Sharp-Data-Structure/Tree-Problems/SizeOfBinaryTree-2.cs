using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class SizeOfBinaryTree_2
    {
        private Queue head;
        private BSTNode rootNode;
        
        public SizeOfBinaryTree_2()
        {
            head = new Queue();
            head.frontIndex = null;
            head.rearNode = null;
        }

        public bool IsQueueEmpty()
        {
            return head.frontIndex == null;
        }

        private void EnQueue(BSTNode newNode)
        {
            QueueNode newQNode = new QueueNode(newNode);

            if (IsQueueEmpty())
            {
                head.rearNode = newQNode;
                head.frontIndex = head.rearNode;
                return;
            }
            head.rearNode.nextNode = newQNode;
            head.rearNode = head.rearNode.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsQueueEmpty())
            {
                throw new Exception("Queue is empty");
            }

            BSTNode temp = head.frontIndex.data;
            head.frontIndex = head.frontIndex.nextNode;
            return temp;
        }

        public int FindSizeOfBinaryTree()
        {
            int count = 0;
            if (rootNode == null)
                return count;

            EnQueue(rootNode);
            while (!IsQueueEmpty())
            {
                BSTNode temp = DeQueue();
                count++;
                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);
                if (temp.rightNode != null)
                    EnQueue(temp.rightNode);
            }
            return count;
        }

        public static void Main(string[] args)
        {
            SizeOfBinaryTree_2 sizeOfBST = new SizeOfBinaryTree_2();
            sizeOfBST.rootNode = new BSTNode(1);
            sizeOfBST.rootNode.leftNode = new BSTNode(2);
            sizeOfBST.rootNode.rightNode = new BSTNode(3);
            sizeOfBST.rootNode.leftNode.leftNode = new BSTNode(4);
            sizeOfBST.rootNode.leftNode.rightNode = new BSTNode(5);
            sizeOfBST.rootNode.rightNode.leftNode = new BSTNode(6);
            sizeOfBST.rootNode.rightNode.rightNode = new BSTNode(7);

            int size = sizeOfBST.FindSizeOfBinaryTree();
            Console.WriteLine("Size of binary tree is "+size);
            Console.ReadKey();
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
                nextNode = null;
            }
        }
        
        private class Queue
        {
            public QueueNode frontIndex;
            public QueueNode rearNode;
        }
    }
}
