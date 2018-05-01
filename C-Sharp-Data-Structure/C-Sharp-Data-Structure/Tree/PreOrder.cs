using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree
{
    public class PreOrder
    {
        private BinaryTreeNode rootNode;
        private StackNode stackHead;
        public int top;
        public PreOrder()
        {
            rootNode = null;
            stackHead = null;
            top = -1;
        }

        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        #region Tree Operations
        private void AddNewNode(int data)
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

        //Recursive attempt of PreOrder root - left - right
        private void PreOrderTraversal(BinaryTreeNode rootNode)
        {
            if(rootNode != null)
            {
                Console.Write(rootNode.data + " ");
                PreOrderTraversal(rootNode.leftNode);
                PreOrderTraversal(rootNode.rightNode);
            }
        }

       //Non recursive attempt of PreOrder
       private void NonRecursivePreOrder(BinaryTreeNode rootNode)
       {
            while (true)
            {
                while (rootNode!= null)
                {
                    //Process current node
                    Console.Write(rootNode.data + " ");
                    Push(rootNode);

                    //Move left
                    rootNode = rootNode.leftNode;
                }
                if (IsStackEmpty())
                    break;
                
                rootNode = Pop();
                //Move right
                rootNode = rootNode.rightNode;
            }
       }
#endregion Tree Operations

        #region Stack Operations
        public bool IsStackEmpty()
        {
            return (top == -1);
        }

        private void Push(BinaryTreeNode newTreeNode)
        {
            StackNode newNode = new StackNode(newTreeNode);
            if (IsStackEmpty())
            {
                stackHead = newNode;
                top++;
                return;
            }
            StackNode oldHead = stackHead;
            stackHead = new StackNode(newTreeNode);
            stackHead.newNode = oldHead;
            top++;
        }

        private BinaryTreeNode Pop()
        {
            if (IsStackEmpty())
            {
                throw new Exception("Stack underflow");
            }

            BinaryTreeNode temp = stackHead.data;
            stackHead = stackHead.newNode;
            top--;
            return temp;
        }
        #endregion Stack Operations

        public static void Main(string[] args)
        {
            PreOrder preOrderInstance = new PreOrder();


            preOrderInstance.AddNewNode(50);
            preOrderInstance.AddNewNode(30);
            preOrderInstance.AddNewNode(20);
            preOrderInstance.AddNewNode(40);
            preOrderInstance.AddNewNode(70);
            preOrderInstance.AddNewNode(60);
            preOrderInstance.AddNewNode(80);

            preOrderInstance.PreOrderTraversal(preOrderInstance.rootNode);
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
            public StackNode newNode;
            public StackNode(BinaryTreeNode data)
            {
                this.data = data;
                newNode = null;
            }
        }
    }
}
