using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionAndBackTracking
    {
    //Print numbers backword and forward using recursion
    public class PrintByRecursion
        {
        public static void Main (string[] args)
            {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("List in Reverse order");
            int result = PrintReverse(number);
            Console.WriteLine("List in forward order");
            int forwardResult = PrintFoward(1, number);
            Console.ReadKey();
            }

        private static int PrintFoward (int number, int limit)
            {
            if ( number > limit )
                return limit;
            else
                {
                Console.WriteLine(number);
                return PrintFoward(number + 1, limit);
                }
            }

        private static int PrintReverse (int number)
            {
            if ( number == 0 )
                return 0;
            else
                {
                Console.WriteLine(number);
                return PrintReverse(number - 1);
                }
            }
        }
    }
