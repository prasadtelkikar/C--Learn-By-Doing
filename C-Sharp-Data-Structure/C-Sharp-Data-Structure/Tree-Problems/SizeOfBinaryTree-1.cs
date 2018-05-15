using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class SizeOfBinaryTree_1
    {
        private BSTNode rootNode;
        public StringBuilder sb;
        public static void Main(string[] args)
        {
            SizeOfBinaryTree_1 sizeOfBST = new SizeOfBinaryTree_1();
            sizeOfBST.sb = new StringBuilder();
            sizeOfBST.rootNode = new BSTNode(1);
            sizeOfBST.rootNode.leftNode = new BSTNode(2);
            sizeOfBST.rootNode.rightNode = new BSTNode(3);
            sizeOfBST.rootNode.leftNode.leftNode = new BSTNode(4);
            sizeOfBST.rootNode.leftNode.rightNode = new BSTNode(5);
            sizeOfBST.rootNode.rightNode.leftNode = new BSTNode(6);
            sizeOfBST.rootNode.rightNode.rightNode = new BSTNode(7);

            sizeOfBST.SizeFromInfix(sizeOfBST.rootNode);
            int size = sizeOfBST.GetSizeOfTree(sizeOfBST.sb.ToString());
            Console.WriteLine("Size of array is " + size);
            Console.ReadKey();
        }

        private int GetSizeOfTree(string array)
        {
            array = array.TrimEnd();
            int[] arr = Array.ConvertAll(array.Split(' '), int.Parse);
            return arr.Length;
        }

        private void SizeFromInfix(BSTNode rootNode)
        {
            if(rootNode != null)
            {
                SizeFromInfix(rootNode.leftNode);
                sb.Append(rootNode.data + " ");
                SizeFromInfix(rootNode.rightNode);
            }
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
