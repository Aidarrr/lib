#include <iostream>
#include <bitset>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>
using namespace std;

struct el_regt
{
	char name[3];
	char code;
};

char t[4] = "000";
void i2b(char x)
{
	char m = 1;
	for (size_t i = 0; i < 3; i++)
	{
		if (x & m) t[2 - i] = '1';
		else t[2 - i] = '0';
		m = m << 1;
	}
}

int main()
{
	char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di"};

	cout << "name	code	width\n";

	for (size_t i = 0; i < 16; i++)
	{
		i2b(i);
		cout << regt[i] << '\t' << t << '\t' << (i >> 3) << endl;
	}

	/*string com;
	getline(cin, com);
	vector<string> tokens;
	stringstream stream;

	stream.str(com);
	while (getline(stream, com, ' '))
		tokens.push_back(com);
	
	for (size_t i = 1; i < tokens.size(); i++)
	{
		for (size_t j = 0; j < 16; j++)
		{
			if (regt[j] == tokens[i])
			{
				i2b(j);
				cout << regt[j] << '\t' << t << '\t' << (j >> 3) << endl;
			}
		}
	}*/
	while (true)
	{
		string command;
		getline(cin, command);
		vector <pair<int, int>> positions;
		for (size_t j = 0; j < 16; j++)
		{
			int t = command.find(regt[j]);
			if (t != -1)
			{
				positions.push_back({ t, j });
			}
		}
		sort(positions.begin(), positions.end());
		for (size_t i = 0; i < positions.size(); i++)
		{
			i2b(positions[i].second);
			cout << regt[positions[i].second] << '\t' << t << '\t' << (positions[i].second >> 3) << endl;
		}
	}
	return 0;
}