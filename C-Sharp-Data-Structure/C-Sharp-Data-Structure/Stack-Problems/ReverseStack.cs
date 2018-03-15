using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class ReverseStack
    {
        static GenericStack<int> head;
        public static void Main(string[] args)
        {
            ReverseStack rStack = new ReverseStack();
            head = new GenericStack<int>();
            head.Push(1);
            head.Push(2);
            head.Push(3);
            head.Push(4);
            head.Push(5);

            rStack.Reverse(head);
            Console.WriteLine(rStack.ToString());
            Console.ReadKey();
        }

        //Use ToString() function to print stack but IT SHOULD USE AT THE END BECAUSE, HERE I AM POPPING EACH ELEMENT
        public override string ToString()
        {
            if(head == null)
                return "Stack = []";
            StringBuilder sb = new StringBuilder();
            sb.Append("Stack = [");
            while (!head.IsStackEmpty())
            {
                //Condition for not using , for last element
                if (head.top != 0)
                    sb.Append(head.Pop() + ", ");
                else
                    sb.Append(head.Pop());

            }
                

            sb.Append("]");
            return sb.ToString();
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
