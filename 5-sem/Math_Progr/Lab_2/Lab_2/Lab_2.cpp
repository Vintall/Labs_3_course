#include <iostream>
#include <vector>

using namespace std;
int main(int argc, char *argv[])
{
    if (argc < 4)
    {
        cout << "No u" << endl;
        return -9;
    }
    vector<int> a_set = vector<int>();
    a_set.push_back(atoi(argv[1]));
    a_set.push_back(atoi(argv[2]));
    a_set.push_back(atoi(argv[3]));

    vector<int> b_set = vector<int>();
    for (int i = 4; i < argc; i++)
        b_set.push_back(atoi(argv[i]));

    int count = 0;
    if ((a_set[0] >= a_set[1] && a_set[1] >= a_set[2]) ||
        (a_set[0] <= a_set[1] && a_set[1] <= a_set[2]))
    {
        for (int i = 0; i < b_set.size(); i++)
        {
            if (b_set[i] == a_set[0] || b_set[i] == a_set[1] || b_set[i] == a_set[2])
                count++;
        }
    }
    if (!((a_set[0] >= a_set[1] && a_set[1] >= a_set[2]) ||
        (a_set[0] <= a_set[1] && a_set[1] <= a_set[2])))
    {
        for (int i = 0; i < b_set.size(); i++)
        {
            if (b_set[i] != a_set[0] || b_set[i] != a_set[1] || b_set[i] != a_set[2])
                count++;
        }
    }
    cout << "Answer: " << count << endl;

    return 0;
}