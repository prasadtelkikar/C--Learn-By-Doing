using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree
{
    public class PostOrder
    {
        private BinaryTreeNode bstRoot;
        private StackNode stackTop;
        public int top;
        public PostOrder()
        {
            top = -1;
        }

        #region Stack operations
        public bool IsStackEmpty()
        {
            return (top == -1);
        }

        private void Push(BinaryTreeNode node)
        {
            StackNode newNode = new StackNode(node);
            if (IsStackEmpty())
            {
                stackTop = newNode;
                top++;
                return;
            }
            StackNode oldHead = stackTop;
            newNode.nextNode = oldHead;
            stackTop = newNode;
            top++;
        }

        private BinaryTreeNode Pop()
        {
            if (IsStackEmpty())
                throw new Exception("Stack is empty");
            BinaryTreeNode temp = stackTop.data;
            stackTop = stackTop.nextNode;
            top--;
            return temp;
        }

        #endregion

        #region Queue operations
        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        private void AddNewNode(int data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(data);
            if(bstRoot == null)
            {
                bstRoot = newNode;
                return;
            }
            BinaryTreeNode previousNode = null;
            BinaryTreeNode currentNode = bstRoot;

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

        //PostOrder recursion
        private void RecursivePostOrder(BinaryTreeNode root)
        {
            if(root != null)
            {
                RecursivePostOrder(root.leftNode);
                RecursivePostOrder(root.rightNode);
                Console.Write(root.data + " ");
            }
        }

        //TODO: Non-Recursive appoach 
        public void NonRecursivePostOrder()
        {

        }
        #endregion

        //Tests are remaining
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        #region Private classes
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

        private class StackNode
        {
            public BinaryTreeNode data;
            public StackNode nextNode;

            public StackNode(BinaryTreeNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }

        #endregion private classes
    }
}
