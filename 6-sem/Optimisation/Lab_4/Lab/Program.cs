#region Methods
double five_sqrt = Math.Sqrt(5);

double Fibonacci(int n) => (Math.Pow((1 + five_sqrt) / 2, n) - Math.Pow((1 - five_sqrt) / 2, n)) / five_sqrt; //Bine's formula 
(int, double) Метод_ділення_навпіл()
{
    List<double> a = new List<double>();
    List<double> b = new List<double>();

    List<double> x1 = new List<double>();
    List<double> x2 = new List<double>();

    int iteration_count = 0;
    a.Add(MyInput.a_border); // First [0] state
    b.Add(MyInput.b_border);
    double a_buff;
    double b_buff;
    int last_buff;
    for (; b[b.Count - 1] - a[a.Count - 1] > MyInput.error; iteration_count++)
    {
        last_buff = a.Count - 1;
        a_buff = a[last_buff];
        b_buff = b[last_buff];

        x1.Add((a_buff + b_buff - MyInput.error / 10) / 2);
        x2.Add((a_buff + b_buff + MyInput.error / 10) / 2);

        if (MyInput.MyFunction(x1[last_buff]) <= MyInput.MyFunction(x2[last_buff]))
        {
            a.Add(a[last_buff]);
            b.Add(x2[last_buff]);
        }
        else
        {
            a.Add(x1[last_buff]);
            b.Add(b[last_buff]);
        }
    }
    Console.WriteLine("A: " + a[a.Count - 1] + "   B: " + b[b.Count - 1]);
    return (iteration_count, (MyInput.MyFunction(x1[x1.Count - 1]) + MyInput.MyFunction(x2[x2.Count - 1])) / 2);
}
(int, double) Метод_золотого_перетину()
{
    List<double> a = new List<double>();
    List<double> b = new List<double>();

    List<double> x1 = new List<double>();
    List<double> x2 = new List<double>();

    int iteration_count = 0;
    a.Add(MyInput.a_border); // First [0] state
    b.Add(MyInput.b_border);

    double a_buff;
    double b_buff;
    int last_buff;

    for (; b[b.Count - 1] - a[a.Count - 1] > MyInput.error; iteration_count++)
    {
        last_buff = a.Count - 1;
        a_buff = a[last_buff];
        b_buff = b[last_buff];

        x1.Add(a_buff + (3 - five_sqrt) * (b_buff - a_buff) / 2);
        x2.Add(a_buff + (five_sqrt - 1) * (b_buff - a_buff) / 2);

        if (MyInput.MyFunction(x1[last_buff]) <= MyInput.MyFunction(x2[last_buff]))
        {
            a.Add(a[last_buff]);
            b.Add(x2[last_buff]);
        }
        else
        {
            a.Add(x1[last_buff]);
            b.Add(b[last_buff]);
        }
    }
    Console.WriteLine("A: " + a[a.Count - 1] + "   B: " + b[b.Count - 1]);
    return (iteration_count, (MyInput.MyFunction(x1[x1.Count - 1]) + MyInput.MyFunction(x2[x2.Count - 1])) / 2);
}
(int, double) Метод_Фібоначчі()
{
    double fibb_n0 = Fibonacci(MyInput.fibbo_iter_count);
    double fibb_n1 = Fibonacci(MyInput.fibbo_iter_count + 1);
    double fibb_n2 = Fibonacci(MyInput.fibbo_iter_count + 2);

    List<double> a = new List<double>();
    List<double> b = new List<double>();

    List<double> x1 = new List<double>();
    List<double> x2 = new List<double>();

    int iteration_count = MyInput.fibbo_iter_count;
    a.Add(MyInput.a_border); // First [0] state
    b.Add(MyInput.b_border);
    double a_buff;
    double b_buff;
    int last_buff;
    for (; iteration_count > 0; iteration_count--) 
    {
        last_buff = a.Count - 1;
        a_buff = a[last_buff];
        b_buff = b[last_buff];

        x1.Add(a_buff + (b_buff - a_buff) * (fibb_n0 / fibb_n2));
        x2.Add(a_buff + (b_buff - a_buff) * (fibb_n1 / fibb_n2));

        if (MyInput.MyFunction(x1[last_buff]) <= MyInput.MyFunction(x2[last_buff]))
        {
            a.Add(a[last_buff]);
            b.Add(x2[last_buff]);
        }
        else
        {
            a.Add(x1[last_buff]);
            b.Add(b[last_buff]);
        }
    }
    Console.WriteLine("A: " + a[a.Count - 1] + "   B: " + b[b.Count - 1]);
    return (MyInput.fibbo_iter_count, (MyInput.MyFunction(x1[x1.Count - 1]) + MyInput.MyFunction(x2[x2.Count - 1])) / 2);
}

#endregion Methods

#region Output
Console.OutputEncoding = System.Text.Encoding.UTF8;
(int, double) output;

Console.WriteLine("Метод ділення навпіл: ");
output = Метод_ділення_навпіл();
Console.WriteLine("Кількість ітерацій: " + output.Item1.ToString());
Console.WriteLine("Результат: " + output.Item2.ToString());
Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");

Console.WriteLine("1) " + MyInput.MyFunction(output.Item2));

Console.WriteLine("Метод золотого перетину: ");
output = Метод_золотого_перетину();
Console.WriteLine("Кількість ітерацій: " + output.Item1.ToString());
Console.WriteLine("Результат: " + output.Item2.ToString());
Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");

Console.WriteLine("2) " + MyInput.MyFunction(output.Item2));

Console.WriteLine("Метод Фібоначчі: ");
output = Метод_Фібоначчі();
Console.WriteLine("Кількість ітерацій: " + output.Item1.ToString());
Console.WriteLine("Результат: " + output.Item2.ToString());
Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");

Console.WriteLine("3) " + MyInput.MyFunction(output.Item2));
#endregion Output

static public class MyInput
{
    public static double MyFunction(double x) => (x * x - 1) / (x * x - 4); // returns y
    public const double a_border = -1;
    public const double b_border = 1;
    public const double error = 0.0001;
    public const int fibbo_iter_count = 21;
}

