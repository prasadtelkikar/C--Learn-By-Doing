using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class MStacksInOneArray
    {
        int m, size;
        int[] data;
        int[] topIndex;
        int[] baseIndex;
        int[] currentIndex;
        public MStacksInOneArray(int arrSize, int stackNo)
        {
            m = stackNo;
            size = arrSize;
            data = new int[size];
            topIndex = new int[m];
            baseIndex = new int[m];
            currentIndex = new int[m];
            for (int i = 0; i < m; i++)
            {
                if (i != 0)
                {
                    baseIndex[i] = topIndex[i - 1];
                    currentIndex[i] = baseIndex[i];
                }
                topIndex[i] = ((i + 1) * size) / m;
            }
        }
        
        public MStacksInOneArray() : this(10, 5)
        {

        }
        public void Push(int stackIndex, int value)
        {
            if(stackIndex <= m)
            {
                int currentindex = currentIndex[stackIndex-1];
                int topindex = topIndex[stackIndex-1];

                if (IsFullStack(stackIndex - 1))
                {
                    Console.WriteLine("Stack is full");
                    return;
                }
                data[currentIndex[stackIndex - 1]++] = value;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private bool IsFullStack(int index)
        {
            return currentIndex[index] == topIndex[index];
        }

        public int Pop(int stackIndex)
        {
            if(stackIndex <= m)
            {
                if (stackIndex == 1 && currentIndex[stackIndex - 1] == 0 && topIndex[stackIndex - 1] == 0)
                {
                    Console.WriteLine("Stack is empty");
                    return int.MinValue;
                }
                else
                {
                    int prevBaseIndex = baseIndex[stackIndex - 2];
                    int currentindex = currentIndex[stackIndex - 1];
                    if(prevBaseIndex == currentindex)
                    {
                        Console.WriteLine("Stack is empty");
                        return int.MinValue;
                    }
                }
                int value = data[currentIndex[stackIndex - 1]--];
                return value;
            }
            else
            {
                Console.WriteLine("Invalid input while pop function");
                return int.MinValue;
            }
        }

        public int Peek(int stackIndex)
        {
            if(stackIndex <= m)
            {
                return data[currentIndex[stackIndex - 1]];
            }
            return int.MinValue;
        }

        public static void Main(string[] args)
        {
            MStacksInOneArray mstack = new MStacksInOneArray(20,2);
            mstack.Push(1, 5);
            mstack.Push(1, 10);
            mstack.Push(1, 15);
            mstack.Push(2, 20);
            mstack.Push(2, 25);
            mstack.Push(2, 30);
            
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
