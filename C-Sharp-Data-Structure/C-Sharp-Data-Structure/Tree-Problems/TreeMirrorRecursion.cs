using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class TreeMirrorRecursion
    {
        BSTNode rootNode;

        private BSTNode MirrorByRecursion(BSTNode currentNode)
        {
            if (currentNode == null)
                return null;

            BSTNode newNode = new BSTNode(currentNode.data);
            newNode.leftNode = MirrorByRecursion(currentNode.rightNode);
            newNode.rightNode = MirrorByRecursion(currentNode.leftNode);

            return newNode;
        }
        public static void Main(string[] args)
        {
            TreeMirrorRecursion treeMirror = new TreeMirrorRecursion();

            treeMirror.rootNode = new BSTNode(1);

            treeMirror.rootNode.leftNode = new BSTNode(2);
            treeMirror.rootNode.rightNode = new BSTNode(3);

            treeMirror.rootNode.leftNode.leftNode = new BSTNode(4);
            treeMirror.rootNode.leftNode.rightNode = new BSTNode(5);

            treeMirror.rootNode.rightNode.leftNode = new BSTNode(6);
            treeMirror.rootNode.rightNode.rightNode = new BSTNode(7);

            BSTNode mirrorTreeRootNode = treeMirror.MirrorByRecursion(treeMirror.rootNode);
            //TODO: Tree structure print remaining

            Console.WriteLine("hello world");
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
