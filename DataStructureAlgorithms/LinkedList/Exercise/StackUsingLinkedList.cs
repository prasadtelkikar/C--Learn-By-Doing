using System;
using System.Collections.Generic;

/* Excercise 1: Implementation of stack using linked list
 * Stack operations:
 * top, clear, push, pop, Check for empty stack
 */
namespace LinkedList.Exercise
    {
    /// <summary>
    /// Stack operations
    /// </summary>
    public class Stack<T>
        {
        LinkedList<T> stack;
        public Stack ()
            {
            stack = new LinkedList<T>();
            }
        public void Push (T item)
            {
            stack.AddFirst(item);
            }
        public T Pop ()
            {
            T topValue;
            if ( !IsEmptyStack() )
                {
                 topValue = Top();
                stack.RemoveFirst();
                return topValue;
                }
            return (T)Convert.ChangeType(0, Type.GetTypeCode(typeof(T)));
            }
        public T Top ()
            {
            if ( IsEmptyStack() )
                {
                Console.WriteLine("Stack is empty");
                return (T) Convert.ChangeType(0, Type.GetTypeCode(typeof(T)));
                }
            else
                {
                LinkedListNode<T> top = stack.First;
                return top.Value;
                }
            }
        public bool IsEmptyStack ()
            {
            if ( stack.Count == 0 )
                return true;

            return false;
            }
        public bool Clear ()
            {
            if ( !IsEmptyStack() )
                {
                stack.Clear();
                return true;
                }
            return true;
            }
        public void PrintStack ()
            {
            LinkedListNode<T> node = stack.First;
            while ( node != null )
                {
                Console.WriteLine(node.Value);
                node = node.Next;
                }
            }
        }
    public class StackUsingLinkedList
        {
        public static void Main (string[] args)
            {
            Stack<int> stack = new Stack<int>();
            char ch = ' ';
            do
                {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3. Check stack is empty");
                Console.WriteLine("4. Check for top");
                Console.WriteLine("5. Display stack");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch ( choice )
                    {
                    case 1:
                        Console.WriteLine("Push operation: Enter integer");
                        int item = Convert.ToInt32(Console.ReadLine());
                        stack.Push(item);
                        break;
                    case 2:
                        Console.WriteLine("Pop operation:");
                        Console.WriteLine(stack.Pop());
                        break;
                    case 3:
                        Console.WriteLine(stack.IsEmptyStack() ? "Stack is empty" : "Stack is not empty");
                        break;
                    case 4:
                        Console.WriteLine("Top of the stack : " + stack.Top());
                        break;
                    case 5:
                        stack.PrintStack();
                        break;
                    }
                Console.WriteLine("Do you want to continue (Y/N): ");
                ch = Convert.ToChar(Console.ReadLine());
                } while ( ch == 'Y' || ch == 'y' );
            Console.ReadKey();
            }
        }
    }