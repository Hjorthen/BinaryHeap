using System;
using Binary_Heap;

namespace BinaryHeapTest
{
    class Test
    {
       static int TestSize = 10000000;

       static void Main(string[] args)
        {
            BinaryHeap<int> HeapTree = new BinaryMinHeap<int>();

            int[] arr = new int[TestSize];
            Random rng = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("Generating random values..");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rng.Next();
            }

            Console.WriteLine("Adding to tree..");
            HeapTree.InsertRange(arr);

            Console.WriteLine("Running tests...");
            try
            {
                int prevValue = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    
                    int currentVaue = HeapTree.Extract();
                    Console.Write(currentVaue + "\n");
                    if (prevValue!=0 && prevValue > currentVaue)
                    {
                        throw new System.ApplicationException("The order in the source tree was wrong!");
                    }
                    prevValue = currentVaue;
                }
                Console.WriteLine("Test successfull!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n " + e.Message + "\n\n" + e.StackTrace);
                
            }
            


            Console.ReadLine();
        }
    }
}
