using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.UnrolledLinkedList
    {
    public class LinkedBlockList<T>
        {
        LinkedBlock<T> head = null;
        LinkedBlock<T> tail = null;
        public int ListCount
            {
            get { return tail.NodeCount; }
            }
        public LinkedBlock<T> Head
            {
            get { return head; }
            } 
        public LinkedBlock<T> Tail
            {
            get
                {
                return tail;
                }
            } 
        public void AddLast (LinkedBlock<T> block)
            {
            tail.Next = block;
            tail = block;
            }
        public LinkedBlockList (T item)
            {
            LinkedBlock<T> block = new LinkedBlock<T>(item);
            head = block;
            tail = block;
            block.Next = null;
            block.Previous = null;
            }
        }
    }
