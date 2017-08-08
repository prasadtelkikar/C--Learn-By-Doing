using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.UnrolledLinkedList
    {
    public sealed class LinkedBlock<T>
        {
        private ListNode<T> head = null;
        private ListNode<T> tail = null;
        public int NodeCount
            {
            get; internal set;
            }
        //public ListNode<T> Head
        //    {
        //    get; internal set;
        //    }
        public LinkedList<T> List { get; internal set; } 
        public LinkedBlock<T> Next
            {
            get; internal set;
            }
        public LinkedBlock<T> Previous
            {
            get; internal set;
            }
        public int BlockSize
            {
            get; internal set;
            }
        public LinkedBlock (T item)
            {
            this.List = new LinkedList<T>();
            this.List.AddLast(item);
            this.NodeCount = 1;
            } 
        }
    }
