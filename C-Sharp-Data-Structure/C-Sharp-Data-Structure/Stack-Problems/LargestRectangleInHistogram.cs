using System;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    //Largest area in histogram - bruteforce approach
    //Input : 3 2 5 6 1 4 4 Output: 10
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
            for (int i = 0; i < input.Length-1; i++)
            {
                int minValue = int.MaxValue;
                for (int j = i+1; j < input.Length; j++)
                {
                    int temp = (input[i] > input[j]) ? input[j] : input[i];
                    minValue = (temp > minValue) ? minValue : temp;
                    int area = minValue * ((j + 1) - i);
                    if (maxArea < area)
                        maxArea = area;
                }
                
            }
            return maxArea;
        }

        public static void Main(string[] args)
        {
            string[] temp = Console.ReadLine().Split(' ');
            int[] input = Array.ConvertAll(temp, int.Parse);
            LargestRectangleInHistogram largest = new LargestRectangleInHistogram(input);
            Console.WriteLine(largest.FindLargestHistogram());
            Console.ReadLine();
        }
    }
}
