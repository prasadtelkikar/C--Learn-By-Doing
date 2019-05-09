using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Restarted
{
    public class PostOrderUsingTwoStacks
    {
        private BSTNode rootNode;
        private BSTStack topNode;
        private int top;

        public PostOrderUsingTwoStacks()
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

        private void AddNewNodeToTree(int data)
        {
            BSTNode newNode = CreateNewNode(data);
            BSTNode currentNode = rootNode;
            BSTNode previousNode = null;
            if (currentNode == null)
            {
                rootNode = newNode;
                return;
            }

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

        private void PostOrderRecursive(BSTNode currentNode)
        {
            if(currentNode != null)
            {
                PostOrderRecursive(currentNode.leftNode);
                PostOrderRecursive(currentNode.rightNode);
                Console.Write(currentNode.data + "-> ");
            }
        }

        private Stack<BSTNode> PostOrderNonRecursively()
        {
            Stack<BSTNode> bstStack1 = new Stack<BSTNode>();
            Stack<BSTNode> bstStack2 = new Stack<BSTNode>();

            if (rootNode == null)
                throw new Exception("Empty Tree");

            bstStack1.Push(rootNode);

            while(bstStack1.Count != 0)
            {
                BSTNode topBSTNode = bstStack1.Pop();
                if (topBSTNode.leftNode != null)
                    bstStack1.Push(topBSTNode.leftNode);

                if (topBSTNode.rightNode != null)
                    bstStack1.Push(topBSTNode.rightNode);

                bstStack2.Push(topBSTNode);
            }
            return bstStack2;
        }

        public void DisplayPostOrderTree()
        {
            Stack<BSTNode> reversePostOrder = PostOrderNonRecursively();
            while (reversePostOrder != null && reversePostOrder.Count != 0)
            {
                BSTNode topNode = reversePostOrder.Pop();
                Console.Write(topNode.data + "-> ");
            }
        }

        #endregion Binary Search Tree

        #region Stack Operation
        public bool IsStackEmpty()
        {
            return top == -1;
        }

        private BSTStack CreateNewNode(BSTNode newNode)
        {
            return new BSTStack(newNode);
        }
        private void Push(BSTNode data)
        {
            BSTStack newNode = CreateNewNode(data);

            if (IsStackEmpty())
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
            if (IsStackEmpty())
                throw new Exception("Stack underflow");

            BSTNode topBSTNode = topNode.data;
            topNode = topNode.nextNode;
            top--;
            return topBSTNode;
        }

        #endregion Stack Operation
        public static void Main(string[] args)
        {
            PostOrderUsingTwoStacks postOrder = new PostOrderUsingTwoStacks();

            postOrder.AddNewNodeToTree(50);
            postOrder.AddNewNodeToTree(30);
            postOrder.AddNewNodeToTree(70);
            postOrder.AddNewNodeToTree(20);
            postOrder.AddNewNodeToTree(40);
            postOrder.AddNewNodeToTree(60);
            postOrder.AddNewNodeToTree(80);

            postOrder.DisplayPostOrderTree();
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
                nextNode = null;
            }
        }
    }
}
