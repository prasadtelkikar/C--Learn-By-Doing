using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class PrintRootToLeafPath
    {
        BSTNode rootNode;
        List<int> rootToLeaf;
        public PrintRootToLeafPath()
        {
            rootNode = null;
            rootToLeaf = new List<int>();
        }

        private void FindRootToLeaf(BSTNode currentNode)
        {
            if (currentNode == null)
                return;

            rootToLeaf.Add(currentNode.data);

            if (currentNode.leftNode == null && currentNode.rightNode == null)
            {
                DisplayPath();
            }
            else
            {
                FindRootToLeaf(currentNode.leftNode);
                FindRootToLeaf(currentNode.rightNode);
            }
        }

        public void DisplayPath()
        {
            foreach (int item in rootToLeaf)
            {
                Console.Write(item + "-> ");
            }
        }

        public static void Main(string[] args)
        {
            PrintRootToLeafPath printRootToLeaf = new PrintRootToLeafPath();
            printRootToLeaf.rootNode = new BSTNode(1);

            printRootToLeaf.rootNode.leftNode = new BSTNode(2);
            printRootToLeaf.rootNode.rightNode = new BSTNode(3);

            printRootToLeaf.rootNode.leftNode.leftNode = new BSTNode(4);
            printRootToLeaf.rootNode.leftNode.rightNode = new BSTNode(5);

            printRootToLeaf.rootNode.rightNode.leftNode = new BSTNode(6);
            printRootToLeaf.rootNode.rightNode.rightNode = new BSTNode(7);

            printRootToLeaf.FindRootToLeaf(printRootToLeaf.rootNode);
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        private class BSTNode
        {
            public int data;
            public BSTNode rightNode;
            public BSTNode leftNode;

            public BSTNode(int data)
            {
                this.data = data;
                rightNode = null;
                leftNode = null;
            }
        }
    }
}
