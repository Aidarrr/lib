#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };

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
	string mod;
	string reg;
	string rm;
	string disp_l;
	string disp_h;
};


string i2b(char x)
{
	string t = "000";
	char m = 1;
	for (size_t i = 0; i < 3; i++)
	{
		if (x & m) t[2 - i] = '1';
		else t[2 - i] = '0';
		m = m << 1;
	}
	return t;
}

void reg_reg(Operation *op, vector<string> opname)
{
	op->d = 1;
	char reg, rm;
	for (size_t i = 0; i < 16; i++)
	{
		if (regt[i] == opname[0])
			reg = i;
		else if (regt[i] == opname[1])
			rm = i;
	}

	op->w = reg >> 3;
	op->mod = "11";
	op->reg = i2b(reg);
	op->rm = i2b(rm);
}

void reg_mem()
{

}

void reg_memDisp()
{

}

int main()
{
	
	Mem_t memt[6] = { {"[bp]", 0, 6}, {"[bx]", 0, 7}, {"[bp + disp_l]", 1, 6}, {"[bx + disp_l]", 1, 7}, {"[bp + disp_h:disp_l]", 2, 6}, {"[bx + disp_h:disp_l]", 2, 7} };

	string name = "add";
	string command;
	getline(cin, command);
	Operation op;

	bool operand[2]; // 1 - reg, 0 - mem
	vector<string> opname;

	for (int i = 0; i < command.size(); i++)
	{
		if (command[i] == ' ')
			break;
		name[i] = command[i];
	}
	
	for (int i = 0, j = 0; i < command.size(); i++)
	{
		if (command[i] == ' ')
		{
			i++;
			if (command[i] == '[')
			{
				operand[j++] = false;
 				int endName = i;
				while (command[endName] != ',')
					endName++;

				opname.push_back(command.substr(i, endName - i));
				i = endName;
			}
			else
			{
				operand[j++] = true;
				opname.push_back(command.substr(i, 2));
			}
		}
		if (command[i] == ',')
		{
			i++;
			if (command[i] == ' ')
				i++;
			if (command[i] == '[')
			{
				operand[j++] = false;
				opname.push_back(command.substr(i, command.size() - i));
			}
			else
			{
				operand[j++] = true;
				opname.push_back(command.substr(i, 2));
			}
			break;
		}
	}

	if (name == "add")
		op.opcode = "000000";
	else if (name == "and")
		op.opcode = "001000";
	else
		op.opcode = "001100";

	if (operand[0] && operand[1])
	{
		reg_reg(&op, opname);
	}
	else if (!operand[0] && operand[1])
	{
		if (opname[0].size() > 4)
			reg_memDisp();
		else
			reg_mem();
	}
	else if (operand[0] && !operand[1])
	{
		if (opname[1].size() > 4)
			reg_memDisp();
		else
			reg_mem();
	}


	//vector <pair<int, int>> positions;
	/*for (size_t j = 0; j < 12; j++)
	{
		int t = command.find(regt[j]);
		if (t != -1)
		{
			count++;
			positions.push_back({ t, j });
		}
	}*/

	//sort(positions.begin(), positions.end());

	//if (count == 2)
	//	reg_reg(&op, positions);

	return 0;
}