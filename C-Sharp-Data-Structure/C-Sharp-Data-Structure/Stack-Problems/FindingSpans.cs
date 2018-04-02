using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class FindingSpans
    {
        int[] input;
        int[] span;

        public FindingSpans()
        {
            Console.WriteLine("Enter input array");
            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            span = new int[input.Length];
        }

        public int[] FindMaxSpan()
        {
            for (int i = 0; i < input.Length; i++)
            {
                int j = 1;
                while (j <= i && input[j] < input[i])
                    j += 1;
                span[i] = j;
            }
            return span ;
        }

        public static void Main(string[] args)
        {   
            FindingSpans fs = new FindingSpans();
            int[] result = fs.FindMaxSpan();

            //print result in tabular format. Input \t span
            Console.WriteLine("Input    Span");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(fs.input[i] + "\t" + result[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
