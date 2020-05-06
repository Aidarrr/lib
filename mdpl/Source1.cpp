//#include <iostream>
//#include <string>
//#include <vector>
//#include <algorithm>
//using namespace std;
//
//char t[4] = "000";
//void i2b(char x)
//{
//	char m = 1;
//	for (size_t i = 0; i < 3; i++)
//	{
//		if (x & m) t[2 - i] = '1';
//		else t[2 - i] = '0';
//		m = m << 1;
//	}
//}
//
//int main()
//{
//	char regt[16][3] = { "al", "cl", "dl", "bl", "ah", "ch", "dh", "bh", "ax", "cx", "dx", "bx", "sp", "bp", "si", "di"};
//
//	cout << "name	code	width\n";
//
//	for (size_t i = 0; i < 16; i++)
//	{
//		i2b(i);
//		cout << regt[i] << '\t' << t << '\t' << (i >> 3) << endl;
//	}
//	cout << endl;
//	
//	string command;
//	while (true)
//	{
//		getline(cin, command);
//		string op1, op2;
//		bool fl = false;
//		int j;
//		for (int i = 0; i < command.size(); i++)
//		{
//			if (command[i] != ' ')
//			{
//				j = i + 3;
//				break;
//			}
//		}
//			
//		for (j; j < command.size(); j++)
//		{
//			if (command[j] != ' ' && !fl)
//			{
//				fl = true;
//				op1 = command.substr(j, 2);
//			}
//			else if (command[j] == ',')
//			{
//				j++;
//				while (command[j] == ' ')
//					j++;
//				op2 = command.substr(j, 2);
//				break;
//			}
//		}
//
//		for (int i = 0; i < 16; i++)
//		{
//			if (regt[i] == op1)
//			{
//				i2b(i);
//				cout << "  " << regt[i] << "  " << t << "  " << (i >> 3) << endl;
//				break;
//			}
//		}
//		for (int i = 0; i < 16; i++)
//		{
//			if (regt[i] == op2)
//			{
//				i2b(i);
//				cout << "  " << regt[i] << "  " << t << "  " << (i >> 3) << endl;
//				break;
//			}
//		}
//	}
//	return 0;
//}