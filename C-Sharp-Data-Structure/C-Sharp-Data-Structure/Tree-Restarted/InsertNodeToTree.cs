using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class InsertNodeToTree
    {
        private BinaryTreeNode rootNode;

        public InsertNodeToTree()
        {
            rootNode = null;
        }

        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        private bool IsTreeEmpty()
        {
            return rootNode == null;
        }
        public void AddNewNode(int data)
        {
            BinaryTreeNode newNode = CreateNewNode(data);
            if (IsTreeEmpty())
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

        private BinaryTreeNode AddNewNode(BinaryTreeNode currentNode, int data)
        {
            BinaryTreeNode newNode = CreateNewNode(data);

            if(currentNode == null)
            {
                rootNode = newNode;
                return rootNode;
            }

            if (currentNode.data > data)
                currentNode.leftNode = AddNewNode(currentNode.leftNode, data);
            else
                currentNode.rightNode = AddNewNode(currentNode.rightNode, data);

            return currentNode;
        }

        private void Display(BinaryTreeNode currentNode)
        {
            if(currentNode != null)
            {
                Display(currentNode.leftNode);
                Console.Write(currentNode.data + "-> ");
                Display(currentNode.rightNode);
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

            insertNodeInstance.Display(insertNodeInstance.rootNode);
            Console.ReadLine();
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
