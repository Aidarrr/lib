#include <iostream>
#include <cmath>
#define n 10
using namespace std;

void factorial(int* fact)
{
	int i;
	fact[0] = 1;
	for (i = 1; i <= n; i++) 
		fact[i] = (fact[i - 1] * i);
}

int main()
{
	setlocale(LC_ALL, "Russian");
	int* arr = new int[n];
	factorial(arr);
	cout.precision(8);
	double x1 = 1.06, x2 = 2.61;
	double result = 1, directResult = 1, temp;
	int i = 1;
	cout << "e^x" << endl << "x1" << endl;
	while(true)
	{
		temp = result;
		result += pow(x1, i) / arr[i];
		if ((int)(result * 1000000) - (int)(temp * 1000000) == 0)
			break;
		i++;
		cout << result << ' ';
	}

	directResult = exp(x1);
	
	cout << endl << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl;

	i = 1;
	result = 1;
	cout << endl << "x2" << endl;
	while(true)
	{
		temp = result;
		result += pow(x2, i) / arr[i];
		cout << result << ' ';
		if ((int)(result * 1000000) - (int)(temp * 1000000) == 0)
			break;
		i++;
	}
	directResult = exp(x2);
	cout << endl << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl << endl;

	cout << "ln(1+x)" << endl;
	//i = 1;
	result = 0;
	x1 = 0.266;

	for (int i = 1; i <= 20; i++)
	{
		result += pow(-1, i + 1) * (pow(x1, i) / i);
		cout << result << ' ';
	}

	directResult = log(1 + x1);
	cout << endl << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl << endl;

	cout << "sin(x)" << endl;
	cout << "x1" << endl;
	//i = 0;
	result = 0;
	x1 = 0.328;
	x2 = 0.635;

	for (int i = 0; i <= 2; i++)
	{
		result += pow(-1, i) * (pow(x1, 2*i+1) / arr[2*i+1]);
		cout << result << ' ';
	}
	directResult = sin(x1);
	cout << endl<< "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl;
	
	cout << "x2" << endl;
	//i = 0;
	result = 0;

	for (int i = 0; i <= 2; i++)
	{
		result += pow(-1, i) * (pow(x2, 2 * i + 1) / arr[2 * i + 1]);
		cout << result << ' ';
	}
	directResult = sin(x2);
	cout << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl << endl;

	cout << "cos(x)" << endl;
	cout << "x1" << endl;
	//i = 1;
	result = 1;
	for (int i = 1; i <= 3; i++)
	{
		result += pow(-1, i) * (pow(x1, 2 * i) / arr[2 * i]);
		cout << result << ' ';
	}
	directResult = cos(x1);
	cout << endl << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl;

	cout << "x2" << endl;
	//i = 1;
	result = 1;
	for (int i = 1; i <= 2; i++)
	{
		result += pow(-1, i) * (pow(x2, 2 * i) / arr[2 * i]);

		cout << result << ' ';

	}
	directResult = cos(x2);
	cout << endl << "С помощью ряда Маклорена = " << result << endl;
	cout << "Прямой способ = " << directResult << endl;

	return 0;
}