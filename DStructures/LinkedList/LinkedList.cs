using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DStructures.LinkedList.Interfaces;

namespace DStructures.LinkedList
{
    public class LinkedList : ILinkedList
    {

        /// <summary>
        /// Stores the First Element of the LinkedList.
        /// </summary>
        public ILinkedListItem First { get; set; }
        
        /// <summary>
        /// Stores the Last Element of the LinkedList.
        /// </summary>
        private ILinkedListItem Last { get; set; }
        
        /// <summary>
        /// Stores the Size of the LinkedList for Performance reasons.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Initialize the values in the constructor.
        /// </summary>
        public LinkedList()
        {
            Count = 0;
        }
        
        /// <summary>
        /// Add values to the LinkedList.
        /// </summary>
        /// <param name="item">is one element of the list.</param>
        public void Add(ILinkedListItem item)
        {
            /*
             * If no items exist in the LinkedList set the First and Last Variables to the new item.
             * Otherwise set the Last variable to the item to append it.
             */
            if (First == null || Last == null)
            {
                First = item;
                Last = item;
            }
            else
            {
                // Stores the referens of the "old" last item.
                ILinkedListItem i = Last;

                // Set the new last item.
                Last = item;
                // Set the reference for the last item.
                i.Next = Last;
            }
            
            // Adding one to the size of the LinkedList
            Count++;
        }

        /// <summary>
        /// Remove the item at the index i.
        /// </summary>
        /// <param name="i">is the index of the item.</param>
        public void RemoveAt(int i)
        {
            if (i == 0)
            {
                First = First.Next;
                return;
            }
            
            // Find Item at index i
            ILinkedListItem current = First;
            if (current == null) return;
            
            for (int j = 0; j < i - 1; j++)
            {
                current = current.Next;
                
                if (current == null) return;
            }
            
            // Cut Item out of the chain
            current.Next = current.Next.Next;
            Count--;
        }

        /// <summary>
        /// Remove the Last Element on the List.
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 1)
            {
                First = null;
                Last = null;
                Count--;
                return;
            }
            
            // Find the second to the last item
            ILinkedListItem current = First;
            if (current == null) return;
            
            for (int j = 0; j < Count - 1; j++)
            {
                current = current.Next;
                
                if (current == null) return;
            }

            // Replace last item.
            current.Next = null;
            Last = current;
            Count--;
        }

        /// <summary>
        /// Return the element at index i.
        /// </summary>
        /// <param name="i">is the element id.</param>
        /// <returns></returns>
        public ILinkedListItem GetAt(int i)
        {
            // Find Element at index i
            ILinkedListItem result = First;
            
            for (int y = 0; y < i; y++)
            {
                result = result.Next;
                
                if (result == null) return null;
            }

            return result;
        }

        /// <summary>
        /// Return the Last Element of the List.
        /// </summary>
        /// <returns>The last Element.</returns>
        public ILinkedListItem GetLast()
        {
            return Last;
        }
        
    }
}
