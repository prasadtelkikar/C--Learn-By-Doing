using System;
using System.Collections;
using System.Collections.Generic;
namespace LinkedList.CircularLinkedList
    {

    /// <summary>
    /// https://navaneethkn.wordpress.com/2009/08/18/circular-linked-list/
    /// </summary>
    public sealed class CircularLinkedList<T>
        {
        private int count = 0;
        Node<T> head = null;
        Node<T> tail = null;

        public int Count
            {
            get
                {
                return count;
                }
            }

        void AddFirstItem (T item)
            {
            head = new Node<T>(item);
            tail = head;
            head.Next = tail;
            head.Previous = tail;
            }

        public void AddLast (T item)
            {
            if ( head == null )
                this.AddFirstItem(item);
            else
                {
                Node<T> newNode = new Node<T>(item);
                tail.Next = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                head.Previous = newNode;
                tail = newNode;
                }
            count++;
            }

        public void AddFirst (T item)
            {
            if ( head == null )
                this.AddFirstItem(item);
            else
                {
                Node<T> newNode = new Node<T>(item);
                newNode.Next = head;
                newNode.Previous = tail;
                head.Previous = newNode;
                tail.Next = newNode;
                head = newNode;
                }
            count++;
            }
        public Node<T> Find (T item)
            {
            Node<T> node = FindNode(head, item);
            return node;
            }

        private Node<T> FindNode (Node<T> head, T valueToCompare)
            {
            Node<T> result = null;
            if ( Comparer.Equals(result.Value, valueToCompare) )
                return result;
            else if ( head.Next != null && result == null )
                result = FindNode(head.Next, valueToCompare);

            return result;
            }

        public IEnumerator<T> GetEnumerator ()
            {
            Node<T> currentNode = head;
            if ( currentNode != null )
                {
                do
                    {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                    } while ( currentNode != head );
                }
            }
        public IEnumerator<T> GetReverseEnumerator ()
            {
            Node<T> currentNode = head;
            if ( currentNode != null )
                {
                do
                    {
                    yield return currentNode.Value;
                    currentNode = currentNode.Previous;
                    } while ( currentNode != head );
                }
            }

        public bool Remove (T item)
            {
            Node<T> node = this.Find(item);
            if ( node != null )
                {
                return this.RemoveNode(node);
                }
            return false;
            }

        private bool RemoveNode (Node<T> node)
            {
            Node<T> previousNode = node.Previous;
            previousNode.Next = node.Next;
            previousNode.Next.Previous = node.Previous;

            if ( head == node )
                head = node.Next;
            if ( tail == node )
                tail = node.Previous;
            --count;

            return true;
            }
        public Node<T> this[int index]
            {
            get {
                if ( index >= count || index < 0 )
                    throw new ArgumentOutOfRangeException("index");
                else
                    {
                    Node<T> node = this.head;
                    for ( int i = 0; i < index; i++ )
                        node = node.Next;

                    return node;
                    }
                }
            }
        }
    }
