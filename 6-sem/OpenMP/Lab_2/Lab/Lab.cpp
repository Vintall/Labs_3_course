#include <iostream>
#include <fstream>
#include <omp.h>
#include <vector>
using namespace std;

class Program
{
public:
    int size;
    vector<vector<double>> matrix;

    Program()
    {
        InitProg();
        InitMatrix();
        Menu();
        CalcMethod();
    }
    void Menu() 
    {
        int choice = 0;
        cout << "How to fill matrix?" << endl;
        cout << "1) Manually" << endl;
        cout << "2) From file" << endl;
        cout << "3) Randomly" << endl;
        cin >> choice;

        switch (choice)
        {
        case 1:
            FillByHand();   break;
        case 2:
            FillFromFile(); break;
        case 3:
            FillAuto();     break;
        default:
            exit(0);        break;
        }
    }
    void FillByHand()
    {
        int sum = 0;
        bool flag = true;

        system("cls");
        cout << "Define matrix:" << endl;
        for (int i = 0; i < size; ++i)
        {
            sum = 0;
            matrix[i].resize(size + 1);
            for (int j = 0; j < size; ++j)
            {
                cout << "[" << i << ", " << j << "]: ";
                cin >> matrix[i][j];

                if (i != j)
                {
                    sum += abs(matrix[i][j]);
                }
            }
            if (sum >= abs(matrix[i][i]))
            {
                flag = false;
                break;
            }
            cout << "Vec[" << i << "]: ";
            cin >> matrix[i][size];
        }
        if (flag)
        {
            return;
        }

        cout << "The entered matrix has no diagonal domain." << endl;
        system("pause");
        exit(0);
    }
    void FillAuto()
    {
        for (int i = 0; i < size; ++i)
        {
            matrix[i].resize(size + 1);
            matrix[i][i] = 0;
            for (int j = 0; j <= size; ++j)
            {
                if (i != j)
                {
                    matrix[i][j] = rand() % 10;
                    matrix[i][i] += matrix[i][j];
                }
            }
            matrix[i][i] += (rand() % 10) + 1;
        }
    }
    void FillFromFile()
    {
        int sum = 0;
        bool flag = true;
        ifstream input("input.in", ifstream::in);

        system("cls");
        for (int i = 0; i < size; ++i)
        {
            sum = 0;
            matrix[i].resize(size + 1);
            for (int j = 0; j < size; ++j)
            {
                input >> matrix[i][j];

                if (i != j)
                {
                    sum += abs(matrix[i][j]);
                }
            }
            if (sum >= abs(matrix[i][i]))
            {
                flag = false;
                break;
            }
            input >> matrix[i][size];
        }
        input.close();
        if (flag)
        {
            return;
        }

        cout << "The entered matrix has no diagonal domain, try again." << endl;
        system("pause");
        exit(0);
    }
    void InitProg()
    {
        srand(time(0));
        setlocale(0, "");
    }
    void InitMatrix()
    {
        cout << "Define matrix size: ";
        cin >> size;
        matrix.resize(size);
    }
    void CalcMethod()
    {
        int threads_count;
        double accuracy;
        cout << "Define accuracy: "; 
        cin >> accuracy;
        cout << "Define thread count: "; 
        cin >> threads_count;
        omp_set_num_threads(threads_count);

        vector<double> buff = vector<double>(size);
        vector<double> result = vector<double>(size);

        for (int i = 0; i < size; ++i)
        {
            buff[i] = matrix[i][size];
        }

        double start_timer;
        double end_timer;
        double error;
        start_timer = omp_get_wtime();
        int iteration_count = 0;

        for (; true; iteration_count++)
        {
            error = 0;
#pragma omp parallel for
            for (int i = 0; i < size; i++)
            {
                result[i] = matrix[i][size] / matrix[i][i];
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        result[i] -= matrix[i][j] / matrix[i][i] * buff[j];
                    }
                }
                if (error < abs(result[i] - buff[i]))
                {
                    error = abs(result[i] - buff[i]);
                }
            }
            if (error < accuracy)
            {
                break;
            }
#pragma omp parallel for
            for (int i = 0; i < size; i++)
            {
                buff[i] = result[i];
            }
        }
        end_timer = omp_get_wtime();
        cout << "Time: " << (end_timer - start_timer) * 1000 << " ms" << endl;
        cout << "Iteration count: " << iteration_count << endl;

        int show_or_not;
        cout << "Show system roots?" << endl;
        cout << "1) Yes" << endl;
        cout << "2) No" << endl;
        cin >> show_or_not;
        if (show_or_not == 1)
        {
            for (int i = 0; i < size; i++)
            {
                cout << result[i] << endl;
            }
        }
    }
};
int main()
{
    Program prog = Program();
    return 0;
}
