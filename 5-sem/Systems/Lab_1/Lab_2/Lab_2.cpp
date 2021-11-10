#include <iostream>
#include <thread>
using namespace std;

void PowIfNegative(int* matrix, int a, int b)
{
	for (int i = a; i <= b; i++)
		if (matrix[i] < 0)
			matrix[i] = matrix[i] * matrix[i];
}
int* matrix_data;

int main()
{
	setlocale(LC_ALL, "Russian");
	matrix_data = new int[9];
	cout << "Введите элементы матрицы" << endl;
	for (int i = 0; i < 9; i++)
	{
		cout << i+1 <<": ";
		cin >> matrix_data[i];
	}

	thread thread_one(PowIfNegative, matrix_data, 0, 2);
	thread thread_two(PowIfNegative, matrix_data, 3, 5);
	thread thread_three(PowIfNegative, matrix_data, 6, 8);

	thread_one.join();
	thread_two.join();
	thread_three.join();
	cout << endl;
	for (int i = 0; i < 9; ++i)
		cout << i+1 << ": " << matrix_data[i] << endl;
}