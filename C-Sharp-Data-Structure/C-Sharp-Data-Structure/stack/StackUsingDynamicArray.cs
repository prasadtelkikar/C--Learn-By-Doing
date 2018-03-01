using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack
{
    public class StackUsingDynamicArray
    {
        int top = -1;
        readonly int capacity = 10;
        int[] array;

        public StackUsingDynamicArray(int capacity)
        {
            this.capacity = capacity;
            array = new int[capacity];
        }

        public bool IsEmptyStack()
        {
            return (top == -1);
        }

        public bool IsFullStack()
        {
            return (top == capacity);
        }

        public int Pop()
        {
            return 0;
        }

        public static void Main(string[] args)
        {

        }
    }
}
