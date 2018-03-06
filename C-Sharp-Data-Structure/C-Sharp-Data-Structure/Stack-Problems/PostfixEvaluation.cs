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
        StackLinkedList stack;

        public PostfixEvaluation()
        {
            stack = new StackLinkedList();
        }

        public int EvaluateEquation(string equation)
        {
            foreach(char ch in equation)
            {
                if (Regex.IsMatch(ch.ToString(), "^[0-9]"))
                    stack.Push(ch);
                else
                {
                    int firstElement = Int32.Parse(stack.Pop().ToString());
                    int secondElement = Int32.Parse(stack.Pop().ToString());

                    int result = GetResult(firstElement, secondElement, ch);
                    stack.Push(Char.Parse(result.ToString()));
                }
            }
            return Int32.Parse(stack.Pop().ToString());
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
