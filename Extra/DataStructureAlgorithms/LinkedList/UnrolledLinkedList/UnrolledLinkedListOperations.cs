using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.UnrolledLinkedList
    {
    public class UnrolledLinkedListOperations
        {
        private ListNode<int> head;
        private ListNode<int> tail;
        private int blockSize = 0;

        public UnrolledLinkedListOperations (int blockSize)
            {
            this.blockSize = blockSize;
            }
        /// <summary>
        /// Create new block of linked list
        /// </summary>
        /// <returns>Instance of linked list block</returns>
        //public LinkedBlock<int> NewLinkedBlock ()
        //    {
        //    LinkedBlock<int> newObject = new LinkedBlock<int>();
        //    newObject.Next = null;
        //    newObject.Previous = null;
        //    newObject.NodeCount = 0;

        //    return newObject;
        //    }

        /// <summary>
        ///Create new node of linked list
        /// </summary>
        /// <param name="item">Value of new node</param>
        /// <returns>Instance of new node
        /// </returns>
        public ListNode<int> NewListNode (int item)
            {
            ListNode<int> newObject = new ListNode<int>(item);
            newObject.Next = null;
            newObject.Previous = null;

            return newObject;
            }

        /// <summary>
        /// Find the node from given list.
        /// </summary>
        /// <param name="position">Position of node in the list</param>
        /// <param name="linkedListBlock">Instance of block of linked list</param>
        /// <ret+urns>If found then print true</returns>
        public int SearchElement (int position, LinkedBlock<int> linkedListBlock)
            {
            int size = Length(linkedListBlock);
            int containedBlock = (position + linkedListBlock.BlockSize - 1) / linkedListBlock.BlockSize;
            if ( containedBlock > size )
                return 0;

            LinkedBlock<int> temp = linkedListBlock;
            while ( containedBlock-- >= 0 )
                temp = temp.Next;

            ListNode<int> headNode = null;//temp.Head;
            int positionInBlock = position % linkedListBlock.BlockSize;

            if ( positionInBlock == 0 )
                return headNode.Value;
            while ( positionInBlock-- > 0 )
                {
                headNode = headNode.Next;
                }
            return headNode.Value;
            }

        public void CreateList (LinkedBlockList<int> block, int value)
            {
            if (block.ListCount % blockSize == 0 )
                {
                LinkedBlock<int> newBlock = new LinkedBlock<int>(value);
                block.AddLast(newBlock);
                }
            else
                {
                block.Tail.List.AddLast(value);
                }
            }
        public static int Length (LinkedBlock<int> linkedListBlock)
            {
            int count = 0;
            if ( linkedListBlock == null )
                return 0;

            while ( linkedListBlock.Next != null )
                count++;
            return count;
            }
        }
    }
