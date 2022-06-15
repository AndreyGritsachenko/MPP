namespace Lab1
{
    public class Matrix
    {
        public void MultiplyMatrixes(int[,] firstMatrix, int[,] secondMatrix)
        {
            int m = firstMatrix.GetLength(0);
            int n = secondMatrix.GetLength(1);
            int o = secondMatrix.GetLength(0);
            int[,] res = new int[m,n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < o; k++)
                    {
                        Thread.Sleep(1);
                        res[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
        }

        public List<int[,]> GenerateMatrix(int m, int n, int matrixAmount)
        {
            Random random = new Random();
            List <int[,]> arrays = new List<int[,]>();
            for (int k = 0; k < matrixAmount; k++)
            {
                int[,] matrix = new int[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = random.Next(1000);
                    }
                }
                arrays.Add(matrix);
            }
            return arrays;
        }

        public void MultiplyMatrixBulk(List<int[,]> matrixes)
        {
            for (int i = 0; i < matrixes.Count - 1; i++)
            {
                MultiplyMatrixes(matrixes[i], matrixes[i + 1]);
            }
        }
    }
}
