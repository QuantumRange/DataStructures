using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DStructures.LinkedList;

namespace DStructures.LinkedList.Interfaces
{
    public interface ILinkedList
    {
        ILinkedListItem First { get; set; }
        int Count { get; }

        void Add(ILinkedListItem item);
        void RemoveAt(int i);
        void RemoveLast();
        ILinkedListItem GetAt(int i);
        ILinkedListItem GetLast();

    }
}
