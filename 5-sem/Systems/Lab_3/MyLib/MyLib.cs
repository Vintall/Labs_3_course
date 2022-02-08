namespace MyLib
{
    public class MyLib
    {
        public static double[,] CalcMatrix(double[,] matrix)
        {
            int size = (int)Math.Sqrt(matrix.Length);
            double[,] result = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrix[i, j];

                    if (result[i, j] < 0)
                        result[i, j] *= result[i, j];
                }
            }
            return result;
        }
    }
}