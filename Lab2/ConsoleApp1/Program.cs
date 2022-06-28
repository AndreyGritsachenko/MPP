using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CulculateResult(2, 1_000);
            CulculateResult(4, 1_000);
            CulculateResult(6, 1_000);
            CulculateResult(10, 1_000);
            CulculateResult(12, 1_000);
            CulculateResult(14, 1_000);
            CulculateResult(16, 1_000);
            CulculateResult(2, 100_000);
            CulculateResult(4, 100_000);
            CulculateResult(6, 100_000);
            CulculateResult(10, 100_000);
            CulculateResult(12, 100_000);
            CulculateResult(14, 100_000);
            CulculateResult(16, 100_000);
            CulculateResult(2, 1_000_000);
            CulculateResult(4, 1_000_000);
            CulculateResult(6, 1_000_000);
            CulculateResult(10, 1_000_000);
            CulculateResult(12, 1_000_000);
            CulculateResult(14, 1_000_000);
            CulculateResult(16, 1_000_000);
        }

        public static void CulculateResult(int numberOfThreds, int numberOfElements)
        {
            Stopwatch stopwatch = new Stopwatch();
            var sum = 0l;
            TestClass testClass = new TestClass(numberOfThreds, numberOfElements);

            for(int i = 0; i < 5; i++)
            {
                stopwatch = Stopwatch.StartNew();

                testClass.Compute();

                stopwatch.Stop();
                sum = sum + stopwatch.ElapsedMilliseconds;
            }
            Console.WriteLine($"Total execution time for {numberOfThreds} threads for {numberOfElements} elements: {sum / 5}ms");
        }

    }
}
