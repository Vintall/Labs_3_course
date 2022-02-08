using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Метод Гаусса
    /// </summary>
    public class GaussMethod : CalcMethod
    {
        public override double[] Use()
        {
            double[,] calc_matrix = matrix;
            double[] calc_g = g;
            double[] result = new double[g.Length];

            double divider;
            for (int i = 0; i < calc_g.Length; i++)
            {
                for (int j = i; j < calc_g.Length; j++)
                {
                    divider = calc_matrix[j, i];
                    for (int k = i; k < calc_g.Length; k++)
                    {
                        calc_matrix[j, k] /= divider;
                    }
                    calc_g[j] /= divider;
                }
                for (int j = i + 1; j < calc_g.Length; j++)
                {
                    for (int k = 0; k < calc_g.Length; k++)
                    {
                        calc_matrix[j, k] -= calc_matrix[i, k];
                    }
                    calc_g[j] -= calc_g[i];
                }
            }
            for (int i = calc_g.Length - 1; i >= 0; i--)
            {
                double res_elem = calc_g[i];
                for (int j = calc_g.Length - 1; j > i; j--)
                {
                    res_elem -= result[j] * calc_matrix[i, j];
                }
                result[i] = Math.Round(res_elem, 5);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < calc_g.Length; i++)
            {
                Console.WriteLine(i + ") = " + result[i]);
            }

            Console.ReadKey();
            return result;
        }
    }
}
