using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class WhetherStackGrows
    {
        //https://stackoverflow.com/questions/17650429/how-to-compile-unsafe-code-in-vs2012
        public static unsafe void Main(string[] args)
        {
            int temp = 10;
            bool result = CheckStackGrows(&temp);
            Console.WriteLine(result ? "Stack is growing upward" : "Stack is growing downward");
            Console.ReadKey();
        }

        private static unsafe bool CheckStackGrows(int* ptr)
        {
            IntPtr intPtr = (IntPtr)ptr;
            long intPtrCast = (long)intPtr;
            int nextTemp = 20;
            //Created pointer to store address of variable
            int* nTprt = &nextTemp;
            //Converted to IntPtr
            IntPtr nextTempPtr = (IntPtr)nTprt;
            //Cast to long for comparing two pointer address
            long nextTempCast = (long)nextTempPtr;

            Console.WriteLine("Address of first pointer = " + intPtrCast);
            Console.WriteLine("Address of second pointer = " + nextTempCast);
            if (nextTempCast > intPtrCast)
                return true;
            return false;
            //throw new NotImplementedException();
        }
    }
}
