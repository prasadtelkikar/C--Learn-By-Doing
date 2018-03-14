using System;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class PalindromeUsingStack
    {
        StackNode head;
        public PalindromeUsingStack()
        {
            head = null;
        }

        private StackNode CreateNode(char data)
        {
            return new StackNode(data);
        }
        public bool IsEmptyStack()
        {
            return (head == null);
        }
        public void Push(char data)
        {
            StackNode newNode = CreateNode(data);
            if (IsEmptyStack())
                head = newNode;
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }

        public char Pop()
        {
            if(IsEmptyStack())
            {
                Console.WriteLine("Stack is underflow");
                return ' ';
            }

            char temp = head.data;
            head = head.next;
            return temp;
        }

        public bool IsPalindrom(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                Push(word[i]);
            }
            int secondHalf = (word.Length % 2 == 0) ? (word.Length / 2) : (word.Length / 2 + 1);

            for (int i = secondHalf; i < word.Length; i++)
            {
                char temp = Pop();
                if (temp != word[i])
                    return false;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            PalindromeUsingStack palindrom = new PalindromeUsingStack();
            Console.WriteLine("Enter string: ");
            string word = Console.ReadLine();
            bool isPalindrom = palindrom.IsPalindrom(word);
            Console.WriteLine(isPalindrom ? "String is palindrom" : "String is not palindrom");
            Console.ReadKey();
        }

        private class StackNode
        {
            public char data;
            public StackNode next;
            public StackNode(char data)
            {
                this.data = data;
            }
        }
    }
}
