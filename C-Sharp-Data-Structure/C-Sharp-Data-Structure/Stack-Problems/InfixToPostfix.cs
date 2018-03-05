using C_Sharp_Data_Structure.Stack_Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class InfixToPostfix
    {
        StackLinkedList stack;
        public InfixToPostfix()
        {
            stack = new StackLinkedList();
        }

        public static void Main(string[] args)
        {
            string infixExpression = Console.ReadLine();
            InfixToPostfix inToPost = new InfixToPostfix();
            string postfixExpression = inToPost.InfixToPostfixConversion(infixExpression);
            Console.WriteLine(postfixExpression);
            Console.ReadKey();
        }

        private string InfixToPostfixConversion(string infixExpression)
        {
            StringBuilder postfixExp = new StringBuilder();
            foreach(char ch in infixExpression)
            {
                if (Regex.IsMatch(ch.ToString(), "^[a-zA-Z0-9]"))
                    postfixExp.Append(ch);
                else if (!stack.IsEmptyStack() && ch != ')')
                {
                    char topChar = stack.Peek();
                    if (Precedence(topChar) < Precedence(ch))
                        stack.Push(ch);
                    else
                    {
                        do
                        {
                            topChar = stack.Pop();
                            postfixExp.Append(topChar);
                        } while (!stack.IsEmptyStack() && Precedence(topChar) >= Precedence(ch));
                        stack.Push(ch);
                    }

                }
                else if(!stack.IsEmptyStack() && ch == ')')
                {
                    char topChar = stack.Pop();
                    while(topChar != '(')
                    {
                        postfixExp.Append(topChar);
                        topChar = stack.Pop();
                    }
                }
                else
                    stack.Push(ch);
            }
            while (!stack.IsEmptyStack())
            {
                char operators = stack.Pop();
                postfixExp.Append(operators);
            }
            return postfixExp.ToString();
        }

        private int Precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
            }
            return -1;
        }
    }
}
