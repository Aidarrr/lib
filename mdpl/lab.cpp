#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

struct Mem_t
{
	string name;
	char mod;
	char rm;
};

struct Operation
{
	string opcode;
	bool d;
	bool w;
	char mod;
	char reg;
	char rm;
	char disp_l;
	char disp_h;
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

void reg_reg(Operation *op, vector <pair<int, int>> positions)
{
	op->d = 1;
	op->w = positions[0].second >> 3;

	op->mod = 3;
	op->reg = positions[0].second - 8;
	op->rm = positions[1].second - 8;
}

void reg_mem(Operation* op, vector <pair<int, int>> positions)
{

}

void reg_memDisp()
{

}

int main()
{
	char regt[12][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx"};
	Mem_t memt[6] = { {"[bp]", 0, 6}, {"[bx]", 0, 7}, {"[bp + disp_l]", 1, 6}, {"[bx + disp_l]", 1, 7}, {"[bp + disp_h:disp_l]", 2, 6}, {"[bx + disp_h:disp_l]", 2, 7} };
	string name = "add";
	int count = 0;

	string command;
	getline(cin, command);
	Operation op;

	for (int i = 0; i < command.size(); i++)
	{
		if (command[i] == ' ')
			break;
		name[i] = command[i];
	}
	
	if (name == "add")
		op.opcode = "000000";
	else if (name == "and")
		op.opcode = "001000";
	else
		op.opcode = "001100";

	vector <pair<int, int>> positions;
	for (size_t j = 0; j < 12; j++)
	{
		int t = command.find(regt[j]);
		if (t != -1)
		{
			count++;
			positions.push_back({ t, j });
		}
	}

	sort(positions.begin(), positions.end());

	if (count == 2)
		reg_reg(&op, positions);

	return 0;
}