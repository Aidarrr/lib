//#include <iostream>
//#include <string>
//#include <vector>
//#include <algorithm>
//#include <bitset>
//#include <fstream>
//#define memt_size 5
//#define opcode_size 3
//using namespace std;
//
//char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };
//
//bool reg[2], mem[2], bx[2], bp[2], disp, disp_l, disp_h, w, d;
//int regs[2];
//int disp_int;
//
//void clear()
//{
//	for (size_t i = 0; i <2; i++)
//	{
//		reg[i] = false; mem[i] = false; bx[i] = false; bp[i] = false;
//	}
//	disp = false;
//	disp_l = false;
//	disp_h = false;
//	w = false;
//	d = false;
//}
//
//struct Opcode_t
//{
//	string name;
//	string code;
//};
//
//struct Mem_t
//{
//	bool bx;
//	bool bp;
//	bool disp_l;
//	bool disp_h;
//	string mod;
//	string rm;
//};
//
//Mem_t memt[memt_size] = { {false, true, true, false, "01", "110"}, {true, false, false, false, "00", "111"},
//				{true, false, true, false, "01", "111"}, {false, true, true, true, "10", "110"}, {true, false, true, true, "10", "111"} };
//
//Opcode_t opcode[opcode_size] = { {"and", "001000"}, {"add", "000000"}, {"xor", "001100"} };
//
//struct Operation
//{
//	string opcode;
//	bool d;
//	bool w;
//	string mod;
//	string reg;
//	string rm;
//	string disp_l;
//	string disp_h;
//};
//
//
//string i2b(char x, int n)
//{
//	string t;
//	t.resize(n, '0');
//	char m = 1;
//	for (int i = n - 1; i >= 0; i--)
//	{
//		if (x & m) t[i] = '1';
//		else t[i] = '0';
//		m = m << 1;
//	}
//	return t;
//}
//
//void reg_reg(Operation *op)
//{
//	op->reg = i2b(regs[0], 3);
//	op->rm = i2b(regs[1], 3);
//	op->mod = "11";
//}
//
//void reg_mem(Operation* op)
//{
//	int m, r;
//	if (d)
//	{
//		m = 1;
//		r = 0;
//	}
//	else
//	{
//		m = 0;
//		r = 1;
//	}
//
//	for (int i = 0; i < memt_size; i++)
//	{
//		if (memt[i].bp == bp[m] && memt[i].bx == bx[m] && memt[i].disp_l == disp_l && memt[i].disp_h == disp_h)
//		{
//			op->mod = memt[i].mod;
//			op->rm = memt[i].rm;
//		}
//	}
//
//	op->reg = i2b(regs[r], 3);
//}
//
//
//void get_disp(string* opname)
//{
//	int start, end;
//	string disp_s;
//	for (int i = 0; i < (*opname).size(); i++)
//	{
//		if ((*opname)[i] == '+')
//		{
//			i++;
//			while ((*opname)[i] == ' ')
//				i++;
//			start = i;
//			while ((*opname)[i] != ' ' && (*opname)[i] != ']')
//				i++;
//			end = i;
//			break;
//		}
//	}
//	
//	disp_s = (*opname).substr(start, end - start);
//
//	if (disp_s[disp_s.size() - 1] == 'h')
//	{
//		disp_int = stoi(disp_s, nullptr, 16);
//	}
//	else if (disp_s[disp_s.size() - 1] == 'o')
//	{
//		disp_int = stoi(disp_s, nullptr, 8);
//	}
//	else
//		disp_int = stoi(disp_s, nullptr);
//}
//
//void set_disp(Operation *op)
//{
//	string disp_s;
//	if (disp_h && disp_l)
//	{
//		disp_s = bitset<16>(disp_int).to_string();
//		op->disp_l = disp_s.substr(8, 8);
//		op->disp_h = disp_s.substr(0, 8);
//	}
//	else if (disp_l)
//	{
//		op->disp_l = bitset<8>(disp_int).to_string();
//	}
//}
//
//void operand(int n, string* opname)
//{
//	n--;
//	if ((*opname).find('[') != -1)
//	{
//		mem[n] = 1;
//		if ((*opname).find("bp") != -1)
//			bp[n] = 1;
//		else if ((*opname).find("bx") != -1)
//			bx[n] = 1;
//
//		if ((*opname).find("+") != -1)
//		{
//			disp = 1;
//			get_disp(opname);
//			if (disp_int < 127)
//				disp_l = 1;
//			else
//			{
//				disp_l = 1; disp_h = 1;
//			}
//		}
//		else if (bp[n] == 1)
//		{
//			disp = 1; disp_l = 1;
//			disp_int = 0;
//		}
//	}
//	else
//	{
//		reg[n] = 1;
//		for (size_t i = 0; i < 16; i++)
//			if (*opname == regt[i])
//				regs[n] = i;
//		w = (regs[n] >> 3);
//	}
//
//	if (n >= 1)
//	{
//		if (reg[0] && reg[1] || reg[0] && mem[1])
//			d = true;
//		else
//			d = false;
//	}
//}
//
//void syn(Operation *op)
//{
//	op->d = d;
//	op->w = w;
//	if (reg[0] && reg[1])
//		reg_reg(op);
//	else if (reg[0] && mem[1] || reg[1] && mem[0])
//		reg_mem(op);
//	if (disp)
//		set_disp(op);
//}
//
//char* bin_to_hex(const char* b, char* h) {
//	int m, n, i, j;
//	const char* p = b;
//	char ch, * q, * t = h;
//
//	/*while (*b && (*b == '0'))
//		++b;*/
//
//	p = b;
//	while (*p)
//		++p;
//
//	if (p == b)
//		*h++ = '0';
//
//	n = (int)(p - b);
//	for (i = n - 1; i > -1; i -= 4) {
//		n = i - 3;
//		if (n <= -1)
//			n = 0;
//
//		for (m = 0, j = n; j <= i; ++j)
//			m |= (int)(b[j] - '0') << (i - j);
//
//		*h++ = (m < 10) ? (char)(m + '0') : (char)(m - 10 + 'A');
//	}
//	*h = '\0';
//
//	if (h > t) {
//		for (--h, q = t; h > q; --h, ++q) {
//			ch = *q;
//			*q = *h;
//			*h = ch;
//		}
//	}
//	return t;
//}
//
//int main()
//{
//	ifstream read("com.txt");
//	string command;
//
//	while (getline(read, command))
//	{
//		string name; int endname;
//		
//		Operation op;
//		vector<string> opname;
//		
//
//		for (int i = 0; i < command.size(); i++)
//		{
//			if (command[i] != ' ')
//			{
//				name = command.substr(i, 3);
//				endname = i + 3;
//				break;
//			}
//		}
//		
//		for (int i = endname, j = 0; i < command.size(); i++)
//		{
//			if (command[i] != ' ' && opname.size() == 0)
//			{
//				if (command[i] == '[')
//				{
//					int endName = i;
//					while (command[endName] != ',')
//						endName++;
//
//					opname.push_back(command.substr(i, endName - i));
//					i = endName - 1;
//				}
//				else
//				{
//					opname.push_back(command.substr(i, 2));
//				}
//			}
//			else if (command[i] == ',')
//			{
//				i++;
//				while (command[i] == ' ')
//					i++;
//				opname.push_back(command.substr(i, command.size() - i));
//				break;
//			}
//		}
//
//		clear();
//
//		operand(1, &opname[0]);
//		if (opname.size() == 2)
//		{
//			operand(2, &opname[1]);
//			syn(&op);
//		}
//
//		for (int i = 0; i < opcode_size; i++)
//		{
//			if (name == opcode[i].name)
//				op.opcode = opcode[i].code;
//		}
//
//		cout << command << endl;
//		command = op.opcode + to_string(op.d) + to_string(op.w) + op.mod + op.reg + op.rm;
//		if (disp_l && disp_h)
//			 command += op.disp_l + op.disp_h;
//		else if (disp_l)
//			command += op.disp_l;
//
//		char s[32];
//		cout << bin_to_hex(command.c_str(), s) << endl << endl;
//	}
//
//	read.close();
//	return 0;
//}