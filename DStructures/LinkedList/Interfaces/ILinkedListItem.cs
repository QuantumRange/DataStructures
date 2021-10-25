using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DStructures.LinkedList;

namespace DStructures.LinkedList.Interfaces
{
    public interface ILinkedListItem
    {
        ILinkedListItem Next { get; set; }
        int Data { get; set; }



    }
}
