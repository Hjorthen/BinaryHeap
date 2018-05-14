using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Binary_Heap
{
    abstract public class BinaryHeap<T> where T : IComparable<T>
    {
        protected List<T> Collection;

        public int Size
        {
            get
            {
                return Collection.Count;
            }
        }
       
        public BinaryHeap()
        {
            Collection = new List<T>();
        }

        /// <summary>
        /// Returns the index of the bottom of the heap
        /// </summary>
        /// <returns>The index of the bottom heap node</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int GetLastNodeIndex()
        {
            return Collection.Count - 1;
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
            if (Collection.Count == 0)
            {
                throw new System.InvalidOperationException("The tree is empty!");
            }

            //Gets the root node
            T baseNode = Collection[0];
            Collection[0] = Collection[GetLastNodeIndex()];
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

        void BubbleSortUp(int startNodeIndex)
        {
            int current = startNodeIndex;
            int parent = GetParentIndex(current);

            while (current > 0 && CompareNodes(current, parent))
            {
                Swap(current, parent);
                current = parent;
                parent = GetParentIndex(current);
            }
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
        /// returns true if the first element is smaller than the one compared to
        /// </summary>
        protected abstract bool CompareNodes(int index1, int index2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int GetParentIndex(int childIndex)
        {
            return ((childIndex - 1) / 2);
        }

        /// <summary>
        /// Gets the index of the left child of the index
        /// </summary>
        /// <param name="parentIndex">The index of the node to find the child of</param>
        /// <returns>the index location of the left child</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int GetLeftChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 1);
        }

        /// <summary>
        /// Gets the index of the right child of the index
        /// </summary>
        /// <param name="parentIndex">The index of the node to find the child of</param>
        /// <returns>the index location of the right child</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int GetRightChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 2);
        }



    }
}
