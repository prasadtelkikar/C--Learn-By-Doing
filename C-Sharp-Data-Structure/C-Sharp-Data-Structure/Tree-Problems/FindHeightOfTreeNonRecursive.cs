using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindHeightOfTreeNonRecursive
    {
        BSTNode rootNode;
        public static void Main(string[] args)
        {
            FindHeightOfTreeNonRecursive findHeight = new FindHeightOfTreeNonRecursive();
            findHeight.rootNode = new BSTNode(1);
            findHeight.rootNode.leftNode = new BSTNode(1);
            findHeight.rootNode.rightNode = new BSTNode(1);
            findHeight.rootNode.leftNode.leftNode = new BSTNode(1);
            findHeight.rootNode.leftNode.rightNode = new BSTNode(1);
            findHeight.rootNode.rightNode.leftNode = new BSTNode(1);
            findHeight.rootNode.rightNode.rightNode = new BSTNode(1);
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
        //TODO: Complete non recusive find height of tree function
        #region BST
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
        #endregion BST
    }
}
