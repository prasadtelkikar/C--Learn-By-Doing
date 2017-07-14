using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionAndBackTracking
    {
    public class CheckIsArraySorted
        {
        public static void Main (string[] args)
            {
            int arrayLength = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            bool isSorted = IsArraySorted(arr, arrayLength);
            Console.WriteLine(isSorted ? "Array is sorted" : "Array is not sorted");
            Console.ReadKey();

            }

        private static bool IsArraySorted(int[] arr, int arrayLength)
        {
            if (arrayLength == 1)
                return true;

            return arr[arrayLength - 1] < arr[arrayLength - 2] ? false : IsArraySorted(arr, arrayLength - 1);
        }
        }
    }
