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
            Stopwatch stopwatch = new Stopwatch();
            int numberOfThreds = 2;
            var sum = 0l;
            TestClass testClass = new TestClass(numberOfThreds);
            stopwatch.Start();

            testClass.Compute();
            stopwatch.Stop();
            
            sum = sum + stopwatch.ElapsedMilliseconds;

            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            Console.WriteLine($"Total execution time for {numberOfThreds} threads: {sum/5}ms");

            sum = 0;
            numberOfThreds = 10;
            testClass = new TestClass(numberOfThreds);

            stopwatch = Stopwatch.StartNew();

            testClass.Compute();
            stopwatch.Stop();

            sum = sum + stopwatch.ElapsedMilliseconds;

            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            stopwatch = Stopwatch.StartNew();

            testClass.Compute();

            stopwatch.Stop();
            sum = sum + stopwatch.ElapsedMilliseconds;


            Console.WriteLine($"Total execution time for {numberOfThreds} threads: {sum / 5}ms");
        }

    }
}
