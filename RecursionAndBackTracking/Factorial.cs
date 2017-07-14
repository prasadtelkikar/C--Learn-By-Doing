using System;

namespace RecursionAndBackTracking
    {
    public class Factorial
        {
        public static void Main (string[] args)
            {
            long factorialNumber = Convert.ToInt32(Console.ReadLine());
            long factoralResult = Fact(factorialNumber);
            Console.WriteLine($"Factorial of {factorialNumber} is {factoralResult}");

            Console.ReadKey();
            }

        private static long Fact (long factorialNumber)
            {
            if ( factorialNumber == 1 || factorialNumber == 0 )
                return 1;

            return factorialNumber * Fact(factorialNumber - 1);
            }
        }
    }
