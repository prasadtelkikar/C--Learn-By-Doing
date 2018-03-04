using System;
using System.Text;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    class StackLinkedList
    {
        int top;
        StackNode head;

        public StackLinkedList()
        {
            top = -1;
        }

        public bool IsEmptyStack()
        {
            return (top == -1);
        }
        
        private StackNode CreateStackNode(char data)
        {
            return new StackNode(data);
        }

        public void Push(char data)
        {
            StackNode oldHead = head;
            head = CreateStackNode(data);
            head.nextNode = oldHead;
            top++;
        }

        public char Pop()
        {
            if (head == null)
                throw new Exception("Underflow");

            char data = head.data;
            head = head.nextNode;
            top--;
            return data;
        }

        public override string ToString()
        {
            if (top == -1)
                return "strack = []";
            else
            {
                Console.WriteLine("*****Stack from top to bottom*****");
                StringBuilder sb = new StringBuilder();
                sb.Append("stack = [");

                StackNode iterator = head;
                while(iterator.nextNode != null)
                {
                    sb.Append(iterator.data + ", ");
                    iterator = iterator.nextNode;
                }
                sb.Append(iterator.data + "]");
                return sb.ToString();
            }
        }

        private class StackNode
        {
            public char data;
            public StackNode nextNode;
            
            public StackNode(char data)
            {
                this.data = data;
                nextNode = null;
            }
        }
        
        public static void Main(string[] args)
        {
            StackLinkedList stackLinkedList = new StackLinkedList();
            stackLinkedList.Push('1');
            stackLinkedList.Push('2');
            stackLinkedList.Push('3');
            stackLinkedList.Push('4');

            Console.WriteLine(stackLinkedList.ToString());
            //Console.WriteLine(stackLinkedList.Pop());
            //Console.WriteLine(stackLinkedList.Pop());
            //Console.WriteLine(stackLinkedList.Pop());
            //Console.WriteLine(stackLinkedList.Pop());
            //Console.WriteLine(stackLinkedList.Pop());
            Console.ReadKey();
        }
    }
}
