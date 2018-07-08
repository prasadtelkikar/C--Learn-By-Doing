using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class SumOfAllNodes
    {
        BSTNode rootNode;

        private int AddNodeValues(BSTNode currentNode)
        {
            if (currentNode == null)
                return 0;

            return (currentNode.data + AddNodeValues(currentNode.leftNode) + AddNodeValues(currentNode.rightNode));
        }


        public static void Main(string[] args)
        {
            SumOfAllNodes sumAllNode = new SumOfAllNodes();
            sumAllNode.rootNode = new BSTNode(1);

            sumAllNode.rootNode.leftNode = new BSTNode(2);
            sumAllNode.rootNode.rightNode = new BSTNode(3);

            sumAllNode.rootNode.leftNode.leftNode = new BSTNode(4);
            sumAllNode.rootNode.leftNode.rightNode = new BSTNode(5);

            sumAllNode.rootNode.rightNode.leftNode = new BSTNode(6);
            sumAllNode.rootNode.rightNode.rightNode = new BSTNode(7);

            int result = sumAllNode.AddNodeValues(sumAllNode.rootNode);
            Console.WriteLine("Sum of all node: " + result);

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
