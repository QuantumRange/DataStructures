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
            // Adding one to the size of the LinkedList
            Count++;

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
        }

        public void RemoveAt(int i)
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            
        }

        public ILinkedListItem GetAt(int i)
        {
            throw new NotImplementedException();
        }

        public ILinkedListItem GetLast()
        {
            throw new NotImplementedException();
        }
    }
}
