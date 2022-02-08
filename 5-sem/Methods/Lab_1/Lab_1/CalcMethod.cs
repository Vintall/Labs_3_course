using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class CalcMethod
    {
        public double[,] matrix;
        public double[] g;

        public virtual double[] Use()
        {
            return null;
        }

        public void FillMatrix()
        {
            Console.Write("Введите кол-во уравнений: ");
            int size = int.Parse(Console.ReadLine());
            g = new double[size];
            matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write("A(" + i + ", " + j + ") = ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            for(int i = 0; i < size; i++)
            {
                Console.Write("g(" + i + ") = ");
                g[i] = double.Parse(Console.ReadLine());
            }
        }
        public void FillMatrix(double[,] matrix_, double[] g_)
        {
            
            int size = g_.Length;
            g = new double[size];
            matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = matrix_[i, j];
                }
            }
            for (int i = 0; i < size; i++)
            {

                g[i] = g_[i];
            }
        }
    }
}
