namespace Lab1
{
    public class CpuMemoryBound
    {
        private Matrix matrixUtils;
        private int threadsAmount;
        private int matrixAmount;
        private const int CPUBOUNDMATRIXSIZE = 20;
        private const int MEMORYBOUNDMATRIXSIZE = 500;

        public CpuMemoryBound(int threadsAmount, int matrixAmount)
        {
            this.threadsAmount = threadsAmount;
            this.matrixAmount = matrixAmount;
            this.matrixUtils = new Matrix();
        }

        public void executeCpuBound()
        {
            DateTime startTime = DateTime.UtcNow;
            execute(CPUBOUNDMATRIXSIZE, CPUBOUNDMATRIXSIZE);
            DateTime endTime = DateTime.UtcNow;
            Console.WriteLine($"CpuBound total execution time: {endTime - startTime}");
        }

        public void executeMemoryBound()
        {
            DateTime startTime = DateTime.UtcNow;
            execute(MEMORYBOUNDMATRIXSIZE, MEMORYBOUNDMATRIXSIZE);
            DateTime endTime = DateTime.UtcNow;
            Console.WriteLine($"MemoryBound total execution time: {endTime - startTime}");
        }

        public void execute(int n, int m)
        {
            List<int[,]> matrixes = matrixUtils.GenerateMatrix(n, m, matrixAmount);
            int limit = matrixes.Count / threadsAmount;
            splitList(limit, matrixes).ForEach(matrixList => new Thread(()=>matrixUtils.MultiplyMatrixBulk(matrixList)).Start());
        }

        List<List<int[,]>> splitList(int limit, List<int[,]> matrixes)
        {
            List<List<int[,]>> splitedList = new List<List<int[,]>>();
            int steps = matrixes.Count / limit;
            for (int i = 0; i < steps; i++)
            {
                splitedList.Add(matrixes.Skip(limit * i).ToList());
            }
            return splitedList;
        }

    }
}
