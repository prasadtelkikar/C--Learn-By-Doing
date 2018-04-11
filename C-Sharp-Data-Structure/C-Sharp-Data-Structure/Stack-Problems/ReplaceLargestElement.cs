using System;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class ReplaceLargestElement
    {
        private void ReplaceElements(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int replacedNumber = int.MinValue;
                for (int j = i+1; j < input.Length; j++)
                {
                    if(input[i] < input[j])
                    {
                        replacedNumber = input[j];
                        Console.WriteLine("Greatest replacement of " + input[i] + " is " + input[j]);
                        break;
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            ReplaceLargestElement replace = new ReplaceLargestElement();
            replace.ReplaceElements(input);
            Console.ReadKey();
        }
    }
}
