using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/* Operand : +,*,/,-
 * Operator : 0-9
 */
namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class PostfixEvaluation
    {
        GenericStack<int> stack;

        public PostfixEvaluation()
        {
            stack = new GenericStack<int>();
        }

        public int EvaluateEquation(string equation)
        {
            //Buggi code. Only works for 1 digit; need to work on multiple digits
            foreach(char ch in equation)
            {
                if (Regex.IsMatch(ch.ToString(), "^[0-9]"))
                    stack.Push(ch);
                else
                {
                    int firstElement = stack.Pop();
                    int secondElement = stack.Pop();

                    int result = GetResult(firstElement, secondElement, ch);
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }

        private int GetResult(int firstElement, int secondElement, char ch)
        {
            switch (ch)
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

        public static void Main(string[] args)
        {
            PostfixEvaluation postFixEval = new PostfixEvaluation();
            string eq = Console.ReadLine();
            Console.WriteLine(postFixEval.EvaluateEquation(eq));
            Console.ReadKey();
        }
    }
}
