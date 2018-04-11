using System;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class RemoveAdjacent
    {
        int top;
        Node head;
        public RemoveAdjacent()
        {
            top = -1;
        }
        public bool IsStackEmpty()
        {
            return top == -1;
        }

        private Node CreateNode(char data)
        {
            return new Node(data);
        }

        public void Push(char data)
        {
            if (IsStackEmpty())
                head = CreateNode(data);
            else
            {
                Node newNode = CreateNode(data);
                newNode.nextNode = head;
                head = newNode;
            }
            top++;
        }

        public char Pop()
        {
            if (IsStackEmpty())
            {
                Console.WriteLine("Stack underflow");
                return ' ';
            }
            else
            {
                char value = head.data;
                head = head.nextNode;
                top--;
                return value;
            }
        }
        
        public char Peek()
        {
            if (IsStackEmpty())
            {
                Console.WriteLine("Stack underflow");
                return ' ';
            }
            else
            {
                return head.data;
            }
        }

        public static void Main(string[] args)
        {
            RemoveAdjacent removeAd = new RemoveAdjacent();
            string input = Console.ReadLine();
            string result = removeAd.RemoveAdjacentChar(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private string RemoveAdjacentChar(string input)
        {
            foreach (char ch in input)
            {
                if (IsStackEmpty())
                {
                    Push(ch);
                }
                else if(ch == Peek())
                {
                    char poppedChar = Pop();
                }
                else
                    Push(ch);
            }
            int count = top + 1;
            char[] result = new char[count];
            while(!IsStackEmpty() && count >= 0)
            {
                result[count-1] = Pop();
                count--;
            }
            return new string(result);
        }

        private class Node
        {
            public char data;
            public Node nextNode;
            public Node(char data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }
    }
}
