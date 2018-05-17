using System;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class LevelOrderReverse
    {
        BSTNode rootNode;
        StackNode stackHead;
        Queue queueHead;
        public LevelOrderReverse()
        {
            queueHead = new Queue
            {
                frontNode = null,
                rearNode = null
            };

            stackHead = null;
            rootNode = null;
        }

        #region Queue Operations
        public bool IsEmptyQueue()
        {
            return queueHead.frontNode == null;
        }

        private void EnQueue(BSTNode newNode)
        {
            QueueNode newQNode = new QueueNode(newNode);
            if (IsEmptyQueue())
            {
                queueHead.rearNode = newQNode;
                queueHead.frontNode = queueHead.rearNode;
                return;
            }

            queueHead.rearNode.nextNode = newQNode;
            queueHead.rearNode = queueHead.rearNode.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is empty");

            BSTNode temp = queueHead.frontNode.data;
            queueHead.frontNode = queueHead.frontNode.nextNode;
            return temp;
        }
        #endregion Queue Operations

        #region Stack Operation
        public bool IsStackEmpty()
        {
            return stackHead == null;
        }

        private void Push(BSTNode newNode)
        {
            StackNode newSNode = new StackNode(newNode);

            if(IsStackEmpty())
            {
                stackHead = newSNode;
                return;
            }

            newSNode.nextNode = stackHead;
            stackHead = newSNode;
        }

        private BSTNode Pop()
        {
            if (IsStackEmpty())
                throw new Exception("Stack is empty");
            BSTNode temp = stackHead.data;
            stackHead = stackHead.nextNode;
            return temp;
        }
        #endregion

        #region BST Operation
        public void LevelOrderTreeReverse()
        {
            if (rootNode == null)
                return;

            EnQueue(rootNode);
            while (!IsEmptyQueue())
            {
                BSTNode temp = DeQueue();

                if (temp.rightNode != null)
                    EnQueue(temp.rightNode);

                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);

                /* To Make fully reversible use following code instead of above two conditions
                 * 
                if (temp.rightNode != null)
                    EnQueue(temp.rightNode);

                if (temp.leftNode != null)
                    EnQueue(temp.leftNode);
                 */

                Push(temp);
            }

            while (!IsStackEmpty())
            {
                BSTNode topNode = Pop();
                Console.Write(topNode.data + " ");
            }
        }
        #endregion BST Operation

        public static void Main(string[] args)
        {
            LevelOrderReverse levelReverse = new LevelOrderReverse();
            levelReverse.rootNode = new BSTNode(1);
            levelReverse.rootNode.leftNode = new BSTNode(2);
            levelReverse.rootNode.rightNode = new BSTNode(3);
            levelReverse.rootNode.leftNode.leftNode = new BSTNode(4);
            levelReverse.rootNode.leftNode.rightNode = new BSTNode(5);
            levelReverse.rootNode.rightNode.leftNode = new BSTNode(6);
            levelReverse.rootNode.rightNode.rightNode = new BSTNode(7);

            levelReverse.LevelOrderTreeReverse();
            Console.ReadKey();
        }

        #region Stack
        private class StackNode
        {
            public BSTNode data;
            public StackNode nextNode;

            public StackNode(BSTNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }
        #endregion

        #region Queue 
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
            public QueueNode frontNode;
            public QueueNode rearNode;
        }
        #endregion

        #region Binary Tree
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
        #endregion
    }
}
