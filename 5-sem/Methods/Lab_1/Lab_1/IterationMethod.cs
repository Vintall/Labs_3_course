using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Метод итераций
    /// </summary>
    internal class IterationMethod : CalcMethod
    {
        double eps = 0.0000001;
        public override double[] Use()
        {
            int len = g.Length;
            double[,] calc_matrix = new double[len, len];
            double[] calc_g = new double[len];
            double[] result = new double[len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    calc_matrix[i, j] = matrix[i, j];
                }
                calc_g[i] = g[i];
            }

            #region IterationFormConverter
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i != j) 
                    calc_matrix[i, j] /= -calc_matrix[i, i];
                }
                calc_g[i] /= calc_matrix[i, i];
                calc_matrix[i, i] = 0;
            }
            #endregion
            
            int max = 0, min = 0;
            for (int i = 0; i < len; i++) 
            {
                if (g[i] > g[max])
                    max = i;
                if (g[i] < g[min])
                    min = i;
            }
            for (int j = 0; j < len; j++)
                result[j] = (g[min] + g[max]) / 2;

            double[] res_buff = result;
            double[] del = new double[len];

            for (bool first_sw = true; first_sw ; )
            //for (int a = 0; a < 50; a++)
                {
                double sum = 0;
                double buff = 0;
                bool sec_sw = false;
                for (int i = 0; i < len; i++)
                {
                    buff = 0;
                    for (int j = 0; j < len; j++)
                    {
                        buff += calc_matrix[i, j] * result[j];
                    }
                    res_buff[i] = buff + calc_g[i];
                }
                result = res_buff;

                for (int i = 0; i < len; i++)
                {
                    sum = 0;
                    for (int j = 0; j < len; j++)
                    {
                        sum += matrix[i, j] * result[j];
                    }
                    del[i] = sum - g[i];
                    if (Math.Abs(del[i]) >= eps)
                        sec_sw = true;
                }
                first_sw = sec_sw;
            }
            int round_count = 0;
            for (int a = (int)(1 / eps); a>1 ; a /= 10) 
                round_count++;

            for (int i = 0; i < len; i++)
            {
                result[i] = Math.Round(result[i], round_count);
                Console.WriteLine(result[i]);
            }

            Console.ReadKey();
            return result;
        }
    }
}
