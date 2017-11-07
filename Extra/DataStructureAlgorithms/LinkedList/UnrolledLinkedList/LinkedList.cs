using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.UnrolledLinkedList
    {
    public class LinkedList<T>
        {
        ListNode<T> head;
        ListNode<T> tail;

        public ListNode<T> Head
            {
            get
                {
                return head;
                }
            }
        public ListNode<T> Tail
            {
            get
                {
                return tail;
                }
            }
        private void AddFirstItem (T item)
            {
            head = new ListNode<T>(item);
            tail = head;
            head.Next = head;
            head.Previous = head;
            }

        public void AddLast (T item)
            {
            if ( head == null )
                this.AddFirstItem(item);
            else
                {
                ListNode<T> newNode = new ListNode<T>(item);
                tail.Next = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                head.Previous = newNode;
                tail = newNode;
                }
            }

        public void AddFirst (T item)
            {
            if ( head == null )
                this.AddFirstItem(item);
            else
                {
                ListNode<T> newNode = new ListNode<T>(item);
                newNode.Previous = tail;
                newNode.Next = head;
                tail.Next = newNode;
                head.Previous = newNode;
                head = newNode;
                }
            }
        }
    }
