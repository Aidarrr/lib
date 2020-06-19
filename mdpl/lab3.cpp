//#include <iostream>
//#include <string>
//#include <vector>
//#include <algorithm>
//#include <bitset>
//#include <fstream>
//#include <sstream>
//#define memt_size 5
//#define mnema_size 1
//#define lea_size 1
//#define no_op_size 2
//#define define_size 1
//using namespace std;
//
//char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di" };
//
//bool reg[2], mem[2], bx[2], bp[2], name[2], disp, disp_l, disp_h, w, d, mnema, lea, no_op, def;
//int regs[2];
//int disp_int, addr = 256;
//string names[2];
//void clear()
//{
//	lea = false; mnema = false; no_op = false; def = false;
//	for (size_t i = 0; i <2; i++)
//	{
//		reg[i] = false; mem[i] = false; bx[i] = false; bp[i] = false; names[i].clear();
//	}
//	disp = false;
//	disp_l = false;
//	disp_h = false;
//	w = false;
//	d = false;
//}
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
//	string data;
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
//struct Opcode_t
//{
//	string name;
//	string code;
//};
//
//Opcode_t mnema_opcode[mnema_size] = {{"add", "000000"}};
//Opcode_t lea_opcode[lea_size] = { {"lea", "1011"} };
//Opcode_t no_opcode[no_op_size] = { {"ret", "11000011"}, {"end", "1011100000000000010011001100110100100001"} };
//Opcode_t def_opcode[define_size] = { {"dw", "?"} };
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
//void reg_name(Operation* op)
//{
//	op->reg = i2b(regs[0], 3);
//	op->data = names[1];
//}
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
//		for (size_t i = 0; i < 16; i++)
//			if (*opname == regt[i])
//			{
//				reg[n] = 1;
//				regs[n] = i;
//			}
//		if (reg[n] == 0)
//		{
//			name[n] = 1;
//			names[n] = *opname;
//		}
//		else
//			w = (regs[n] >> 3);
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
//	else if (reg[0] && name[1])
//		reg_name(op);
//	if (disp)
//		set_disp(op);
//}
//
//char* bin_to_hex(const char* b, char* h) {
//	int m, n, i, j;
//	const char* p = b;
//	char ch, * q, * t = h;
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
//void name_dw(vector <string> *com, string *name, string *command)
//{
//	for (size_t i = 0; i < (*com).size(); i++)
//	{
//		if ((*com)[i].find(*name) != -1)
//		{
//			(*com)[i] = (*com)[i].substr(0, 8);
//			if ((*com)[i][4] == '1')
//			{
//				 string t = bitset<16>(addr).to_string();
//				 (*com)[i] += t.substr(8,8);
//				 (*com)[i] += t.substr(0, 8);
//			}
//			else
//			{
//				(*com)[i] += bitset<8>(addr).to_string();
//			}
//		}
//	}
//
//	for (int i = (*command).find("dw") + 3; i < (*command).size(); i++)
//	{
//		string t;
//		while ((*command)[i] != ',' && i != (*command).size())
//		{
//			t += (*command)[i];
//			i++;
//		}
//		t = bitset<16>(stoi(t)).to_string();
//		(*com).push_back(t.substr(8, 8) + t.substr(0, 8));
//	}
//}
//
//int main()
//{
//	ifstream in_file("input.txt");
//	string command;
//	vector <string> hex;
//	vector<string> com;
//	char ch[64];
//	while (getline(in_file, command))
//	{
//		Operation op;
//		vector<string> opname;
//		string name; int endname, indx_noop;
//
//		for (size_t i = 0; i < command.size(); i++)
//		{
//			if (command[i] == ' ' || i == command.size() - 1)
//			{
//				name = command.substr(0, i);
//				if (i == command.size() - 1)
//					name = command.substr(0, i + 1);
//				endname = i + 1;
//				for (size_t i = 0; i < mnema_size; i++)
//					if (name == mnema_opcode[i].name)
//					{
//						mnema = 1;
//						op.opcode = mnema_opcode[i].code;
//					}
//				for (size_t i = 0; i < lea_size; i++)
//					if (name == lea_opcode[i].name)
//					{
//						lea = 1;
//						op.opcode = lea_opcode[i].code;
//					}
//				for (size_t i = 0; i < define_size; i++)
//					if (command.find(def_opcode[i].name) != -1)
//						def = 1;
//				for (size_t i = 0; i < no_op_size; i++)
//					if (name == no_opcode[i].name)
//					{
//						indx_noop = i;
//						no_op = 1;
//					}
//				break;
//			}
//		}
//
//		if (lea || mnema)
//		{
//			for (int i = endname, j = 0; i < command.size(); i++)
//			{
//				if (command[i] != ' ' && opname.size() == 0)
//				{
//					int endName = i;
//					while (command[endName] != ',')
//						endName++;
//
//					opname.push_back(command.substr(i, endName - i));
//					i = endName - 1;
//				}
//				else if (command[i] == ',')
//				{
//					i++;
//					while (command[i] == ' ')
//						i++;
//					opname.push_back(command.substr(i, command.size() - i));
//					break;
//				}
//			}
//
//
//
//			operand(1, &opname[0]);
//			if (opname.size() == 2)
//			{
//				operand(2, &opname[1]);
//				syn(&op);
//			}
//			if (mnema)
//			{
//				command = op.opcode + to_string(op.d) + to_string(op.w) + op.mod + op.reg + op.rm;
//				addr += 2;
//				if (disp_l && disp_h)
//				{
//					command += op.disp_l + op.disp_h;
//					addr += 2;
//				}
//				else if (disp_l)
//				{
//					command += op.disp_l;
//					addr++;
//				}
//				com.push_back(command);
//
//			}
//			else if (lea)
//			{
//				command = op.opcode + to_string(op.w) + op.reg + op.data;
//				if (op.w == 1)
//					addr += 3;
//				else
//					addr += 2;
//				com.push_back(command);
//			}
//
//		}
//		else if (def)
//		{
//			name_dw(&com, &name, &command);
//			addr += 2;
//		}
//		else if (no_op)
//		{
//			com.push_back(no_opcode[indx_noop].code);
//			addr += no_opcode[indx_noop].code.size() / 8;
//		}
//		clear();
//	}
//	for (size_t i = 0; i < com.size(); i++)
//	{
//		hex.push_back(bin_to_hex(com[i].c_str(), ch));
//	}
//
//	in_file.close();
//
//	std::basic_string<uint8_t> bytes;
//	command.clear();
//	for (size_t i = 0; i < hex.size(); i++)
//	{
//		command += hex[i];
//	}
//
//	for (size_t i = 0; i < command.length(); i += 2) {
//		uint16_t byte;
//		std::string nextbyte = command.substr(i, 2);
//		std::istringstream(nextbyte) >> std::hex >> byte;
//		bytes.push_back(static_cast<uint8_t>(byte));
//	}
//
//	std::string result(begin(bytes), end(bytes));
//
//	std::ofstream output_file("com.com", std::ios::binary | std::ios::out);
//
//	output_file << result;
//	output_file.close();
//	return 0;
//}