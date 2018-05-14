using Binary_Heap;
using NUnit.Framework;
using System;

namespace UnitTests
{

    class MockMinHeap : BinaryMinHeap<int>
    {
        public int[] GetData()
        {
            return Collection.ToArray();
        }
    }
    [TestFixture]
    public class BinaryHeapTests
    {
        [Test]
        public void MinHeapOrdering()
        {
            BinaryMinHeap<int> heap = new BinaryMinHeap<int>();
            int[] values = new int[50];

            Random rng = new Random(0xCEA);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = rng.Next();
            }

            foreach(int i in values)
            {
                heap.Insert(i);
            }

            Array.Sort(values, (a, b) => a - b);

            int index = 0;
            while(heap.Size > 0)
            {
                Assert.AreEqual(values[index], heap.Extract());
                ++index;    
            }

            Assert.AreEqual(values.Length, index);
        }

        [Test]
        public void MaxHeapOrdering()
        {
            BinaryMaxHeap<int> heap = new BinaryMaxHeap<int>();
            int[] values = new int[50];

            Random rng = new Random(0xCEA);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = rng.Next();
            }

            foreach (int i in values)
            {
                heap.Insert(i);
            }

            Array.Sort(values, (a, b) => b - a);

            int index = 0;
            while (heap.Size > 0)
            {
                Assert.AreEqual(values[index], heap.Extract());
                ++index;
            }

            Assert.AreEqual(values.Length, index);
        }

        [Test]
        public void MaxStaysNearRoot()
        {
            MockMinHeap heap = new MockMinHeap();
            heap.Insert(5);
            heap.Insert(4);
            heap.Insert(3);
            heap.Insert(2);
            heap.Insert(1);
            heap.Insert(0);
            int[] data = heap.GetData();
            Assert.AreEqual(5, data[0]);

            // Insert one larger element, check that 5 is a child
            heap.Insert(6);
            data = heap.GetData();
            Assert.AreEqual(6, data[0]);
            Assert.True(data[1] == 5 || data[2] == 5);
        }
    }
}