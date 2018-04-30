using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree
{
    public class InsertNodeToTree
    {
        private BinaryTreeNode rootNode;
        public InsertNodeToTree()
        {
            rootNode = null;
        }

        private BinaryTreeNode CreatNewNode(int data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(data);
            return newNode;
        }

        //Recursive function to add new node
        private BinaryTreeNode AddNewNode(BinaryTreeNode currentNode,int data)
        {
            BinaryTreeNode newNode = CreatNewNode(data);
            if(currentNode == null)
            {
                return newNode;
            }
            if (data > currentNode.data)
                currentNode.rightNode = AddNewNode(currentNode.rightNode, data);
            else if (data < currentNode.data)
                currentNode.leftNode = AddNewNode(currentNode.leftNode, data);
            return currentNode;
        }

        //https://stackoverflow.com/questions/36795065/binary-search-tree-insertion-c-without-recursion
        //Non recursive function to add new node
        private void AddNewNode(int data)
        {
            BinaryTreeNode newNode = CreatNewNode(data);
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

        private void DisplayTree(BinaryTreeNode currentNode)
        {
            if(currentNode != null)
            {
                DisplayTree(currentNode.leftNode);
                Console.Write(currentNode.data + " ");
                DisplayTree(currentNode.rightNode);
            }
        }

        public static void Main(string[] args)
        {
            InsertNodeToTree insertNodeInstance = new InsertNodeToTree();

            insertNodeInstance.AddNewNode(50);
            insertNodeInstance.AddNewNode(30);
            insertNodeInstance.AddNewNode(20);
            insertNodeInstance.AddNewNode(40);
            insertNodeInstance.AddNewNode(70);
            insertNodeInstance.AddNewNode(60);
            insertNodeInstance.AddNewNode(80);

            insertNodeInstance.DisplayTree(insertNodeInstance.rootNode);
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
