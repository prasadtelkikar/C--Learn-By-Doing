using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class SizeOfBinaryTree
    {
        private BSTNode rootNode;

        public static void Main(string[] args)
        {
            SizeOfBinaryTree sizeBT = new SizeOfBinaryTree();
            sizeBT.rootNode = new BSTNode(1);
            sizeBT.rootNode.leftNode = new BSTNode(2);
            sizeBT.rootNode.rightNode = new BSTNode(3);
            sizeBT.rootNode.leftNode.leftNode = new BSTNode(4);
            sizeBT.rootNode.leftNode.rightNode = new BSTNode(5);
            sizeBT.rootNode.rightNode.leftNode = new BSTNode(6);
            sizeBT.rootNode.rightNode.rightNode = new BSTNode(7);

            int size = sizeBT.FindSizeOfBST(sizeBT.rootNode);
            Console.WriteLine("Size of Binary search tree is " + size);
            Console.ReadKey();
        }

        private int FindSizeOfBST(BSTNode rootNode)
        {
            if (rootNode == null)
                return 0;

            return (FindSizeOfBST(rootNode.leftNode) + 1 + FindSizeOfBST(rootNode.rightNode));
        }

        private class BSTNode
        {
            public int data;
            public BSTNode leftNode;
            public BSTNode rightNode;

            public BSTNode(int data)
            {
                this.data = data;
                this.leftNode = null;
                this.rightNode = null;
            }
        }
    }
}
