using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Heap
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        List<T> Collection;

        public BinaryHeap()
        {
            Collection = new List<T>();
        }

        /// <summary>
        /// Returns the index of the bottom of the heap
        /// </summary>
        /// <returns>The index of the bottom heap node</returns>
        int GetLastNodeIndex()
        {
            return Collection.Count - 1;
        }

        T GetBaseNode()
        {
            return Collection[0];
        }

      
        /// <summary>
        /// Inserts a range of elements by calling Insert on each of them
        /// </summary>
        /// <param name="vars">A range of elements to be added to the heap</param>
        public void InsertRange(params T[] vars)
        {
            foreach(T element in vars)
            {
                Insert(element);
            }
        }


        /// <summary>
        /// Inserts a single element to the tree
        /// </summary>
        /// <param name="element">The element to be added</param>
        public void Insert(T element)
        {
            Collection.Add(element);
            //Sorts the tree 
            BubbleSortUp(GetLastNodeIndex());
        }


         /// <summary>
         /// Gets the base node and removes it from the tree
         /// </summary>
         /// <returns>The value of the base element</returns>
        public T Extract()
        {
            //Gets the base node
            T baseNode = GetBaseNode();

            //Swaps the base node with the last node
            Swap(0, GetLastNodeIndex());

            //Removes the base node
            Collection.RemoveAt(GetLastNodeIndex());
            BubbleSortDown(0);
            return baseNode;
        }


        public override string ToString()
        {
            return String.Format("Tree size: {0}, Height: {1}", Collection.Count, GetDepth());
        }

        /// <summary>
        /// Gets depth of the tree
        /// </summary>
        /// <returns>Amount of steps the tree has</returns>
        double GetDepth()
        {
            return Math.Floor(Math.Log((double)Collection.Count, 2.0));
        }

        void BubbleSortUp(int childNodeIndex)
        {
            int parentNodeIndex = GetParentIndex(childNodeIndex);

            //If parent is less than zero, then the current node is the root. 
            if(parentNodeIndex >= 0)
            {
                if(CompareNodes(childNodeIndex, parentNodeIndex))
                {
                    Swap(childNodeIndex, parentNodeIndex);

                    //Move onto the next node
                    BubbleSortUp(parentNodeIndex);
                    return; 
                }
                return;
            }
            return;
        }

        void BubbleSortDown(int NodeIndex)
        {
            int childValue;
            if((childValue = GetLeftChildIndex(NodeIndex)) < Collection.Count)
            {
                if(CompareNodes(childValue, NodeIndex))
                {
                    Swap(childValue, NodeIndex);
                    BubbleSortDown(childValue);
                }

            }
            if((childValue = GetRightChildIndex(NodeIndex)) < Collection.Count)
            {
                if (CompareNodes(childValue, NodeIndex))
                {
                    Swap(childValue, NodeIndex);
                    BubbleSortDown(childValue);
                }

            }

        }

        /// <summary>
        /// returns true if the first element is smaller than the compared to, then the two nodes should be swapped 
        /// </summary>
        bool CompareNodes(int index1, int index2)
        {
            return Collection[index1].CompareTo(Collection[index2]) < 0;
        }

        void Swap(int index1, int index2)
        {
            T tmp = Collection[index1];
            Collection[index1] = Collection[index2];
            Collection[index2] = tmp;
        }

        /// <summary>
        /// Gets the parent's position of a child in the tree
        /// </summary>
        /// <param name="childIndex">The child node's index to find the parent of</param>
        /// <returns>The index of the parent node</returns>
        int GetParentIndex(int childIndex)
        {
            return ((childIndex - 1) / 2);
        }

        /// <summary>
        /// Gets the index of the left child of the index
        /// </summary>
        /// <param name="parentIndex">The index of the node to find the child of</param>
        /// <returns>the index location of the left child</returns>
        int GetLeftChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 1);
        }

        /// <summary>
        /// Gets the index of the right child of the index
        /// </summary>
        /// <param name="parentIndex">The index of the node to find the child of</param>
        /// <returns>the index location of the right child</returns>
        int GetRightChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 2);
        }



    }
}
