using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack
{
    public class StackUsingFixedArray
    {
        int top = 0;
        readonly int capacity = 0;
        int []array; 
        public StackUsingFixedArray()
        {
            top = -1;
            capacity = 10;
            array = new int[capacity];
        }

        public bool IsEmptyStack()
        {
            //If the top is equal to -1 (it means stack is empty), then it will return true otherwise false
            return (top == -1) ;
        }

        public bool IsFullStack()
        {
            //If top is equal to capacity, then it will return true otherwise false
            return (top == capacity - 1);
        }

        public void Push(int data)
        {
            if (IsFullStack())
            {
                throw new Exception("Stack overflow");
            }
            else
                array[++top] = data;
        }

        public int Pop()
        {
            if (IsEmptyStack())
                throw new Exception("Stack underflow");
            else
                return array[top--];
        }

        public static void Main(string[] args)
        {
            StackUsingFixedArray stackObj = new StackUsingFixedArray();
            try
            {
                stackObj.Push(1);
                stackObj.Push(2);
                stackObj.Push(3);
                stackObj.Push(4);
                stackObj.Push(5);
                stackObj.Push(6);
                stackObj.Push(7);

                Console.WriteLine(stackObj.Pop());
                Console.WriteLine(stackObj.Pop());
                Console.WriteLine(stackObj.Pop());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
