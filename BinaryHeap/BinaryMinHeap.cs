using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Heap
{
    public class BinaryMinHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {
        protected override bool CompareNodes(int index1, int index2)
        {
                return Collection[index1].CompareTo(Collection[index2]) < 0;
        }

    }
}
