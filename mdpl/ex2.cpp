//#include <iostream>
//#include <string>
//#include <map>
//#include <set>
//#include <vector>
//using namespace std;
//
//int main()
//{
//	int addr = 0;
//	string command;
//	vector <pair<int, string>> names;
//	vector <pair<int, string>> seg;
//	bool fl = true;
//
//	while(getline(cin, command) && command != "")
//	{
//		if (command.find("ends") != -1)
//		{
//			seg.push_back({addr, command.substr(0, command.find("ends") - 1) });
//			addr = 0;
//		}
//		for (size_t i = 0; i < command.size(); i++)
//		{
//			if (command[i] == ' ')
//			{
//				if (i == 0)
//					break; 
//				names.push_back({ addr, command.substr(0, i) });
//				break;
//			}
//		}
//		size_t db = command.find("db");
//		size_t dw = command.find("dw");
//		if (db != -1)
//		{
//			command.insert(db + 3, ",");
//			for (size_t i = db + 2; i < command.size(); i++)
//			{
//				if ((int)command[i] == 39)
//				{
//					i++;
//					while ((int)command[i] != 39)
//					{
//						addr++;
//						i++;
//					}
//				}
//				if (command[i] == ',')
//				{
//					i++;
//					while (command[i] != ',' && i < command.size())
//					{
//						if ((int)command[i] == 39)
//						{
//							i--;
//							fl = false;
//							break;
//						}
//						i++;
//					}
//					if (fl)
//					{
//						addr++;
//						i--;
//					}
//				}
//
//				fl = true;
//			}
//		}
//		else if(dw != -1)
//		{
//			int c = 0;
//			for (size_t i = dw + 2; i < command.size(); i++)
//			{
//				if (command[i] == ',')
//				{
//					c++;
//				}
//			}
//
//			addr += (c + 1) * 2;
//		}
//	}
//
//	for (size_t i = 0; i < seg.size(); i++)
//	{
//		cout << seg[i].second << ' ' << seg[i].first << endl;
//	}
//
//	return 0;
//}