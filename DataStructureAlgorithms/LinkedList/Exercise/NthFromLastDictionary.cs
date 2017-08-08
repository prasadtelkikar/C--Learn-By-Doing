using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Exercise
    {
    public class NthFromLastDictionary
        {
        public static void Main (string[] args)
            {

            LinkedList<int> linkedList = new LinkedList<int>();
            Dictionary<int, LinkedListNode<int>> dictionary = new Dictionary<int, LinkedListNode<int>>();
            char ch = ' ';
            int index = 1;
            do
                {
                Console.WriteLine("Enter element: ");
                int element = Convert.ToInt32(Console.ReadLine());
                LinkedListNode<int> node = new LinkedListNode<int>(element);
                linkedList.AddLast(node);
                dictionary.Add(index, node);
                Console.WriteLine("Do you want to continue: ");
                ch = Convert.ToChar(Console.ReadLine());
                index++;
                } while ( ch == 'Y' || ch == 'y' );

            Console.WriteLine("Enter nth node from the end of list");
            int nthNode = Convert.ToInt32(Console.ReadLine());

            if ( nthNode > index )
                {
                Console.WriteLine("Fewer numbers of nodes in the list");
                return;
                }
            else
                {
                int nEnd = index - nthNode;
                LinkedListNode<int> node = dictionary[nEnd];
                if ( node != null )
                    Console.WriteLine($"Found node at location {nthNode} from end and value is {node.Value}");
                else
                    Console.WriteLine("Expected node not found");
                }
            Console.ReadKey();
            }
        }
    }
