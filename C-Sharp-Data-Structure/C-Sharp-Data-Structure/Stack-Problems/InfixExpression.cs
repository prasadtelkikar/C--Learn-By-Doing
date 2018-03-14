using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class InfixExpression
    {
        GenericStack<char> stackOperator;
        GenericStack<int> stackOperand;
        public InfixExpression()
        {
            stackOperator = new GenericStack<char>();
            stackOperand = new GenericStack<int>();
        }

        public static void Main(string[] args)
        {
            InfixExpression infixExpression = new InfixExpression();
            string equation = Console.ReadLine();
            int result = infixExpression.EvaluateExpression(equation);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private int EvaluateExpression(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == ' ')
                    continue;
                else if (equation[i] >= '0' && equation[i] <= '9')
                {
                    StringBuilder sb = new StringBuilder();
                    while (i < equation.Length && equation[i] >= '0' && equation[i] <= '9')
                        sb.Append(equation[i++]);

                    stackOperand.Push(Int32.Parse(sb.ToString()));
                }
                else if (equation[i] == '(')
                    stackOperator.Push('(');
                else if(equation[i] == ')')
                {
                    while(stackOperator.Peek() != '(')
                    {
                        int result = GetResult(stackOperand.Pop(), stackOperand.Pop(), stackOperator.Pop());
                        stackOperand.Push(result);
                    }
                    stackOperator.Pop();
                }
                else if(equation[i] == '+' || equation[i] == '-' || equation[i] == '*' || equation[i] == '/')
                {
                    while(!stackOperator.IsStackEmpty() && HasPrecedence(equation[i], stackOperator.Peek()))
                    {
                        int result = GetResult(stackOperand.Pop(), stackOperand.Pop(), stackOperator.Pop());
                        stackOperand.Push(result);
                    }
                    stackOperator.Push(equation[i]);
                }
            }
            while (!stackOperator.IsStackEmpty())
            {
                int result = GetResult(stackOperand.Pop(), stackOperand.Pop(), stackOperator.Pop());
                stackOperand.Push(result);
            }
            return stackOperand.Pop();
        }

        private bool HasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
                return false;
            else if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;
            else
                return true;
        }

        private int GetResult(int firstElement, int secondElement, char stackOperator)
        {
            switch (stackOperator)
            {
                case '+':
                    return firstElement + secondElement;
                case '-':
                    return firstElement - secondElement;
                case '*':
                    return firstElement * secondElement;
                case '/':
                    return firstElement / secondElement;
                default://Kept + as a default operation
                    return firstElement + secondElement;
            }
        }
    }
}
