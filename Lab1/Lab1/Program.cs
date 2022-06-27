namespace Lab1
{
    class Program
    {
        public static void Main()
        {
            int threadCount = 10;
            Console.WriteLine($"Thread count {threadCount}");
            CpuMemoryBound executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            IoBound ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 30;
            Console.WriteLine($"Thread count{threadCount}");
            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();

            threadCount = 50;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.ExecuteCpuBound();
            executor.ExecuteMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.Execute();
        }
    }
    
}

