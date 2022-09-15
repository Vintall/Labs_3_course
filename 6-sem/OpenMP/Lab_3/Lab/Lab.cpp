#include <iostream>
#include <stdio.h>
#include <fstream>
#include <string>
#include "mpi.h"

using namespace std;

int main(int argc, char* argv[])
{
    int errCode;
    if ((errCode = MPI_Init(&argc, &argv)) != 0)
    {
        return errCode;
    }
    int myRank;
    int count;
    char* name = new char[1];
    name[0] = 'a';
    int result_len;
   
    ifstream in("//DESKTOP-F14INQA/Users/vintall/Documents/MPI_Test/mpi_test.txt");
    MPI_Comm_rank(MPI_COMM_WORLD, &myRank);
    MPI_Comm_size(MPI_COMM_WORLD, &count);
    MPI_Get_processor_name(name, &result_len);

    cout << "Processor name is: " << name << endl;
    cout << "Rank is: " << myRank << endl;
    
    if (in.is_open())
    {
        cout << "File contains: " << endl;
        string line;
        while (getline(in, line))
        {
            cout << line << endl;
        }
        in.close();
    }
    else
    {
        cout << "Can not read the file" << endl;
    }
    
    MPI_Finalize();
    return 0;
}