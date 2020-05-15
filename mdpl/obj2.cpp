//#include <iostream>
//#include <string>
//#include <vector>
//#include <algorithm>
//#include <bitset>
//#include <sstream>
//
//using namespace std;
//
//char* bin_to_hex(const char* b, char* h) {
//	int m, n, i, j;
//	const char* p = b;
//	char ch, * q, * t = h;
//
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
//	int len = 0, indx = 2;
//	string command;
//	//vector <pair<int, int>> seg;
//	bool fl = true;
//	vector <vector<string>> hex_names;
//	
//	char ch[32];
//	string acbp = "011";
//
//	while (getline(cin, command) && command != "")
//	{
//		if (command.find("stack") != -1)
//		{
//			acbp += "101";
//		}
//		else if (command.find("segment") != -1)
//		{
//			acbp += "000";
//		}
//		if (command.find("ends") != -1)
//		{
//			//seg.push_back({ len, indx });
//			int chksum = 152;
//
//			if (len < 65536)
//				acbp += "0";
//			else if (len == 65536)
//			{
//				acbp += "1";
//				len = 0;
//			}
//			acbp += "0";
//
//			vector <string> str;
//			str.push_back("98");
//			
//			string rec_len = bin_to_hex(bitset<16>(5).to_string().c_str(), ch);;//определить
//
//
//			str.push_back(rec_len.substr(2, 2));
//
//			int x;
//			stringstream ss;
//			ss << hex << str.back();
//			ss >> x;
//			chksum += x;
//			ss.clear();
//
//			str.push_back(rec_len.substr(0, 2));
//
//			ss << hex << str.back();
//			ss >> x;
//			chksum += x; ss.clear();
//
//			str.push_back(bin_to_hex(acbp.c_str(), ch));
//
//			ss << hex << str.back();
//			ss >> x;
//			chksum += x; ss.clear();
//			
//			chksum += indx; //
//			string seg_len = bin_to_hex(bitset<16>(len).to_string().c_str(), ch);
//			str.push_back(seg_len.substr(2, 2));
//
//			ss << hex << str.back();
//			ss >> x;
//			chksum += x; ss.clear();
//
//			str.push_back(seg_len.substr(0, 2));
//
//			ss << hex << str.back();
//			ss >> x;
//			chksum += x; ss.clear();
//
//			str.push_back(bin_to_hex(bitset<8>(indx).to_string().c_str(), ch));
//			
//			str.push_back(bin_to_hex(bitset<8>(256 - chksum).to_string().c_str(), ch));
//
//			hex_names.push_back(str);
//			len = 0;
//			indx++;
//			acbp = "011";
//		}
//		
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
//						len++;
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
//						len++;
//						i--;
//					}
//				}
//
//				fl = true;
//			}
//		}
//		else if (dw != -1)
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
//			len += (c + 1) * 2;
//		}
//	}
//
//	for (size_t i = 0; i < hex_names.size(); i++)
//	{
//		for (size_t j = 0; j < hex_names[i].size() - 1; j++)
//		{
//			cout << hex_names[i][j] << ' ';
//		}
//		cout << hex_names[i][hex_names[i].size() - 1] << endl;
//	}
//
//	return 0;
//}