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
        public ILinkedListItem Last { get; set; }
        public int Count { get; }
        
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
        /// <param name="item">is the value </param>
        public void Add(ILinkedListItem item)
        {
            
        }

        public void RemoveAt(int i)
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
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
