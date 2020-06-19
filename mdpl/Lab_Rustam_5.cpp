#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <bitset>
#include <fstream>
#include <iomanip>
#define MEM_T 5
#define OPCODE 2
using namespace std;

bool reg[2], mem[2], bx[2], bx_si[2], bx_di[2], si[2], di[2], w, d;
int regs[2];

void clear()
{
	for (size_t i = 0; i <2; i++)
	{
		reg[i] = false; mem[i] = false; bx[i] = false; bx_si[i] = false;
		bx_di[i] = false; si[i] = false; di[i] = false;
	}
	w = false;
	d = false;
}

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

char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };

struct opcode_t
{
	string name;
	string code;
};

opcode_t op[OPCODE] =
{
	{"sub", "001010"},
	{"cmp", "001110"}
};

struct mem_t
{
	bool bx;
	bool bx_si;
	bool bx_di;
	bool si;
	bool di;
	string r_m;
};

mem_t memt[MEM_T] =
{
	{true, false, false, false, false, "111"},
	{true, true, false, false, false, "000"},
	{true, false, true, false, false, "001"},
	{false, false, false, true, false, "100"},
	{false, false, false, false, true, "101"}
};

void operand(int n, string& operand)
{
	n--;
	if (operand.find('[') != -1)
	{
		mem[n] = 1;
		if (operand.find("bx") != -1)
		{
			bx[n] = 1;
			if (operand.find("bx + si") != -1)
				bx_si[n] = 1;
			else if (operand.find("bx + di") != -1) 
				bx_di[n] = 1;
		}
		else if (operand.find("si") != -1)
			si[n] = 1;
		else if (operand.find("di") != -1)
			di[n] = 1;

		
	}
	else
	{
		reg[n] = 1;
		for (size_t i = 0; i < 16; i++)
			if (operand == regt[i])
				regs[n] = i;
		w = (regs[n] >> 3); //Перенести на синтез
	}

	//Перенести на синтез
	if (n >= 1)
	{
		if (reg[0] && reg[1] || reg[0] && mem[1])
			d = true;
		else
			d = false;
	}
}

void get_command()
{
	op->d = d;
	op->w = w;
	if (reg[0] && reg[1])
		reg_reg(op);
	else if (reg[0] && mem[1] || reg[1] && mem[0])
		reg_mem(op);
	if (disp)
		set_disp(op);
}

int main()
{
	ifstream rf("c.txt");
	string cmd;
	string bin_str;
	long int longint;
	cout << setbase(16);

	while (getline(rf, cmd))
	{
		string name;
		for (size_t i = 0; i < cmd.size(); i++)
		{
			if (cmd[i] == ' ')
			{
				name = cmd.substr(0, i);
				break;
			}
		}
		
		string mod;
		string reg;
		string r_m;

		//operand(1, opname[0]);		//Анализ операндов
		//if (opname.size() == 2)
		//{
		//	operand(2, opname[1]);
		//	syn(&op);				//Синтез машинной команды
		//}


		
		/*longint = 0;					//Перевод строки в шестнадцатеричное представление
		int len = bin_str.size();
		for (int i = 0; i < len; i++)
			longint += (bin_str[len - i - 1] - 48) * pow(2, i);

		cout << longint;*/
	}

	rf.close();
	return 0;
}