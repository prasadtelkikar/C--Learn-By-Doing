using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class PostOrderUsingSingleStack
    {
        private BSTNode rootNode;
        private BSTStack topNode;
        private int top;

        public PostOrderUsingSingleStack()
        {
            rootNode = null;
            topNode = null;
            top = -1;
        }

        #region Binary Search Tree
        private BSTNode CreateNewNode(int data)
        {
            return new BSTNode(data);
        }

        public bool IsTreeEmpty()
        {
            return rootNode == null;
        }

        public void AddNewNodeToTree(int data)
        {
            BSTNode newNode = CreateNewNode(data);
            
            if (IsTreeEmpty())
            {
                rootNode = newNode;
                return;
            }

            BSTNode currentNode = rootNode;
            BSTNode previousNode = null;

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


        //Buggy code. Need to debug.
        public void PostOrderWithSingleStack()
        {
            if (IsTreeEmpty())
                return;

            BSTNode currentNode = rootNode;
            do
            {

                while (currentNode != null)
                {
                    if (currentNode.rightNode != null)
                        Push(currentNode.rightNode);

                    Push(currentNode);

                    currentNode = currentNode.leftNode;
                }

                currentNode = Pop();

                if (currentNode.rightNode != null && !IsEmptyStack() && topNode.data == currentNode)
                {
                    var tempNode = Pop();
                    Push(currentNode);
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    Console.WriteLine(currentNode.data + "-> ");
                    currentNode = null;
                }
            } while (!IsEmptyStack());
        }

        #endregion Binary Search Tree

        #region Stack Operation
        public bool IsEmptyStack()
        {
            return top == -1;
        }

        private BSTStack CreateNewStackNode(BSTNode newNode)
        {
            return new BSTStack(newNode);
        }

        private void Push(BSTNode data)
        {
            BSTStack newNode = new BSTStack(data);

            if (IsEmptyStack())
            {
                topNode = newNode;
                top++;
                return;
            }

            newNode.nextNode = topNode;
            topNode = newNode;
            top++;
        }

        private BSTNode Pop()
        {
            if (IsEmptyStack())
                throw new Exception("Stack underflow");

            BSTNode topBSTNode = topNode.data;
            topNode = topNode.nextNode;
            top--;
            return topBSTNode;
        }

        private BSTNode Peek()
        {
            if (IsEmptyStack())
                throw new Exception("Stack underflow");

            return topNode.data;
        }
        #endregion Stack Operation
        public static void Main(string[] args)
        {

            PostOrderUsingSingleStack postOrder = new PostOrderUsingSingleStack();

            postOrder.AddNewNodeToTree(50);
            postOrder.AddNewNodeToTree(30);
            postOrder.AddNewNodeToTree(70);
            postOrder.AddNewNodeToTree(20);
            postOrder.AddNewNodeToTree(40);
            postOrder.AddNewNodeToTree(60);
            postOrder.AddNewNodeToTree(80);
            postOrder.PostOrderWithSingleStack();
            Console.WriteLine("Hello world");
            Console.ReadLine();
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

        private class BSTStack
        {
            public BSTNode data;
            public BSTStack nextNode;

            public BSTStack(BSTNode data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
    }
}
