using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class GetMinimumFromStack
    {
        GenericStack<int> mainStack;
        GenericStack<int> minStack;

        public GetMinimumFromStack()
        {
            mainStack = new GenericStack<int>();
            minStack = new GenericStack<int>();
        }

        public static void Main(string[] args)
        {
            string array = Console.ReadLine();
            GetMinimumFromStack minFromStack = new GetMinimumFromStack();
//            GenericStack<int> mainStack = CreateMainStack(array);
            int min = minFromStack.GetMinimum(array);
            Console.WriteLine(min);
            Console.ReadKey();
        }

        private int GetMinimum(string array)
        {
            int[] elements = Array.ConvertAll(array.Split(' '), Int32.Parse);
            foreach (int element in elements)
            {
                if (mainStack.IsStackEmpty() || (!mainStack.IsStackEmpty() && minStack.Peek() > element))
                {
                    mainStack.Push(element);
                    minStack.Push(element);
                }
                else 
                {
                    int top = minStack.Peek();
                    minStack.Push(top);
                    mainStack.Push(element);
                }
            }
            return minStack.Peek();
        }
    }
}
