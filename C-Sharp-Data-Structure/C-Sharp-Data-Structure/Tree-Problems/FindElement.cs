using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class FindElement
    {
        private BSTNode rootNode;
        public StringBuilder sb;

        public FindElement()
        {
            sb = new StringBuilder();
        }

        private int FindMaxElement(BSTNode currentNode)
        {
            int max = int.MinValue;
            int rootValue, leftNodeValue, rightNodeValue;

            if (currentNode != null)
            {
                rootValue = currentNode.data;
                leftNodeValue = FindMaxElement(currentNode.leftNode);
                rightNodeValue = FindMaxElement(currentNode.rightNode);

                if (leftNodeValue > rightNodeValue)
                    max = leftNodeValue;
                else
                    max = rightNodeValue;

                if (rootValue > max)
                    max = rootValue;
            }
            return max;
        }

        private int? FindMaxElementUsingInfixOrder(BSTNode root)
        {
            InfixOrder(root);
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                //Trim is used to remove last empty space.
                int[] treeElements = Array.ConvertAll(sb.ToString().Trim().Split(' '), int.Parse);
                return treeElements.Max();
            }
            return null;
        }

        private void InfixOrder(BSTNode root)
        {
            if(root != null)
            {
                InfixOrder(root.leftNode);
                sb.Append(root.data+" ");
                Console.WriteLine(root.data + " ");
                InfixOrder(root.rightNode);
            }
        }

        public static void Main(string[] args)
        {
            FindElement findElement = new FindElement();
            findElement.rootNode = new BSTNode(1);

            findElement.rootNode.leftNode = new BSTNode(2);
            findElement.rootNode.rightNode = new BSTNode(3);

            findElement.rootNode.leftNode.leftNode = new BSTNode(4);
            findElement.rootNode.leftNode.rightNode = new BSTNode(5);

            findElement.rootNode.rightNode.leftNode = new BSTNode(6);
            findElement.rootNode.rightNode.rightNode = new BSTNode(7);

            //int maxValue = findElement.FindMaxElement(findElement.rootNode);
            int? maxValueIO = findElement.FindMaxElementUsingInfixOrder(findElement.rootNode);
            Console.WriteLine(maxValueIO.HasValue ? string.Format("{0} is max element from tree", maxValueIO) : "Processing error");

            //Console.WriteLine("Max element from tree: " + maxValue);
            Console.ReadKey();
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
