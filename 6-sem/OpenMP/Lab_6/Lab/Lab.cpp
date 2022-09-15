#include <iostream>
#include <stdio.h>
#include <string>
#include "mpi.h"
#include <fstream>
#include <vector>
#include <chrono>

using namespace std;

int main(int argc, char* argv[])
{
    auto start = chrono::steady_clock::now();
    MPI_Init(&argc, &argv);
    int rank;
    int world_size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &world_size);


    int first_row_id;
    double** matrix_rows;
    double* my_vector;
    double* result;

    cout << "[" << rank << "] - - - rank: " << rank << endl;
    cout << "[" << rank << "] - - - world_size: " << world_size << endl;
    int rows_count;
    MPI_Status status;
    int matrix_size;

    srand(time(0) * (rank + 1));

    if (rank == 0)
    {
        cout << "[" << rank << "] - - - Define, how much rows one process must contains: ";
        
        cin >> rows_count;
        matrix_size = world_size * rows_count;
        
        my_vector = new double[matrix_size];
        
        for (int i = 0; i < matrix_size; i++)
        {
            my_vector[i] = rand() % 100;
        }

        for (int i = 1; i < world_size; i++)
        {
            MPI_Send(&rows_count, 1, MPI_INT, i, 0, MPI_COMM_WORLD);
            MPI_Send(my_vector, matrix_size, MPI_DOUBLE, i, 1, MPI_COMM_WORLD);
            cout << "[" << rank << "] - - - Send vec to: " << i << "   Matrix size is : " << matrix_size << endl;
        }
    }
    else
    {
        MPI_Recv(&rows_count, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);


        matrix_size = world_size * rows_count;
        my_vector = new double[matrix_size];

        MPI_Recv(my_vector, matrix_size, MPI_DOUBLE, 0, 1, MPI_COMM_WORLD, &status);
    }
     
    first_row_id = rank * rows_count;
    
    matrix_rows = new double* [rows_count];
    for (int i = 0; i < rows_count; i++)
    {
        matrix_rows[i] = new double[matrix_size];
        for (int j = 0; j < matrix_size; j++)
        {
            matrix_rows[i][j] = rand() % 100;
            cout << "[" << rank << "] - - - [" << first_row_id + i << ", " << j << "]: " << matrix_rows[i][j] << endl;
        }
    }
    for (int i = 0; i < matrix_size; i++)
    {
        cout << "[" << rank << "] - - - vec[" << i << "]: " << my_vector[i] << endl;
    }

    result = new double[rows_count];

    for (int i = 0; i < rows_count; i++)
    {
        result[i] = 0;
        for (int j = 0; j < matrix_size; j++)
        {
            result[i] += matrix_rows[i][j] * my_vector[j];
        }
    }

    for (int i = 0; i < world_size; i++)
    {
        if (i == rank)
            continue;

        MPI_Send(result, rows_count, MPI_DOUBLE, i, 2, MPI_COMM_WORLD);
    }
    double* final_result = new double[matrix_size];
    for (int i = 0; i < world_size; i++)
    {
        if (i == rank)
            continue;

        double* result_buffer = new double[rows_count];

        MPI_Recv(result_buffer, rows_count, MPI_DOUBLE, MPI_ANY_SOURCE, 2, MPI_COMM_WORLD, &status);


        for (int j = 0; j < rows_count; j++)
        {
            final_result[status.MPI_SOURCE * rows_count + j] = result_buffer[j];
        }
    }
    for (int j = 0; j < rows_count; j++)
    {
        final_result[rank * rows_count + j] = result[j];
    }
    

    MPI_Finalize();


    auto end = chrono::steady_clock::now();

    ofstream out(to_string(rank) + "_process.txt");
    out << "My rank is: " << rank << endl;
    out << "Running time is: " << chrono::duration_cast<chrono::milliseconds>(end - start).count() << " milliseconds" << endl << endl;
    for (int i = 0; i < matrix_size; i++)
    {
        out << "vec[" << i << "]: " << final_result[i] << endl;
    }

    return 0;
}