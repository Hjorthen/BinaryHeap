using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Heap;

namespace BinaryHeapTest
{
    class Test
    {
       static void Main(string[] args)
        {
            BinaryHeap<int> HeapTree = new BinaryHeap<int>();
            int[] arr = { 2, 5, 10, 22, 50, 52, 42 };

            HeapTree.InsertRange(arr);

            Console.Write("Hello, World!" + HeapTree.ToString());
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\n" + HeapTree.Extract());

            }

            arr = new int[] { 255, 90, 30, 22, 512,2,1,0};
            HeapTree.InsertRange(arr);
            Console.Write("\nPass two:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\n" + HeapTree.Extract());

            }
            Console.ReadLine();
        }
    }
}
