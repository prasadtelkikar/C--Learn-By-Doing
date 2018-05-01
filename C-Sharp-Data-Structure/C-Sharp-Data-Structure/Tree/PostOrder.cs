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
        
        #region Stack operations
        private void Push(BinaryTreeNode node)
        {
            //TODO: complete it.
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
