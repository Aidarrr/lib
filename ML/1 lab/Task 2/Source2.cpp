#include <iostream>
using namespace std;

bool* calc(bool a[], bool b[], int num)
{
	bool* res = new bool[16];

	if (num == 1)
		for (int i = 0; i < 16; i++)
			res[i] = a[i] && b[i];
	else if (num == 2)
		for (int i = 0; i < 16; i++)
			res[i] = a[i] || b[i];
	else if (num == 3)
		for (int i = 0; i < 16; i++)
			res[i] = !(a[i] && b[i]);
	else if (num == 4)
		for (int i = 0; i < 16; i++)
			res[i] = a[i] && !b[i];
	else if (num == 5)
		for (int i = 0; i < 16; i++)
			res[i] = !a[i] && !b[i];
	return res;
}

bool* calc2(bool a[], bool b[])
{
	bool* res = new bool[16];

	for (int i = 0; i < 16; i++)
		res[i] = a[i] && !b[i];

	return res;
}

int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Исходное выражение: " << endl << "(a || (c || (b && c))) && !(c && d) && (c && !d) && (c || (!d && !c) || d)" << endl << endl;

	char arg[12];
	bool values[12][16];
	bool* result = new bool[16];
	bool a[16] = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
	bool b[16] = { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 };
	bool c[16] = { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 };
	bool d[16] = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };

	cout << "Изменение положения переменных:" << endl;
	for (int i = 0; i < 4; i++)
		cin >> arg[i];

	cout << endl << "(" << arg[0] << " || " << "(" << arg[1] << " || (" << arg[2] << " && " << arg[1] << "))) && !(" << arg[1] << " && " << arg[3] << ") && (" << arg[1] << " && !" << arg[3] << ") && (" << arg[1] << " || (!" << arg[3] << " && !" << arg[1] << ") || " << arg[3] << ")" << endl << endl;

	for (int i = 0; i < 12; i++)
	{
		if (arg[i] == 'a')
		{
			values[i][0] = 0;
			values[i][1] = 0;
			values[i][2] = 0;
			values[i][3] = 0;
			values[i][4] = 0;
			values[i][5] = 0;
			values[i][6] = 0;
			values[i][7] = 0;
			values[i][8] = 1;
			values[i][9] = 1;
			values[i][10] = 1;
			values[i][11] = 1;
			values[i][12] = 1;
			values[i][13] = 1;
			values[i][14] = 1;
			values[i][15] = 1;
		}
		else if (arg[i] == 'b')
		{
			values[i][0] = 0;
			values[i][1] = 0;
			values[i][2] = 0;
			values[i][3] = 0;
			values[i][4] = 1;
			values[i][5] = 1;
			values[i][6] = 1;
			values[i][7] = 1;
			values[i][8] = 0;
			values[i][9] = 0;
			values[i][10] = 0;
			values[i][11] = 0;
			values[i][12] = 1;
			values[i][13] = 1;
			values[i][14] = 1;
			values[i][15] = 1;
		}
		else if (arg[i] == 'c')
		{
			values[i][0] = 0;
			values[i][1] = 0;
			values[i][2] = 1;
			values[i][3] = 1;
			values[i][4] = 0;
			values[i][5] = 0;
			values[i][6] = 1;
			values[i][7] = 1;
			values[i][8] = 0;
			values[i][9] = 0;
			values[i][10] = 1;
			values[i][11] = 1;
			values[i][12] = 0;
			values[i][13] = 0;
			values[i][14] = 1;
			values[i][15] = 1;
		}
		else if (arg[i] == 'd')
		{
			values[i][0] = 0;
			values[i][1] = 1;
			values[i][2] = 0;
			values[i][3] = 1;
			values[i][4] = 0;
			values[i][5] = 1;
			values[i][6] = 0;
			values[i][7] = 1;
			values[i][8] = 0;
			values[i][9] = 1;
			values[i][10] = 0;
			values[i][11] = 1;
			values[i][12] = 0;
			values[i][13] = 1;
			values[i][14] = 0;
			values[i][15] = 1;
		}
	}


	cout << 'a' << ' ' << 'b' << ' ' << 'c' << ' ' << 'd' << "   " << 'F' << endl;
	//result = implication(implication(implication(values[0], values[1]), implication(values[2], values[3])), implication(values[4], implication(values[5], values[6])));

	result = calc(calc(calc(calc(values[0], calc(values[1], calc(values[2], values[3], 1), 2), 2), calc(values[4], values[5], 3), 1), calc(values[6], values[7], 4), 1), calc(calc(values[8], calc(values[9], values[10], 5), 2), values[11], 2), 1);
	for (int i = 0; i < 16; i++)
	{
		cout << a[i] << ' ' << b[i] << ' ' << c[i] << ' ' << d[i] << "   " << result[i] << endl;
	}

	cout << endl;
	if (arg[4] == arg[5] || arg[6] == arg[7])
		cout << "Упрощенное выражение: 0";
	else
	{
		cout << "Упрощенное выражение: c ^ D" << endl;
		bool* result2 = new bool[16];
		bool values2[2][4];
		values[0][0] = 0;
		values[0][1] = 0;
		values[0][2] = 1;
		values[0][3] = 1;
		values[0][4] = 0;
		values[0][5] = 0;
		values[0][6] = 1;
		values[0][7] = 1;
		values[0][8] = 0;
		values[0][9] = 0;
		values[0][10] = 1;
		values[0][11] = 1;
		values[0][12] = 0;
		values[0][13] = 0;
		values[0][14] = 1;
		values[0][15] = 1;
		values[1][0] = 0;
		values[1][1] = 1;
		values[1][2] = 0;
		values[1][3] = 1;
		values[1][4] = 0;
		values[1][5] = 1;
		values[1][6] = 0;
		values[1][7] = 1;
		values[1][8] = 0;
		values[1][9] = 1;
		values[1][10] = 0;
		values[1][11] = 1;
		values[1][12] = 0;
		values[1][13] = 1;
		values[1][14] = 0;
		values[1][15] = 1;
		result2 = calc2(values[0], values[1]);

		for (int i = 0; i < 16; i++)
			cout << a[i] << ' ' << b[i] << ' ' << values[0][i] << ' ' << values[1][i] << "   " << result2[i] << endl;


	}
	cout << endl;
	return 0;
}