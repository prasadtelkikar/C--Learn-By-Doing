using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindElementFromTree
    {
        private BSTNode rootNode;
        public static void Main(string[] args)
        {
            FindElementFromTree findElement = new FindElementFromTree();
            findElement.rootNode = new BSTNode(1);
            findElement.rootNode.leftNode = new BSTNode(2);
            findElement.rootNode.rightNode = new BSTNode(3);
            findElement.rootNode.leftNode.leftNode = new BSTNode(4);
            findElement.rootNode.leftNode.rightNode = new BSTNode(5);
            findElement.rootNode.rightNode.leftNode = new BSTNode(6);
            findElement.rootNode.rightNode.rightNode = new BSTNode(7);

            bool result = findElement.FindGivenElementFromTree(findElement.rootNode, 3);
            Console.WriteLine(result ? "Element present in tree" : "Element not available in tree");

            Console.ReadKey();
        }

        //Buggy code
        private bool FindGivenElementFromTree(BSTNode rootNode, int data)
        {
            if (rootNode == null)
                return false;
            else
            {
                if (rootNode.data == data)
                    return true;

                if (FindGivenElementFromTree(rootNode.leftNode, data))
                    return true;
                else
                    FindGivenElementFromTree(rootNode.rightNode, data);
            }
            return false;
        }

        #region BST Class
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
        #endregion BST Class
    }
}
