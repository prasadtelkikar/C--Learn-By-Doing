namespace LinkedList.UnrolledLinkedList
    {
    public sealed class ListNode<T>
        {
        public T Value
            {
            get; internal set;
            }
        public ListNode<T> Next
            {
            get; internal set;
            }
        public ListNode<T> Previous
            {
            get; internal set;
            }
        public ListNode (T item)
            {
            this.Value = item;
            }
        }
    }
