using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class ReverseStack
    {
        //Buggi code; time to sleep :) Tomorrow I will see u...
        public static void Main(string[] args)
        {
            ReverseStack rStack = new ReverseStack();
            GenericStack<int> head = new GenericStack<int>();
            head.Push(1);
            head.Push(2);
            head.Push(3);
            head.Push(4);
            head.Push(5);

            rStack.Reverse(head);
            Console.ReadKey();
        }

        private void Reverse(GenericStack<int> head)
        {
            if (head.IsStackEmpty())
                return;
            int data = head.Pop();
            Reverse(head);
            InsertAtEnd(head, data);
        }

        private void InsertAtEnd(GenericStack<int> head, int data)
        {
            if (head.IsStackEmpty())
            {
                head.Push(data);
                return;
            }
            int temp = head.Pop();
            InsertAtEnd(head, data);
            head.Push(temp);
        }
    }
}
