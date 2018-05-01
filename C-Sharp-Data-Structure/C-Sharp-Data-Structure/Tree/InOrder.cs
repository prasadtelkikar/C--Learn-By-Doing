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
        private StackNode stackRootNode;
        public int top;
        public InOrder()
        {
            rootNode = null;
            stackRootNode = null;
            top = -1;
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

        public bool IsEmptyStack()
        {
            return (top == -1);
        }

        private void Push(BinaryTreeNode newNode)
        {
            if (IsEmptyStack())
            {
                stackRootNode.data = newNode;
                top++;
                return;
            }
            StackNode oldHead = stackRootNode;
            stackRootNode = new StackNode(newNode);
            stackRootNode.nextNode = oldHead;
            top++;
        }

        private BinaryTreeNode Pop()
        {
            if (IsEmptyStack())
            {
                throw new Exception("Stack underflow");
            }
            BinaryTreeNode headNode = stackRootNode.data;
            stackRootNode = stackRootNode.nextNode;
            top--;
            return headNode;
        }

        private void InorderTraversal(BinaryTreeNode rootNode)
        {
            while (true)
            {
                while (rootNode != null)
                {
                    Push(rootNode);
                    rootNode = rootNode.leftNode;
                }

                if (IsEmptyStack())
                    break;

                BinaryTreeNode root = Pop();
                Console.Write(root.data+ " ");
                root = root.rightNode;
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
        
        private class StackNode
        {
            public BinaryTreeNode data;
            public StackNode nextNode;
            public StackNode(BinaryTreeNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }
    }
}
