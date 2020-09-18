#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	double polyn[6] = {0.375, -1.213, 1.108, 0.742, -3.115, 2.724};
	double root[7] = {0.5, 0.75, 1, 1.25, 1.5, 1.75, 2};

	double result = 0;
	double directRes = 0;

	for (int i = 0; i < 7; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			if (j == 0)
				result = polyn[j] * root[i] + polyn[j + 1];
			else
				result = result * root[i] + polyn[j + 1];
		}

		for (int j = 0; j < 6; j++)
			directRes += polyn[j] * pow(root[i], 5 - j);

		directRes = round(directRes * 1000) / 1000;
		result = round(result * 1000) / 1000;

		if (directRes == result)
			cout << "x = " << root[i] << ": " << result << " +" <<endl << endl;
		result = 0;
		directRes = 0;
	}

	return 0;
}