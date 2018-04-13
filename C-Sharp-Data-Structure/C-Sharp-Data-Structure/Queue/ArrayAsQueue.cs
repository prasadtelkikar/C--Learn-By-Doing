using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue
{
    public class ArrayAsQueue
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("To avoid failure in program, Add only digits");
            int size = int.Parse(Console.ReadLine());
            int[] queue = new int[size];
            //Array works on the principle of First-In-First-Out
            for (int i = 0; i < size; i++)
            {
                queue[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Output: Printing queue based on FIFO");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(queue[i]);
            }
            Console.ReadKey();
        }
    }
}
