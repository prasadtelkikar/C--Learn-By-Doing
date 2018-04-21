using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue_Problems
{
    //This problem can be solved with doubly ended queue or priority queue. Will solve in that chapter
    public class MaxInSlideWindow
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter queue in array format");
                int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine("Enter slide window size:");
                int slidingWindow = Convert.ToInt32(Console.ReadLine());
                int[] result = GetMaxFromSlideWindow(array, slidingWindow);
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static int[] GetMaxFromSlideWindow(int[] array, int slidingWindow)
        {
            int[] results = new int[(array.Length - slidingWindow + 1)];
            if(array.Length < slidingWindow)
            {
                throw new Exception("Sliding window size is greater than array length");
            }
            else
            {
                //O(n*m) complexity, need to find some efficient code
                for (int i = 0; i < (array.Length - slidingWindow+1); i++)
                {
                    int maxValue = int.MinValue;
                    for (int j = 0; j < (i+slidingWindow); j++)
                    {
                        maxValue = Math.Max(maxValue, array[j]);
                    }
                    results[i] = maxValue;
                }
            }
            return results;
        }
    }
}
