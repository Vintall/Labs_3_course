using MyLib;

Console.Write("Введите размер матрицы (NxN): ");
int size = int.Parse(Console.ReadLine());
double[,] matrix = new double[size, size];

for(int i = 0; i < size; i++)
    for(int j = 0; j < size; j++)
    {
        Console.Write("a[" + (i + 1) + ", " + (j + 1) + "]= ");
        matrix[i, j] = double.Parse(Console.ReadLine());
    }
matrix = MyLib.MyLib.CalcMatrix(matrix);

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        Console.Write(matrix[i, j] + "   ");
    }
    Console.WriteLine();
}