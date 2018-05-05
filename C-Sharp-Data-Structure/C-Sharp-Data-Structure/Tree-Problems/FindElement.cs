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

            int maxValue = findElement.FindMaxElement(findElement.rootNode);
            Console.WriteLine("Max element from tree: " + maxValue);
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
