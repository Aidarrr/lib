//#include <iostream>
//#include <math.h>
//#include <iomanip>
//using namespace std;
//
//double Ff(double x)
//{
//	double rez = tan(x * 0.5 + 0.2)-pow(x,2);
//	return(rez);
//}
//double Flf(double x)
//{
//	double rez = 0.5 / pow(cos(x * 0.5 + 0.2), 2) - 2 * x;
//	return(rez);
//}
//double Fg(double x)
//{
//	double rez = pow(x, 3) + x - 5;
//	return(rez);
//}
//double Flg(double x)
//{
//	double rez = pow(x, 2) * 3 + 1;
//	return(rez);
//}
//double Slope1(double x, double e)
//{
//	double xi;
//	int i = 1;
//
//	xi = x - Ff(x) / (Flf(x));
//	while (true)
//	{
//		if (abs(xi - x) < e || i > 20000)
//			break;
//		x = xi;
//		xi = x - Ff(x) / (Flf(x));
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return xi;
//
//}
//double Slope2(double x, double e)
//{
//	double xi;
//	int i = 1;
//
//	xi = x - Fg(x) / (Flg(x));
//	while (true)
//	{
//		if (abs(xi - x) < e || i > 20000)
//			break;
//		x = xi;
//		xi = x - Fg(x) / (Flg(x));
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return xi;
//
//}
//double Hord1(double a, double b, double e)
//{
//	double x0 = b, xi, t = 0;
//	int i = 1;
//	xi = a - Ff(a) * (x0 - a) / (Ff(x0) - Ff(a));
//	while (true)
//	{
//		if (abs(xi - t) < e || i > 20000)
//			break;
//		t = xi;
//		xi = xi - Ff(xi) * (x0 - xi) / (Ff(x0) - Ff(xi));
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return xi;
//}
//double Hord2(double a, double b, double e)
//{
//	double x0 = b, xi, t = 0;
//	int i = 1;
//	xi = a - Fg(a) * (x0 - a) / (Fg(x0) - Fg(a));
//	while (true)
//	{
//		if (abs(xi - t) < e || i > 20000)
//			break;
//		t = xi;
//		xi = xi - Fg(xi) * (x0 - xi) / (Fg(x0) - Fg(xi));
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return xi;
//}
//double Half1(double a, double b, double e)
//{
//	double x,right=b,left=a;
//	int i = 1;
//	x = (right + left) / 2;
//	while (true)
//	{
//		if (abs(x - right) < e || abs(left - x) < e || i > 20000)
//			break;
//		if (Ff(x) * Ff(right) < 0)
//			left = x;
//		else
//			right = x;
//		x = (right + left) / 2;
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return x;
//}
//double Half2(double a, double b, double e)
//{
//	double x, right = b, left = a;
//	int i = 1;
//	x = (right + left) / 2;
//	while (true)
//	{
//		if (abs(x - right) < e || abs(left - x) < e || i > 20000)
//			break;
//		if (Fg(x) * Fg(right) < 0)
//			left = x;
//		else
//			right = x;
//		x = (right + left) / 2;
//		i++;
//	}
//	cout << " Итераций:" << i << " ";
//	return x;
//}
//
//int main()
//{
//	setlocale(LC_ALL, "Russian");
//	cout << " Значение:" << fixed << setprecision(5) << Slope1(1, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Slope1(1, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Slope1(1, 0.000000001) << endl;
//	cout << endl;
//	cout << " Значение:" << fixed << setprecision(5) << Hord1(0.5, 1, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Hord1(0.5, 1, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Hord1(0.5, 1, 0.000000001) << endl;
//	cout << endl;
//	cout << " Значение:" << fixed << setprecision(5) << Half1(0.5, 1, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Half1(0.5, 1, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Half1(0.5, 1, 0.000000001) << endl;
//	cout << endl;
//	cout << " Значение:" << fixed << setprecision(5) << Slope2(1, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Slope2(1, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Slope2(1, 0.000000001) << endl;
//	cout << endl;
//	cout << " Значение:" << fixed << setprecision(5) << Hord2(1, 2, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Hord2(1, 2, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Hord2(1, 2, 0.000000001) << endl;
//	cout << endl;
//	cout << " Значение:" << fixed << setprecision(5) << Half2(1, 2, 0.001) << endl;
//	cout << " Значение:" << fixed << setprecision(8) << Half2(1, 2, 0.000001) << endl;
//	cout << " Значение:" << fixed << setprecision(11) << Half2(1, 2, 0.000000001) << endl;
//	cout << endl;
//	return 0;
//}