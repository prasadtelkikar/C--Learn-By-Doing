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
        public PreOrder()
        {
            rootNode = null;
        }

        private BinaryTreeNode CreateNewNode(int data)
        {
            return new BinaryTreeNode(data);
        }

        private void AddNewNode(int data)
        {
            BinaryTreeNode newNode = CreateNewNode(data);
            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }
            BinaryTreeNode previousNode = null;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to tree");
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
