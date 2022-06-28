namespace Lab1
{
    class Program
    {
        public static void Main()
        {
            int threadCount = 2;
            Console.WriteLine($"Thread count {threadCount}");
            CpuMemoryBound executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            IoBound ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 4;
            Console.WriteLine($"Thread count{threadCount}");
            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 6;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 10;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 12;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 14;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

        }
    }
    
}

