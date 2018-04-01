using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    //Copied from https://github.com/lakshmikantdeshpande/Data_Structures_in_Java/blob/master/Java%20Data%20Structures/src/stack_problems/ThreeStacksInArray.java
    public class ThreeStackOneArray
    {
        int[] data;
        int topOne, topTwo, topThree, baseThree, size;

        public ThreeStackOneArray(int size)
        {
            this.size = size;
            data = new int[size];
            topOne = 0;
            topTwo = size - 1;
            baseThree = (size - 1) / 2;
            topThree = baseThree;
        }
        public ThreeStackOneArray():this(10)
        {
        }
        
        public void Push(int stackIndex, int data1)
        {
            if(stackIndex == 1)
            {
                if(topOne+1 == baseThree)
                {
                    if (IsMiddleStackRightShiftable())
                    {
                        ShiftMiddleStackToRight();
                        data[topOne] = data1;
                        topOne++;
                    }
                    else
                    {
                        throw new Exception("First stack is full");
                    }
                }
                else
                {
                    data[topOne] = data1;
                    topOne++;
                }
            }
            else if(stackIndex == 2)
            {
                if (topTwo - 1 == baseThree)
                {
                    if (IsMiddleStackLeftShiftable())
                    {
                        ShiftMiddleStackToLeft();
                        data[topTwo--] = data1;
                    }
                    else
                    {
                        throw new Exception("second stack is full");
                    }
                }
                else
                    data[topTwo--] = data1;

            }
            else if(stackIndex == 3)
            {
                if(topTwo - 1 == topThree)
                {
                    if (IsMiddleStackRightShiftable())
                    {
                        ShiftMiddleStackToRight();
                        data[topThree] = data1;
                        topThree++;
                    }
                    else
                    {
                        throw new Exception("Stack 3 is full");
                    }
                }
                else
                {
                    data[topThree] = data1;
                    topThree++;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        public int Pop(int stackIndex)
        {
            if(stackIndex == 1)
            {
                if(topOne == -1)
                {
                    throw new Exception("First stack is empty");
                }
                int value = data[topOne];
                data[topOne--] = int.MinValue;
                return value;
            }
            else if(stackIndex == 2)
            {
                if(topTwo == this.size)
                {
                    throw new Exception("Second stack is empty");
                }
                int value = data[topTwo];
                data[topTwo++] = int.MinValue;
                return value;
            }
            else if(stackIndex == 3)
            {
                if (topThree == baseThree)
                    throw new Exception("Third stack is empty");
                int value = data[topThree];
                data[topThree--] = int.MinValue;
                return value;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return int.MinValue;
            }
        }
        public int Peek(int stackIndex)
        {
            if (stackIndex == 1)
            {
                if (topOne == -1)
                    throw new Exception("first stack is empty");
                return data[topOne];
            }
            else if (stackIndex == 2)
            {
                if (topTwo == this.size)
                    throw new Exception("second stack is empty");
                return data[topTwo];
            }
            else if (stackIndex == 3)
            {
                if (topThree == baseThree)
                    throw new Exception("Third stack is empty");
                return data[topThree];
            }
            else
                return int.MinValue;
        }
        public bool IsEmpty(int stackIndex)
        {
            if (stackIndex == 1)
                return topOne == -1;
            else if (stackIndex == 2)
                return topTwo == this.size;
            else if (stackIndex == 3)
                return topThree == baseThree;
            else
                return false;
        }
        private void ShiftMiddleStackToRight()
        {
            for(int i = topThree; i >= baseThree; i--)
                data[i + 1] = data[i];
            data[baseThree++] = int.MinValue;
            topThree++;
        }

        private void ShiftMiddleStackToLeft()
        {
            for (int i = baseThree + 1; i <= topThree; i++)
                data[i] = data[i + 1];
            data[topThree--] = int.MinValue;
            baseThree--;
        }

        private bool IsMiddleStackRightShiftable()
        {
            return topOne + 1 < baseThree;
        }

        private bool IsMiddleStackLeftShiftable()
        {
            return topThree + 1 < topTwo;
        }

        public static void Main(String[] args)
        {
            ThreeStackOneArray three = new ThreeStackOneArray();
            three.Push(1, 1);
            three.Push(1, 1);
            three.Push(1, 1);
            Console.ReadKey();
        }
    }
}
