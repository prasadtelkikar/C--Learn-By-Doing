using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class TwoStacksOneArray
    {
        int[] result;
        int startIndex;
        int lastIndex;
        public TwoStacksOneArray(int size)
        {
            result = new int[size];
            startIndex = 0;
            lastIndex = size - 1;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number of inputs");
             int numOfInputs = Convert.ToInt32(Console.ReadLine());
            TwoStacksOneArray twoSoneA = new TwoStacksOneArray(numOfInputs);
            Console.WriteLine("Enter inputs in format<value 1st/2nd stack>. e.g. 5, 2");

            for (int i = 0; i < numOfInputs; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                twoSoneA.InsertToArray(input[0], input[1]);
            }
            Console.WriteLine(twoSoneA.ToString());
            Console.ReadKey();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Array = [");
            for (int i = 0; i < result.Length - 1; i++)
            {
                sb.Append(result[i] + ", ");
            }
            sb.Append(result[result.Length - 1] + "]");
            return sb.ToString();
        }
        private void InsertToArray(int inputValue, int stackNumber)
        {

            switch (stackNumber)
            {
                case 1:
                    result[startIndex++] = inputValue;
                    break;
                case 2:
                    result[lastIndex--] = inputValue;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
