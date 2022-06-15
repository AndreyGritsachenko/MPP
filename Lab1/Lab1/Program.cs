namespace Lab1
{
    class Program
    {
        public static void Main()
        {
            int threadCount = 10;
            Console.WriteLine($"Thread count {threadCount}");
            CpuMemoryBound executor = new CpuMemoryBound(threadCount, 1000);
            executor.executeCpuBound();
            executor.executeMemoryBound();

            IoBound ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.execute();

            threadCount = 30;
            Console.WriteLine($"Thread count{threadCount}");
            executor = new CpuMemoryBound(threadCount, 1000);
            executor.executeCpuBound();
            executor.executeMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.execute();

            threadCount = 50;
            Console.WriteLine($"Thread count{threadCount}");

            executor = new CpuMemoryBound(threadCount, 1000);
            executor.executeCpuBound();
            executor.executeMemoryBound();

            ioBoundExecutor = new IoBound(threadCount);
            ioBoundExecutor.execute();
        }
    }
    
}

