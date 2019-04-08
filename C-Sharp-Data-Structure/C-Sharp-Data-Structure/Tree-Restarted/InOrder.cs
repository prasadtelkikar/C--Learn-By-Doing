using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class InOrder
    {

        private BinaryTreeNode rootNode;
        private StackNode topNode;
        private int top;

        #region Constructor
        public InOrder()
        {
            rootNode = null;
            topNode = null;
            top = -1;
        }
        #endregion Constructor

        #region Entry point
        public static void Main(string[] args)
        {

            InOrder inOrderTraversal = new InOrder();
            inOrderTraversal.AddNewNode(50);
            inOrderTraversal.AddNewNode(30);
            inOrderTraversal.AddNewNode(40);
            inOrderTraversal.AddNewNode(20);

            inOrderTraversal.AddNewNode(70);
            inOrderTraversal.AddNewNode(60);
            inOrderTraversal.AddNewNode(80);

            inOrderTraversal.InOrderTraversalNonRecursive();

            Console.ReadLine();
        }
        #endregion Entry point

        #region Tree Operation
        private BinaryTreeNode CreateNewBinaryTreeNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        private void InOrderTraversalRecursive(BinaryTreeNode currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraversalRecursive(currentNode.leftNode);
                Console.Write(currentNode.data + "-> ");
                InOrderTraversalRecursive(currentNode.rightNode);
            }
        }

        public void InOrderTraversalNonRecursive()
        {
            BinaryTreeNode currentBinaryNode = rootNode;
            while (true)
            {
                while (currentBinaryNode != null)
                {
                    Push(currentBinaryNode);
                    currentBinaryNode = currentBinaryNode.leftNode;
                }

                if (IsEmptyStack())
                    break;

                currentBinaryNode = Pop();

                Console.Write(currentBinaryNode.data + "-> ");

                currentBinaryNode = currentBinaryNode.rightNode;
            }
        }
        private void AddNewNode(int data)
        {
            BinaryTreeNode newNode = CreateNewBinaryTreeNode(data);
            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }

            BinaryTreeNode previousNode = null;
            BinaryTreeNode currentNode = rootNode;

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

        #endregion Tree Operations

        #region Stack operations
        private StackNode CreateStackNode(BinaryTreeNode data)
        {
            return new StackNode(data);
        }

        private void Push(BinaryTreeNode currentNode)
        {
            StackNode newNode = CreateStackNode(currentNode);

            if (IsEmptyStack())
            {
                topNode = newNode;
                top++;
                return;
            }

            newNode.nextNode = topNode;
            topNode = newNode;
            top++;
        }

        private BinaryTreeNode Pop()
        {
            if (IsEmptyStack())
            {
                throw new Exception("Stack Underflow");
            }

            BinaryTreeNode headNode = topNode.data;
            topNode = topNode.nextNode;
            top--;
            return headNode;
        }

        public bool IsEmptyStack()
        {
            return top == -1;
        }


        #endregion Stack operation

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

        private class StackNode
        {
            public BinaryTreeNode data;
            public StackNode nextNode;

            public StackNode(BinaryTreeNode data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
    }
}
