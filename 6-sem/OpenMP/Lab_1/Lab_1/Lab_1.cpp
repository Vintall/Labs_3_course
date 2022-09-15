#include <iostream>
#include <vector>
#include <omp.h>
#include <chrono>

using namespace std;

long long Sum(vector<double>& a, vector<double>& b)
{
    long long result = 0;

    for (int i = 0; i < a.size(); i++)
        result += a[i] * b[i];

    return result;
}
void Splitter()
{
    cout << "|                                                   |" << endl;
    cout << "|                                                   |" << endl;
}
int main()
{
    int size = 1024*1024*1024/2;  //1024 * 1024 * 1024 * 16 / 4 / 2;
    // double is a variable, that takes 4 bytes per one value
    // i have 16gb of RAM on my PC
    // 1gb = 1024mb = 1024*1024Kb = 1024*1024*1024 bytes
    // consequansly, i need to define 2 vector, each of those contains 1024*1024*1024*16/4/2 elements
    Splitter();
    auto before_defining = chrono::high_resolution_clock::now();

    vector<double> first = vector<double>(size);
    vector<double> second = vector<double>(size);
    double result;

    auto after_defining = chrono::high_resolution_clock::now();
    auto milliseconds = chrono::duration_cast<chrono::milliseconds>(after_defining - before_defining);

    cout << "|Defining takes " << milliseconds.count() << " milliseconds" << endl;
    Splitter();
    for (int i = 0; i < size; i++)
    {
        first[i] = 1;
        second[i] = 1;
    }
    auto after_filling = chrono::high_resolution_clock::now();

    milliseconds = chrono::duration_cast<chrono::milliseconds>(after_filling - after_defining);
    cout << "|Filling takes " << milliseconds.count() << " milliseconds" << endl;
    Splitter();
    result = Sum(first, second);

    auto after_summing_vectors = chrono::high_resolution_clock::now();

    milliseconds = chrono::duration_cast<chrono::milliseconds>(after_summing_vectors - after_filling);
    cout << "|Summing takes " << milliseconds.count() << " milliseconds" << endl;
    Splitter();
    cout << "|Result is " << result << endl;
    Splitter(); Splitter(); Splitter();

    auto before_omp = chrono::high_resolution_clock::now();


    result = 0;
    int i;
#pragma omp parallel shared(first, second, result) private(i) num_threads(12)
    {
        int j = 0;
#pragma omp for
            for (i = 0; i < size; i++)
            {
                j += first[i] * second[i];
            }
#pragma omp atomic
        result += j;
    }


    auto after_omp = chrono::high_resolution_clock::now();

    milliseconds = chrono::duration_cast<chrono::milliseconds>(after_omp - before_omp);

    cout << "|Summing, using OMP, takes " << milliseconds.count() << " milliseconds" << endl;
    Splitter();
    cout << "|Result is " << result << endl;
    Splitter();

    return 0;

}