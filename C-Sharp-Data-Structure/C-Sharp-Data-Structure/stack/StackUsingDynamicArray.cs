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
        int capacity = 10;
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
            return (top + 1 == capacity);
        }

        public int Pop()
        {
            if (IsEmptyStack())
                throw new Exception("Stack underflow");
            int topElement =  array[top--];
            if(array.Length - 1 == capacity / 4)
            {
                var t = array;
                array = new int[capacity / 2];
                Array.Copy(t, array, capacity / 2);
            }
            return topElement;
        }

        public void Push(int data)
        {
            if(IsFullStack())
            {
                capacity *= 2;
                var temp = array;
                array = new int[capacity];
                Array.Copy(temp, array, temp.Length);
            }
            array[++top] = data;
        }

        public static void Main(string[] args)
        {
            StackUsingDynamicArray stackDynamic = new StackUsingDynamicArray(4);
            stackDynamic.Push(1);
            stackDynamic.Push(2);
            stackDynamic.Push(3);
            stackDynamic.Push(4);
            stackDynamic.Push(5);   /*Dynamically increase size of array by 2 times*/

            Console.WriteLine(stackDynamic.Pop());
            Console.WriteLine(stackDynamic.Pop());
            Console.WriteLine(stackDynamic.Pop());
            Console.WriteLine(stackDynamic.Pop());
            Console.WriteLine(stackDynamic.Pop());
            Console.WriteLine(stackDynamic.Pop());  /* Underflow */

        }
    }
}
