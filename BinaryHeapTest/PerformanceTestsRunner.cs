using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryHeapTest
{
    public interface PerformanceTest
    {
        void Setup();
        void Execute();
        void Teardown();
    }

    class PerformanceTestsRunner
    {
        static void Main(string[] args)
        {
            new TestExecutor()
            .AddTest<BinaryHeapBenchmarks.InsertAverage>("insert")
            .AddTest<BinaryHeapBenchmarks.InsertBest>("insertBest")
            .AddTest<BinaryHeapBenchmarks.InsertWorst>("insertWorst")
            .Execute(args[0]);
        }
    }

    class HelloWorldTest : PerformanceTest
    {
        public void Execute()
        {
            Console.WriteLine("Hello, execute!");
        }

        public void Setup()
        {
            Console.WriteLine("Hello, setup!");
        }

        public void Teardown()
        {
            Console.WriteLine("Hello, teardown!");
        }
    }

    class TestExecutor
    {
        Dictionary<string, Type> m_Tests = new Dictionary<string, Type>();
        static Type m_PerfTestType = typeof(PerformanceTest);

        public TestExecutor AddTest<T>(string name) where T : PerformanceTest
        {
            m_Tests.Add(name, typeof(T));
            return this;
        }
        
        public void Execute(string name)
        {
            Type testType = m_Tests[name];
            PerformanceTest instance = (PerformanceTest)Activator.CreateInstance(testType);
            instance.Setup();
            GC.Collect();
            Thread.Sleep(2000);
            instance.Execute();
            instance.Teardown();
        }
    }
}
