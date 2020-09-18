#include <iostream>
using namespace std;

bool* implication(bool a[], bool b[])
{
	bool* res = new bool[8];

	for (int i = 0; i < 8; i++)
		res[i] = !a[i] || b[i];
	return res;
}

int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Исходное выражение: " << "((x -> y) -> (x -> z)) -> (x -> (y -> z))" << endl << endl;

	char arg[7];
	bool values[7][8];
	bool* result = new bool[8];
	int countZero = 0, countOne = 0;
	bool x[8] = { 0, 0, 0, 0, 1, 1, 1, 1 };
	bool y[8] = { 0, 0, 1, 1, 0, 0, 1, 1 };
	bool z[8] = { 0, 1, 0, 1, 0, 1, 0, 1 };

	cout << "Изменение положения переменных:" << endl;
	for (int i = 0; i < 7; i++)
		cin >> arg[i];

	cout << endl << "((" << arg[0] << " -> " << arg[1] << ") -> (" << arg[2] << " -> " << arg[3] << ")) -> (" << arg[4] << " -> (" << arg[5] << " -> " << arg[6] << "))" << endl << endl;

	for (int i = 0; i < 7; i++)
	{
		if (arg[i] == 'x')
		{
			values[i][0] = 0;
			values[i][1] = 0;
			values[i][2] = 0;
			values[i][3] = 0;
			values[i][4] = 1;
			values[i][5] = 1;
			values[i][6] = 1;
			values[i][7] = 1;
		}
		else if(arg[i] == 'y')
		{
			values[i][0] = 0;
			values[i][1] = 0;
			values[i][2] = 1;
			values[i][3] = 1;
			values[i][4] = 0;
			values[i][5] = 0;
			values[i][6] = 1;
			values[i][7] = 1;
		}
		else if (arg[i] == 'z')
		{
			values[i][0] = 0;
			values[i][1] = 1;
			values[i][2] = 0;
			values[i][3] = 1;
			values[i][4] = 0;
			values[i][5] = 1;
			values[i][6] = 0;
			values[i][7] = 1;
		}
	}
	

	cout << 'x' << ' ' << 'y' << ' ' << 'z' << "   " << 'F' << endl;
	result = implication(implication(implication(values[0], values[1]), implication(values[2], values[3])), implication(values[4], implication(values[5], values[6])));

	for (int i = 0; i < 8; i++)
	{
		cout << x[i] << ' ' << y[i] << ' ' << z[i] << "   " << result[i] << endl;
		
		if (result[i] == 0)
			countZero++;
		else
			countOne++;
	}

	cout << endl;
	if (countZero == 8)
		cout << "Формула является противоречием" << endl;
	else if (countOne == 8)
		cout << "Формула является тавтологией" << endl;
	else
		cout << "Формула является выполнимой" << endl;

	return 0;
}