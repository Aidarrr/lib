#include <iostream>
#include <math.h>
#include <iomanip>
using namespace std;
double ln10 = log(10);

double func(double x, bool num)
{
	if(num == 0)
		return x + log10(x) - 0.5;

	return x * x * x + 3 * x + 1;
}

double deriv(double x, bool num)
{
	if (num == 0)
		return 1 + 1 / (x * ln10);

	return 3 * x * x + 3;
}

double half(double a, double b, double eps, bool num)
{
	int i = 0;
	double left = a, right = b;
	double x = (left + right) / 2;

	while (abs(x - left) > eps || abs(x - right) > eps)
	{
		
		if (func(x, num) * func(right, num) < 0)
			left = x;
		else
			right = x;
		x = (left + right) / 2;
		i++;
	}
	cout << "Кол-во итераций = " << i << endl;
	return x;
}

double slope(double x, double eps, bool num)
{
	int i = 0;
	double x_last = x;
	x = x_last - func(x_last, num)/deriv(x_last, num);

	while (abs(x - x_last) > eps)
	{
		x_last = x;
		x = x_last - func(x_last, num) / deriv(x_last, num);
		i++;
	}
	cout << "Кол-во итераций = " << i << endl;
	return x;
}

double hord(double x, double a, double eps, bool num)
{
	int i = 0;
	double x_last = a, x0 = x;
	x = x_last - func(x_last, num) / (func(x0, num) - func(x_last, num)) * (x0 - x_last);

	while (abs(x - x_last) > eps)
	{
		x_last = x;
		x = x_last - func(x_last, num) / (func(x0, num) - func(x_last, num)) * (x0 - x_last);
		i++;
	}
	cout << "Кол-во итераций = " << i << endl;
	return x;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	double a1 = 0.5, b1 = 1, a2 = -1, b2 = 0;

	cout << half(a1, b1, 0.000001, 0) << endl;
	cout << half(a2, b2, 0.000001, 1) << endl;
	cout << slope(1, 0.000001, 0) << endl;
	cout << slope(-1, 0.000001, 1) << endl;
	cout << hord(1, a1, 0.000001, 0) << endl;
	cout << hord(-1, b2, 0.000001, 1) << endl;


	return 0;
}