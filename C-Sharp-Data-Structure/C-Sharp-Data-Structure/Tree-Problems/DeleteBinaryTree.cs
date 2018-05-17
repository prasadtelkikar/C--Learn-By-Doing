using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class DeleteBinaryTree
    {
        BSTNode rootNode;
        public DeleteBinaryTree()
        {
            rootNode = null;
        }

        //TODO: Need to fix it
        private void DeleteBST(BSTNode param)
        {
            if (param == null)
                return;

            DeleteBST(param.leftNode);
            DeleteBST(param.rightNode);
            param = null;
        }

        public bool IsEmptyTree()
        {
            return rootNode == null;
        }

        public static void Main(string[] args)
        {
            DeleteBinaryTree deleteBST = new DeleteBinaryTree();
            deleteBST.rootNode = new BSTNode(1);
            deleteBST.rootNode.leftNode = new BSTNode(2);
            deleteBST.rootNode.rightNode = new BSTNode(3);
            deleteBST.rootNode.leftNode.leftNode = new BSTNode(4);
            deleteBST.rootNode.leftNode.rightNode = new BSTNode(5);
            deleteBST.rootNode.rightNode.leftNode = new BSTNode(6);
            deleteBST.rootNode.rightNode.rightNode = new BSTNode(7);

            deleteBST.DeleteBST(deleteBST.rootNode);

            Console.WriteLine(deleteBST.IsEmptyTree()? "Tree is empty":"Tree is not empty");
            Console.ReadKey();
        }

        #region Binary Search Tree node
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
        #endregion Binary Search Tree node
    }
}
