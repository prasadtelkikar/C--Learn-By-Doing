using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class PreOrder
    {
        private BinaryTreeNode rootNode;
        private BinaryStackNode stackHead;
        public int top;

        public PreOrder()
        {
            rootNode = null;
            stackHead = null;
            top = -1;
        }

        public static void Main(string[] args)
        {
            PreOrder preOrderInstance = new PreOrder();
            preOrderInstance.AddNewNode(50);
            preOrderInstance.AddNewNode(30);
            preOrderInstance.AddNewNode(20);
            preOrderInstance.AddNewNode(40);
            preOrderInstance.AddNewNode(70);
            preOrderInstance.AddNewNode(60);
            preOrderInstance.AddNewNode(80);

            preOrderInstance.PreOrderTraversalNonRecursive(preOrderInstance.rootNode);
            Console.WriteLine();
            Console.ReadKey();
        }

#region Tree Operations
        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }
        private void AddNewNode(int data)
        {
            BinaryTreeNode newTreeNode = CreateNewNode(data);

            if (rootNode == null)
            {
                rootNode = newTreeNode;
                return;
            }

            BinaryTreeNode previousBinaryNode = null;
            BinaryTreeNode currentBinaryNode = rootNode;

            while(currentBinaryNode != null)
            {
                previousBinaryNode = currentBinaryNode;

                if (previousBinaryNode.data > data)
                    currentBinaryNode = currentBinaryNode.leftNode;
                else
                    currentBinaryNode = currentBinaryNode.rightNode;
            }
            if (previousBinaryNode.data > data)
                previousBinaryNode.leftNode = newTreeNode;
            else
                previousBinaryNode.rightNode = newTreeNode;
        }


        private void PreOrderTraversal(BinaryTreeNode currentTreeNode)
        {
            if (currentTreeNode != null)
            {
                Console.Write(currentTreeNode.data + "-> ");
                PreOrderTraversal(currentTreeNode.leftNode);
                PreOrderTraversal(currentTreeNode.rightNode);
            }
        }

        private void PreOrderTraversalNonRecursive(BinaryTreeNode binaryTreeNode)
        {
            while (true)
            {
                while(binaryTreeNode != null)
                {
                    Console.Write(binaryTreeNode.data + "-> ");
                    Push(binaryTreeNode);

                    binaryTreeNode = binaryTreeNode.leftNode;
                }
                if (IsStackEmpty())
                    break;
                binaryTreeNode = Pop();
                binaryTreeNode = binaryTreeNode.rightNode;
            }
        }
        #endregion Tree Operation

        #region Stack Operations
        public bool IsStackEmpty()
        {
            return top == -1;
        }

        private void Push(BinaryTreeNode binaryTreeNode)
        {
            BinaryStackNode stackNode = new BinaryStackNode(binaryTreeNode);

            if (IsStackEmpty())
            {
                stackHead = stackNode;
                top++;
                return;
            }

            BinaryStackNode oldStackNode = stackHead;
            stackNode.nextData = oldStackNode;
            stackHead = stackNode;
            top++;
        }

        private BinaryTreeNode Pop()
        {
            if (IsStackEmpty())
                throw new Exception("Stack underflow");

            BinaryTreeNode topNode = stackHead.data;
            stackHead = stackHead.nextData;
            top--;
            return topNode;

        }
        #endregion Stack Operations

        private class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode leftNode;
            public BinaryTreeNode rightNode;

            public BinaryTreeNode(int data)
            {
                this.data = data;
                this.leftNode = null;
                this.rightNode = null;
            }
        }

        private class BinaryStackNode
        {
            public BinaryTreeNode data;
            public BinaryStackNode nextData;

            public BinaryStackNode(BinaryTreeNode data)
            {
                this.data = data;
                this.nextData = null;
            }
        }
    }
}
