#include <iostream>
#include <math.h>
using namespace std;


int main()
{
	int n, a;
	cin >> n;
	int *coef = new int[n + 1];
	int *mult = new int[n + 2];
	for (int i = 0; i < n+2; i++)
	{
		mult[i] = 0;
	}
	int multInd = 0;

	for (int i = 0; i < n + 1; i++)
		cin >> coef[i];
	cin >> a;

	for (int i = 0; i < n + 1; i++)
	{
		if (coef[i] != 0)
		{
			mult[i] = mult[i] + coef[i];
			mult[i + 1] += coef[i] * (-1 * a);
		}
	}

	for (int i = 0; i < n+2; i++)
	{
		cout << mult[i];
		if(i != n + 1)
			cout << ' ';
	}

	delete[] coef;
	delete[] mult;
}