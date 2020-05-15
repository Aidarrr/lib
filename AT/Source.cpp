#include <iostream>
#include <vector>
#include <string>

using namespace std;

enum x_symbols
{
	x0, x1, x2, x3, x4, x5, x6, x7
};

int main()
{
	setlocale(LC_ALL, "Russian");
	string in;
	vector<x_symbols> in_symbols;
	int state = 1;
	vector <vector <int>> table = 
	{ 
		{12, 3, 12, 12, 12, 12, 12, 2, 0}, {12, 12, 12, 12, 4, 5, 12, 12, 0}, {12, 12, 7, 12, 7, 11, 8, 10, 0},
		{12, 12, 12, 12, 6, 12, 12, 12, 0}, {12, 12, 12, 6, 12, 12, 12, 12, 0}, {12, 12, 12, 12, 12, 11, 12, 10, 0}, 
		{12, 12, 12, 12, 12, 12, 8, 12, 0}, {9, 12, 12, 12, 12, 12, 12, 12, 0}, {12, 12, 12, 12, 12, 11, 12, 12, 0},
		{12, 11, 12, 12, 12, 1, 12, 12, 0}, {12, 12, 12, 12, 12, 12, 12, 12, 1}, {12, 12, 12, 12, 12, 12, 12, 12, 0} 
	};

	while ((cin >> in) && in != ".")
	{
		in = in.substr(1,1);
		in_symbols.push_back(static_cast<x_symbols>(stoi(in)));
	}

	for (size_t i = 0; i < in_symbols.size(); i++)
	{
		cout << state << " --> ";
		state = table[state - 1][in_symbols[i]];
		cout << "x" << in_symbols[i] << " " << state << endl;
		if (state == 12)
		{
			cout << "Состояние Er => ";
			cout << "недопустимая цепочка" << endl;
			return 0;
		}
	}

	if (table[state - 1][8] == 0)
	{
		cout << "Состояние " << state << " является недопускающим => ";
		cout << "недопустимая цепочка" << endl;
	}
	else
	{
		cout << "Состояние " << state << " является допускающим => ";
		cout << "Допустимая цепочка" << endl;
	}

	return 0;
}