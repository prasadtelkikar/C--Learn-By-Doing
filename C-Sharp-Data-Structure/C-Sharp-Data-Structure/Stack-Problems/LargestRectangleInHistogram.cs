using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class LargestRectangleInHistogram
    {
        int[] input;
        public LargestRectangleInHistogram(int[] input)
        {
            this.input = input;
        }
        public int FindLargestHistogram()
        {
            int maxArea = int.MinValue;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int j = i + 1;
                int count = 1;
                while(j < input.Length && input[j] >= input[i])
                {
                    count++;
                    j++;
                }
                int area = count * input[i];
                maxArea = (maxArea < area) ? area : maxArea;
            }
            return maxArea;
        }
        public static void Main(string[] args)
        {
            string[] temp = Console.ReadLine().Split(' ');
            int[] input = Array.ConvertAll(temp, int.Parse);
            LargestRectangleInHistogram largest = new LargestRectangleInHistogram(input);
            Console.WriteLine("Maximum area:" + largest.FindLargestHistogram());
            //Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
