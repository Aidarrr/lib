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
	double x_last;

	do
	{
		x_last = x;
		x = x_last - func(x_last, num) / deriv(x_last, num);
		i++;
	} while (abs(x - x_last) > eps);
	
	cout << "Кол-во итераций = " << i << endl;
	return x;
}

double hord(double x, double opposite, double eps, bool num)
{
	int i = 0;
	double x_last = opposite, x0 = x;
	x = x_last - func(x_last, num) / (func(x0, num) - func(x_last, num)) * (x0 - x_last); i++;

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
	double x00, x01, opposite0, opposite1;

	if (func(a1, 0) * deriv(a1, 0) > 0)
	{
		x00 = a1;
		opposite0 = b1;
	}
	else
	{
		x00 = b1;
		opposite0 = a1;
	}
	if (func(a2, 1) * deriv(a2, 1) > 0)
	{
		x01 = a2;
		opposite1 = b2;
	}
	else
	{
		x01 = b2;
		opposite1 = a2;
	}

	cout << "eps = 0.001\n";
	cout << "Уравнение 1 \n" << half(a1, b1, 0.001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << half(a2, b2, 0.001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << slope(x00, 0.001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << slope(x01, 0.001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << hord(x00, opposite0, 0.001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << hord(x01, opposite1, 0.001, 1) << endl << endl << endl;

	cout << "eps = 0.000001\n";
	cout << fixed << setprecision(8) << "Уравнение 1 \n" << half(a1, b1, 0.000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << half(a2, b2, 0.000001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << slope(x00, 0.000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << slope(x01, 0.000001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << hord(x00, opposite0, 0.000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << hord(x01, opposite1, 0.000001, 1) << endl << endl << endl;

	cout << "eps = 0.000000001\n";
	cout << fixed << setprecision(11) << "Уравнение 1\n" << half(a1, b1, 0.000000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << half(a2, b2, 0.000000001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << slope(x00, 0.000000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << slope(x01, 0.000000001, 1) << endl << endl;
	cout << "Уравнение 1 \n" << hord(x00, opposite0, 0.000000001, 0) << endl << endl;
	cout << "Уравнение 2 \n" << hord(x01, opposite1, 0.000000001, 1) << endl << endl;


	return 0;
}