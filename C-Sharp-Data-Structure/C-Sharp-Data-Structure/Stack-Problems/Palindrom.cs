using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class Palindrom
    {
        public static bool IsPalindrom(string input)
        {
            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                    return false;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter string to check palindrom? :");
            string input = Console.ReadLine();
            bool isPalindrom = IsPalindrom(input);
            Console.WriteLine(isPalindrom ? "String is palindrom" : "String is not a palindrom");
            Console.ReadKey();
        }
    }
}
