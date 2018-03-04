using System;

namespace C_Sharp_Data_Structure.Stack_Problems
{

    public class CheckBalancingSymbols
    {
        StackLinkedList stackLinkedList = new StackLinkedList();
        string input="";

        public static void Main(string[] args)
        {
            CheckBalancingSymbols balancingSymbol = new CheckBalancingSymbols();
            Console.WriteLine("Enter string in format of balancing symbols (A+B)+(C+D) :");
            balancingSymbol.input = Console.ReadLine();

            bool isBalance = balancingSymbol.IsBalancedStack(balancingSymbol.input);
            Console.WriteLine(isBalance ? "Symbols are balanced" : "Symbols are not balanced");
            Console.ReadKey();
        }

        private bool IsBalancedStack(string input)
        {
            try
            {
                foreach (char ch in input)
                {
                    if (ch == '(' || ch == '[' || ch == '{')
                        stackLinkedList.Push(ch);
                    else if (ch == ')' || ch == ']' || ch == '}')
                    {
                        char stackChar = stackLinkedList.Pop();
                        switch (stackChar)
                        {
                            case '(':
                                if (ch != ')')
                                    return false;
                                break;
                            case '[':
                                if (ch != ']')
                                    return false;
                                break;
                            case '{':
                                if (ch != '}')
                                    return false;
                                break;
                        }
                    }
                }
                return stackLinkedList.IsEmptyStack();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
