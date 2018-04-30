using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree
{
    public class InOrder
    {
        private BinaryTreeNode rootNode;
        public InOrder()
        {
            rootNode = null;
        }

        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        //Non recursive insertion
        public void InsertNewNode(int data)
        {
            BinaryTreeNode newNode = CreateNewNode(data);
            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }
            BinaryTreeNode previousNode = null;
            BinaryTreeNode currentNode = rootNode;

            while(currentNode != null)
            {
                previousNode = currentNode;
                if (currentNode.data > data)
                    currentNode = currentNode.leftNode;
                else
                    currentNode = currentNode.rightNode;
            }

            if (previousNode.data > data)
                previousNode.leftNode = newNode;
            else
                previousNode.rightNode = newNode;
        }

        //Recursive function
        private void Inorder(BinaryTreeNode rootNode)
        {
            if(rootNode!= null)
            {
                Inorder(rootNode.leftNode);
                Console.Write(rootNode.data + " ");
                Inorder(rootNode.rightNode);
            }
        }

        public static void Main(string[] args)
        {
            InOrder inOrderInstance = new InOrder();
            inOrderInstance.InsertNewNode(50);
            inOrderInstance.InsertNewNode(30);
            inOrderInstance.InsertNewNode(20);
            inOrderInstance.InsertNewNode(40);
            inOrderInstance.InsertNewNode(70);
            inOrderInstance.InsertNewNode(80);
            inOrderInstance.InsertNewNode(60);

            inOrderInstance.Inorder(inOrderInstance.rootNode);
            //Console.WriteLine("Welcome to world of tree");
            Console.ReadKey();
        }

        private class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode leftNode;
            public BinaryTreeNode rightNode;
            public BinaryTreeNode(int data)
            {
                this.data = data;
                leftNode = null;
                rightNode = null;
            }
        }
    }
}
