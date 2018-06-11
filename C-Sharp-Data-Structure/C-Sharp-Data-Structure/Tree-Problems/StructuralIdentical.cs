using System;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class StructuralIdentical
    {
        BSTNode rootNode;

        private bool IsTreeIdentical(BSTNode rootNode1, BSTNode rootNode2)
        {
            if (rootNode1 == null && rootNode2 == null)
                return true;

            if (rootNode1 == null || rootNode2 == null)
                return false;

            return (rootNode1.Equals(rootNode2) &&
                IsTreeIdentical(rootNode1.leftNode, rootNode2.leftNode) &&
                IsTreeIdentical(rootNode1.rightNode, rootNode2.rightNode));
        }


        public static void Main(string[] args)
        {
            StructuralIdentical si1 = new StructuralIdentical();
            si1.rootNode = new BSTNode(1);
            si1.rootNode.leftNode = new BSTNode(2);
            si1.rootNode.rightNode = new BSTNode(3);
            si1.rootNode.leftNode.leftNode = new BSTNode(4);
            si1.rootNode.leftNode.rightNode = new BSTNode(5);
            si1.rootNode.rightNode.leftNode = new BSTNode(6);
            si1.rootNode.rightNode.rightNode = new BSTNode(7);

            StructuralIdentical si2 = new StructuralIdentical();
            si2.rootNode = new BSTNode(1);
            si2.rootNode.leftNode = new BSTNode(2);
            si2.rootNode.rightNode = new BSTNode(3);
            si2.rootNode.leftNode.leftNode = new BSTNode(4);
            si2.rootNode.leftNode.rightNode = new BSTNode(5);
            si2.rootNode.rightNode.leftNode = new BSTNode(6);
            si2.rootNode.rightNode.rightNode = new BSTNode(7);

            bool result = si1.IsTreeIdentical(si1.rootNode, si2.rootNode);
            Console.WriteLine(result ? "Both trees are identical":"Trees are not identical");
            Console.ReadKey();
        }

        #region BST
        private class BSTNode : IEquatable<BSTNode>
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

            public override bool Equals(object obj)
            {
                return Equals(obj as BSTNode);
            }

            public bool Equals(BSTNode node)
            {
                if (this == null && node == null)
                    return true;

                else if ((leftNode == null && node.leftNode == null) || (rightNode == null && node.rightNode == null))
                    return true;

                else if ((leftNode != null && node.leftNode == null) || (rightNode != null && node.rightNode == null)
                    || (leftNode == null && node.leftNode != null) || (rightNode == null && node.rightNode != null))
                    return false;

                else if ((data == node.data
                    && leftNode.data == node.leftNode.data
                    && rightNode.data == node.rightNode.data))
                    return true;
                else
                    return false;
            }
        }
        #endregion BST
    }
}
