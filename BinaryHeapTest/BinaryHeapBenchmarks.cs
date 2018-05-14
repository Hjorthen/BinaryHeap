using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapTest.BinaryHeapBenchmarks
{
    public class InsertAverage : PerformanceTest
    {
        const int kIterationCount = 100000000;
        public Binary_Heap.BinaryMaxHeap<int> heap;
        public void Execute()
        {
            Random dataGen = new Random(0xBEEF);
            for (int i = 0; i < kIterationCount; i++)
            {
                heap.Insert(dataGen.Next());
            }
        }

        public void Setup()
        {
            heap = new Binary_Heap.BinaryMaxHeap<int>();
        }

        public void Teardown()
        {
            heap = null;
        }
    }

    public class InsertBest : PerformanceTest
    {
        const int kIterationCount = 100000000;
        public Binary_Heap.BinaryMaxHeap<int> heap;
        public void Execute()
        {
            for (int i = kIterationCount; i >= 0; --i)
            {
                heap.Insert(i);
            }
        }

        public void Setup()
        {
            heap = new Binary_Heap.BinaryMaxHeap<int>();
        }

        public void Teardown()
        {
            heap = null;
        }
    }

    public class InsertWorst : PerformanceTest
    {
        const int kIterationCount = 100000000;
        public Binary_Heap.BinaryMaxHeap<int> heap;
        public void Execute()
        {
            Random dataGen = new Random(0xBEEF);
            for (int i = 0; i < kIterationCount; i++)
            {
                heap.Insert(i);
            }
        }

        public void Setup()
        {
            heap = new Binary_Heap.BinaryMaxHeap<int>();
        }

        public void Teardown()
        {
            heap = null;
        }
    }
}
