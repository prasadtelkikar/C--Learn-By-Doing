using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class FindingSpans
    {
        public FindingSpans()
        {
        }

        public int[] FindingSpan(int[] input)
        {
            int[] span = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int j = 1;
                while (j <= i && input[j] < input[i])
                    j += 1;
                span[i] = j;
            }
            return span;
        }

        public static void Main(string[] args)
        {
            FindingSpans fs = new FindingSpans();

            Console.WriteLine("Enter input array");
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] result = fs.FindingSpan(input);

            //print result in tabular format. Input \t span
            Console.WriteLine("Input    Span");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(input[i] + "\t" + result[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
