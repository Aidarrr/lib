#include <iostream>
#include <string>
#include <fstream>
#include <bitset>
#include <algorithm>
#include <iomanip>
#define MEMT_SIZE 5 
#define OPCODE_T 6
#define regt_size 8
#define seg_regt_size 4
using namespace std;

bool reg, mem, bx, bx_si, bx_di, bx_dispL, bx_dispH, seg_reg, err;
int reg_num, disp;

void clear()
{
	reg = false; mem = false; bx = false; bx_si = false; bx_di = false; 
	bx_dispL = false; bx_dispH = false; seg_reg = false; err = false;
}

//Перевод целочисленного номера регистра в двоичное представление
string i2b(char x, int n)
{
	string t;
	t.resize(n, '0');
	char m = 1;
	for (int i = n - 1; i >= 0; i--)
	{
		if (x & m) t[i] = '1';
		else t[i] = '0';
		m = m << 1;
	}
	return t;
}

//Таблицы регистров
char regt[regt_size][3] = { "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };
char seg_regt[seg_regt_size][3] = { "es","cs", "ss", "ds" };

struct Opcode_t
{
	string name;
	string code;
	string code2;
	bool reg_op;
	bool seg_reg_op;
	bool mem_op;
};

//Коды операций
Opcode_t op_t[OPCODE_T] =
{
	{"push", "11111111", "110", false, false, true},
	{"push", "01010", "", true, false, false},
	{"push", "000", "110", false, true, false},
	{"pop", "10001111", "000", false, false, true},
	{"pop", "01011", "", true, false, false},
	{"pop", "000", "111", false, true, false}
};

struct Mem_t
{
	bool bx;
	bool bx_si;
	bool bx_di;
	bool bx_disp_l;
	bool bx_disp_h;
	string mod;
	string r_m;
};

//Таблица для способа задания операнда в памяти
Mem_t memt[MEMT_SIZE] =
{
	{true, false, false, false, false, "00", "111"},
	{true, true, false, false, false, "00" ,"000"},
	{true, false, true, false, false, "00" ,"001"},
	{true, false, false, true, false, "01", "111"},
	{true, false, false, true, true, "10","111"}
};

void get_disp(string& opname)				//Получение DISP из строки
{											//в целое число
	int start, end;
	string disp_s;
	for (int i = 0; i < opname.size(); i++)
	{
		if (opname[i] == '+')
		{
			i+=2;
			start = i;
			while (opname[i] != ' ' && opname[i] != ']')
				i++;
			end = i;
		}
	}
	
	disp_s = opname.substr(start, end - start);

	if (disp_s[disp_s.size() - 1] == 'h')
		disp = stoi(disp_s, nullptr, 16);
	else if (disp_s[disp_s.size() - 1] == 'o')
		disp = stoi(disp_s, nullptr, 8);
	else
		disp = stoi(disp_s, nullptr);
}

void set_disp(string &bin)			//Установить DISP в машинную команду
{
	string disp_s;
	if (bx_dispL && bx_dispH)
	{
		disp_s = bitset<16>(disp).to_string();
		bin += disp_s.substr(0, 8);
		bin += disp_s.substr(8, 8);
	}
	else if (bx_dispL)
	{
		bin += bitset<8>(disp).to_string();
	}
}

void operand(string& operand)				//Анализ операнда
{
	if (operand.find('[') != -1)			//Операнд в памяти
	{
		mem = true;
		if (operand.find("bx") != -1)
		{
			bx = true;
			if (operand.find("bx + si") != -1)
				bx_si = true;
			else if (operand.find("bx + di") != -1)
				bx_di = true;
			else if (operand.find("bx + ") != -1)
			{
				get_disp(operand);
				if (disp >= 127)
				{
					bx_dispL = bx_dispH = true;
				}
				else
				{
					bx_dispL = true;
				}
			}
		}
	}
	else									//Операнд в регистре
	{
		for (size_t i = 0; i < regt_size; i++)
			if (operand == regt[i])
			{
				reg = true;
				reg_num = i;
				break;
			}
		if (!reg)
		{
			for (size_t i = 0; i < seg_regt_size; i++)
			{
				if (operand == seg_regt[i])
				{
					seg_reg = true;
					reg_num = i;
					break;
				}
			}
		}
	}
}

void bin_syn(string &bin, string &name)		//Синтез машинной команды
{
	int j;
	for (j = 0; j < OPCODE_T; j++)			//Установка к.оп.
	{
		if (name == op_t[j].name)
		{
			if (op_t[j].mem_op == mem && op_t[j].reg_op == reg && op_t[j].seg_reg_op == seg_reg)
			{
				bin = op_t[j].code;
				if (op_t[j].name == "pop" && reg_num == 1 && op_t[j].seg_reg_op)
					err = true;
				break;
			}
		}

	}

	if (reg)							//Установка остальных полей
	{
		bin += i2b(reg_num, 3);
	}
	else if (mem)
	{
		for (size_t i = 0; i < MEMT_SIZE; i++)
		{
			if (memt[i].bx == bx && memt[i].bx_di == bx_di && memt[i].bx_si == bx_si
				&& memt[i].bx_disp_l == bx_dispL && memt[i].bx_disp_h == bx_dispH)
			{
				bin += memt[i].mod + op_t[j].code2 + memt[i].r_m;
				if (bx_dispL)
					set_disp(bin);
				break;
			}
		}
	}
	else
	{
		bin += i2b(reg_num, 2);
		bin += op_t[j].code2;
	}
}

char* bin_to_hex(const char* b, char* h) {
	int m, n, i, j;
	const char* p = b;
	char ch, * q, * t = h;

	p = b;
	while (*p)
		++p;

	if (p == b)
		*h++ = '0';

	n = (int)(p - b);
	for (i = n - 1; i > -1; i -= 4) {
		n = i - 3;
		if (n <= -1)
			n = 0;

		for (m = 0, j = n; j <= i; ++j)
			m |= (int)(b[j] - '0') << (i - j);

		*h++ = (m < 10) ? (char)(m + '0') : (char)(m - 10 + 'A');
	}
	*h = '\0';

	if (h > t) {
		for (--h, q = t; h > q; --h, ++q) {
			ch = *q;
			*q = *h;
			*h = ch;
		}
	}
	return t;
}

int main()
{
	ifstream file("lines.txt");
	string asmCmd;							

	while (getline(file, asmCmd))
	{
		string name;						
		string opname;
		string binary;

		int start_operand;
		for (int j = 0; j < asmCmd.size(); j++)
		{
			if (asmCmd[j] == ' ')
			{
				name = asmCmd.substr(0, j);
				j++;
				start_operand = j;
				break;
			}
		}
		
		clear();

		opname = asmCmd.substr(start_operand, asmCmd.size() - start_operand);
		operand(opname);
		cout << asmCmd << endl;
		
		bin_syn(binary, name);
		if (err)
		{
			cout << "Ошибка в имени регистра\n";
			continue;
		}
		char s[32];
		cout << bin_to_hex(binary.c_str(), s) << endl << endl;
	}

	file.close();
	return 0;
}