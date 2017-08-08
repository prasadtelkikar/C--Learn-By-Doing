using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.UnrolledLinkedList
    {
    public class StartUp
        {
        public static void Main (string[] args)
            {

            Console.WriteLine("Please enter block size of linked list");
            int blockSize = Convert.ToInt32(Console.ReadLine());
            UnrolledLinkedListOperations unRolled = new UnrolledLinkedListOperations(blockSize);
            LinkedBlockList<int> block = null;

            bool flag = true;
            int count = 0;
            while ( flag )
                {
                Console.WriteLine("Enter value: ");
                int value = Convert.ToInt32(Console.ReadLine());
                if ( count == 0 )
                    {
                    block = new LinkedBlockList<int>(value);
                    //unRolled.CreateList(block, value);
                    }
                else
                    {
                    unRolled.CreateList(block, value);
                    }
                count++;
                Console.Write("Do you want to continue (Y/N):");
                char c = Convert.ToChar(Console.Read());
                Console.ReadLine();
                flag = c == 'Y' || c == 'y';
                }
            }
        }
    }
