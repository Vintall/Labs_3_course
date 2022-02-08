using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] thomas_matrix = new double[,]
            {
                { -11, 9,  0,   0,  0 },
                { -9,  17, 6,   0,  0 },
                {  0,  5,  20,  8,  0 },
                {  0,  0, -6,  -20, 7 },
                {  0,  0,  0,   2,  8 }
            };
            double[] thomas_g = new double[]
                { -117, -97, -6, 59, -86};

            double[,] square_matrix = new double[,]
            {
                { 14, 2,  -10},
                { 2,  -18, -8},
                {  -10,  -8,  28}
            };
            double[] square_g = new double[]
                { 5, 8, 2};

            //GaussMethod method = new GaussMethod();
            //ThomasMethod method = new ThomasMethod();
            IterationMethod method = new IterationMethod();
            method.FillMatrix(square_matrix, square_g);
            method.Use();
        }
    }
}
