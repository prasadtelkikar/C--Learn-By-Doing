using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindHeightOfTree
    {
        BSTNode rootNode;

        public FindHeightOfTree()
        {
            rootNode = null;
        }

        public static void Main(string[] args)
        {
            FindHeightOfTree findheight = new FindHeightOfTree();
            findheight.rootNode = new BSTNode(1);
            findheight.rootNode.leftNode = new BSTNode(2);
            findheight.rootNode.rightNode = new BSTNode(3);
            findheight.rootNode.leftNode.leftNode = new BSTNode(4);
            findheight.rootNode.leftNode.rightNode = new BSTNode(5);
            findheight.rootNode.rightNode.leftNode = new BSTNode(6);
            findheight.rootNode.rightNode.rightNode = new BSTNode(7);
            int height = findheight.FindTreeHeight(findheight.rootNode);
            Console.WriteLine("Height of tree: " + height);

            Console.ReadKey();
        }

        private int FindTreeHeight(BSTNode bstNode)
        {
            int leftHeight = 0;
            int rightHeight = 0;

            if (bstNode == null)
                return 0;
            else
            {
                leftHeight = FindTreeHeight(bstNode.leftNode);
                rightHeight = FindTreeHeight(bstNode.rightNode);

                return ((rightHeight > leftHeight) ? (rightHeight + 1) : (leftHeight + 1));
            }
        }

        #region BSTNode
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
        #endregion BSTNode
    }
}
