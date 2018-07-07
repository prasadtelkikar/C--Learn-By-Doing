using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class CheckSumInPath
    {
        BSTNode rootNode;
        int sum;
        public CheckSumInPath(int sum)
        {
            rootNode = null;
            this.sum = sum;
        }

        private bool CheckPathSum(BSTNode currentNode)
        {
            if (currentNode == null)
                return sum == 0;

            sum -= currentNode.data;

            if ((currentNode.leftNode != null && currentNode.rightNode != null) || (currentNode.leftNode == null && currentNode.rightNode == null))
                return (CheckPathSum(currentNode.leftNode) || CheckPathSum(currentNode.rightNode));

            if (currentNode.leftNode != null)
                return CheckPathSum(currentNode.leftNode);
            else
                return CheckPathSum(currentNode.rightNode);

        }

        public static void Main(string[] args)
        {
            CheckSumInPath isSumAvailable = new CheckSumInPath(7);
            isSumAvailable.rootNode = new BSTNode(1);

            isSumAvailable.rootNode.leftNode = new BSTNode(2);
            isSumAvailable.rootNode.rightNode = new BSTNode(3);

            isSumAvailable.rootNode.leftNode.leftNode = new BSTNode(4);  //1 + 2 + 4 == 7
            isSumAvailable.rootNode.leftNode.rightNode = new BSTNode(5);

            isSumAvailable.rootNode.rightNode.leftNode = new BSTNode(6);
            isSumAvailable.rootNode.rightNode.rightNode = new BSTNode(7);

            Console.WriteLine(isSumAvailable.CheckPathSum(isSumAvailable.rootNode) ? "Available" : "Not available");
            
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
                leftNode = null;
                rightNode = null;
            }
        }
    }
}
