#include <iostream>
#include <stdio.h>
#include <string>
#include "mpi.h"
#include <fstream>

using namespace std;

int main(int argc, char* argv[])
{
    MPI_Init(&argc, &argv);

    int size;
    int rank;
    int recv_rank;
   
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);

    ofstream out(to_string(rank) + ".my_out");
    out << "I am process #" << rank << endl;

    int mass[10];
    int result;
    MPI_Status status;
    if (rank == 0)
    {
        cout << "Type in 10 nums: " << endl;
        for (int i = 0; i < 10; i++)
        {
            cin >> mass[i];
        }

        MPI_Send(&mass, 10, MPI_INT, 1, 0, MPI_COMM_WORLD);

        out << "Just send vector of data (0(me) -> 1 process, 0 tag): ";
        for (int i = 0; i < 10; i++)
        {
            out << mass[i];
        }
        out << endl;
        
        MPI_Recv(&result, 1, MPI_INT, 1, 1, MPI_COMM_WORLD, &status);
        out << "Just received one number (1 -> 0(me) process, 1 tag): " << result << endl;

        out << "Result is: " << result << endl;
        cout << "Result is: " << result << endl;
    }
    if(rank == 1)
    {
        result = 0;
        MPI_Recv(&mass, 10, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);
        out << "Just received vector of data (0 -> 1(me) process, 0 tag): ";
        for (int i = 0; i < 10; i++)
        {
            out << mass[i];
            result += mass[i];
        }
        out << endl;

        MPI_Send(&result, 1, MPI_INT, 0, 1, MPI_COMM_WORLD);
        out << "Just send one number (1(me) -> 0 process, 1 tag): " << result << endl;
    }
    out.close();

    MPI_Finalize();
    return 0;
}