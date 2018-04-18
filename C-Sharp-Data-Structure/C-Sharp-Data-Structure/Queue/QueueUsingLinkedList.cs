using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Queue
{
   public class QueueUsingLinkedList
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
        private class QueueNode
        {
            public int data;
            public QueueNode nextNode;
        }
        private class QueueIndex
        {
            public QueueNode frontIndex;
            public QueueNode rearNode;
        }
    }
}
