//#include <iostream>
//#include <string>
//#include <vector>
//#include <algorithm>
//#include <bitset>
//using namespace std;
//
//char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };
//
//struct Mem_t
//{
//	string name;
//	char mod;
//	char rm;
//};
//
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
//void reg_reg(Operation *op, vector<string> *opname)
//{
//	op->d = 1;
//
//	for (size_t i = 0; i < 16; i++)
//	{
//		if (regt[i] == (*opname)[0])
//		{
//			op->w = i >> 3;
//			op->reg = i2b(i, 3);
//		}
//		if (regt[i] == (*opname)[1])
//			op->rm = i2b(i, 3);
//	}
//	op->mod = "11";	
//}
//
//void reg_mem(Operation* op, Mem_t *mem, vector<string> *opname, bool *operand)
//{
//	int memind, regind;
//	if (!operand[0])
//	{
//		memind = 0;
//		regind = 1;
//		op->d = 0;
//	}
//	else
//	{
//		memind = 1;
//		regind = 0;
//		op->d = 1;
//	}
//
//	for (int i = 0; i < 6; i++)
//	{
//		if (mem[i].name == (*opname)[memind])
//		{
//			op->rm = i2b(mem[i].rm, 3);
//			op->mod = i2b(mem[i].mod, 2);
//			break;
//		}
//	}
//
//	for (int i = 0; i < 16; i++)
//	{
//		if (regt[i] == (*opname)[regind])
//		{
//			op->reg = i2b(i, 3);
//			op->w = i >> 3;
//			break;
//		}
//	}
//}
//
//void reg_memDisp(Operation* op, Mem_t* mem, vector<string>* opname, bool* operand)
//{
//	string disp, name;
//	int memind, regind, start, end, dispint;
//	if (!operand[0])
//	{
//		memind = 0;
//		regind = 1;
//		op->d = 0;
//	}
//	else
//	{
//		memind = 1;
//		regind = 0;
//		op->d = 1;
//	}
//
//	for (int i = 0; i < (*opname)[memind].size(); i++)
//		if ((*opname)[memind][i] != ' ' && (*opname)[memind][i] != '[')
//		{
//			start = i;
//			break;
//		}
//	name = (*opname)[memind].substr(start, 2);
//	
//	for (int i = 0; i < (*opname)[memind].size(); i++)
//	{
//		if ((*opname)[memind][i] == '+')
//		{
//			i++;
//			while ((*opname)[memind][i] == ' ')
//				i++;
//			start = i;
//			while ((*opname)[memind][i] != ' ' && (*opname)[memind][i] != ']')
//				i++;
//			end = i;
//			break;
//		}
//	}
//	
//	disp = (*opname)[memind].substr(start, end - start);
//
//	if (disp[disp.size() - 1] == 'h')
//	{
//		dispint = stoi(disp, nullptr, 16);
//	}
//	else if (disp[disp.size() - 1] == 'o')
//	{
//		dispint = stoi(disp, nullptr, 8);
//	}
//	else
//		dispint = stoi(disp, nullptr);
//
//	
//	
//	if (dispint < 127)
//	{
//		name = "[" + name + " + disp_l]";
//		op->disp_l = bitset<8>(dispint).to_string();
//	}
//	else
//	{
//		name = "[" + name + " + disp_h:disp_l]";
//		disp = bitset<16>(dispint).to_string();
//		op->disp_l = disp.substr(8, 8);
//		op->disp_h = disp.substr(0, 8);
//	}
//
//	for (int i = 0; i < 6; i++)
//	{
//		if (mem[i].name == name)
//		{
//			op->rm = i2b(mem[i].rm, 3);
//			op->mod = i2b(mem[i].mod, 2);
//			break;
//		}
//	}
//
//	for (int i = 0; i < 16; i++)
//	{
//		if (regt[i] == (*opname)[regind])
//		{
//			op->reg = i2b(i, 3);
//			op->w = i >> 3;
//			break;
//		}
//	}
//}
//
//int main()
//{
//	Mem_t memt[6] = { {"[bp]", 0, 6}, {"[bx]", 0, 7}, {"[bp + disp_l]", 1, 6}, {"[bx + disp_l]", 1, 7}, {"[bp + disp_h:disp_l]", 2, 6}, {"[bx + disp_h:disp_l]", 2, 7} };
//	
//	while (true)
//	{
//		string name; int endname;
//		string command;
//		getline(cin, command);
//		Operation op;
//
//		bool operand[2]; // 1 - reg, 0 - mem
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
//					operand[j++] = false;
//					int endName = i;
//					while (command[endName] != ',')
//						endName++;
//
//					opname.push_back(command.substr(i, endName - i));
//					i = endName - 1;
//				}
//				else
//				{
//					operand[j++] = true;
//					opname.push_back(command.substr(i, 2));
//				}
//			}
//			else if (command[i] == ',')
//			{
//				i++;
//				while (command[i] == ' ')
//					i++;
//				if (command[i] == '[')
//				{
//					operand[j++] = false;
//					opname.push_back(command.substr(i, command.size() - i));
//				}
//				else
//				{
//					operand[j++] = true;
//					opname.push_back(command.substr(i, 2));
//				}
//				break;
//			}
//		}
//
//
//		if (name == "add")
//			op.opcode = "000000";
//		else if (name == "and")
//			op.opcode = "001000";
//		else
//			op.opcode = "001100";
//
//		if (operand[0] && operand[1])
//		{
//			reg_reg(&op, &opname);
//		}
//		else if (!operand[0] && operand[1] || operand[0] && !operand[1])
//		{
//			if ((!operand[0] && opname[0].find('+') != -1) || (!operand[1] && opname[1].find('+') != -1))
//				reg_memDisp(&op, memt, &opname, operand);
//			else
//				reg_mem(&op, memt, &opname, operand);
//		}
//
//		cout << "opcode" << '\t' << "d" << '\t' << "w" << '\t' << "mod" << '\t' << "reg" << '\t' << "r/m" << "\tdisp_l\t" << "\tdisp_h" << endl;
//		cout << op.opcode << '\t' << op.d << '\t' << op.w << '\t' << op.mod << '\t' << op.reg << '\t' << op.rm;
//
//		if (op.mod == "01")
//			cout << '\t' << op.disp_l << endl;
//		else if (op.mod == "10")
//			cout << '\t' << op.disp_l << '\t' << op.disp_h << endl;
//		cout << endl << endl;
//	}
//
//	return 0;
//}