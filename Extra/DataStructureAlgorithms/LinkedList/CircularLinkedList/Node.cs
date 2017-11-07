namespace LinkedList.CircularLinkedList
    {
    public sealed class Node<T>
        {
        /// <summary>
        /// Value property with only public get
        /// </summary>
        public T Value
            {
            get;
            private set;
            }
        /// <summary>
        /// Pointer to the next node
        /// </summary>
       public Node<T> Next
            {
            get;
            internal set;
            }

        /// <summary>
        ///Pointer to the previous node 
        /// </summary>
        public Node<T> Previous
            {
            get;
            internal set;
            }

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="item"></param>
        internal Node (T item)
            {
            this.Value = item;
            }
        }
    }
