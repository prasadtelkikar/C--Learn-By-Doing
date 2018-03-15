using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class GenericStack<T>
    {
        public int top;
        Stack<T> head = null;
        public GenericStack()
        {
            top = -1;
        }

        public bool IsStackEmpty()
        {
            return (top == -1);
        }

        public T Peek()
        {
            return head.data;
        }

        private Stack<T> CreateNode(T data)
        {
            return new Stack<T>(data);
        }

        public void Push(T data)
        {
            Stack<T> newNode = CreateNode(data);
            Stack<T> oldNode = head;
            newNode.nextData = oldNode;
            head = newNode;
            top++;

        }

        public T Pop()
        {
            Stack<T> temp = head;
            head = head.nextData;
            top--;
            return temp.data;
        }

        private class Stack<T1>
        {
            public T1 data;
            public Stack<T1> nextData;
            public Stack(T1 data)
            {
                this.data = data;
                nextData = null;
            }
        }
    }
}
