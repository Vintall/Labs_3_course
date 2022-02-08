using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class SquareMethod : CalcMethod
    {
        public override double[] Use()
        {
            int len = g.Length;
            double[,] calc_matrix = new double[len, len];
            double[] calc_g = new double[len];
            double[] result = new double[len];
            double[,] above_matrix = new double[len, len];
            double[,] below_matrix = new double[len, len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    calc_matrix[i, j] = matrix[i, j];
                    if (i >= j)
                        below_matrix[i, j] = matrix[i, j];
                    if (i <= j)
                        above_matrix[i, j] = matrix[i, j];
                }
                calc_g[i] = g[i];
            }


            for (int i = 0; i < len; i++)
                Console.WriteLine(result[i]);
            Console.ReadKey();
            return result;
        }
    }
}
