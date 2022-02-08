using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Метод прогонки
    /// </summary>
    internal class ThomasMethod : CalcMethod
    {
        public override double[] Use()
        {
            int len = g.Length;
            double[] result = new double[len];
            double[] calc_m = new double[len];
            double[] calc_g = new double[len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.Write(g[i]);
                Console.WriteLine();
            }

            double a, b, c;

            a = matrix[0, 1];
            b = matrix[0, 0];

            calc_m[0] = a / b;
            calc_g[0] = g[0] / b;

            
            for (int i = 1; i < len-1; i++)
            {
                a = matrix[i, i + 1];
                b = matrix[i, i];
                c = matrix[i, i - 1];

                calc_m[i] = a / (b - c * calc_m[i - 1]);
                calc_g[i] = (g[i] - c * calc_g[i - 1]) / (b - c * calc_m[i - 1]);
            }

            b = matrix[len - 1, len - 1];
            c = matrix[len - 1, len - 2];

            result[result.Length - 1] = (g[len - 1] - c * calc_g[len - 2]) / (b - c * calc_m[len - 2]);

            Console.WriteLine(result[result.Length - 1]);

            for (int i = len - 2; i >= 0; i--)
            {
                result[i] = calc_g[i] - calc_m[i] * result[i + 1];
                Console.WriteLine(result[i]);  
            }

            Console.ReadKey();
            return result;
        }
    }
}
