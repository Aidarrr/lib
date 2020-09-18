//#include <iostream>
//#include <vector>
//#include <map>
//#include <sstream>
//#include <string>
//#include <iterator>
//#include<algorithm>
//using namespace std;
//
//string screen_ready(string temp)
//{
//	while (temp.size() < 4)
//		temp = "0" + temp;
//	return temp;
//}
//
//int main()
//{
//	vector<string> tokens;
//	string temp;
//	stringstream stream;
//	vector<vector<string>> code;
//	vector<vector<string>> MDT;
//	map<int, string> MNT;
//	bool fl = 0; int count = 0;
//
//	while (getline(cin, temp) && temp != "main endp")
//	{
//		if (temp == "")
//			continue;
//		stream.clear();
//		stream.str(temp);
//		while (getline(stream, temp, ' '))
//			tokens.push_back(temp);
//
//		code.push_back(tokens);
//
//		tokens.clear();
//	}
//
//	for (size_t i = 0; i < code.size(); i++)
//	{
//		for (size_t j = 0; j < code[i].size(); j++)
//		{
//			if (code[i][j] == "macro" && code[i][j - 1] != "exit")
//				fl = 1;
//		}
//		if (fl)
//			MDT.push_back(code[i]);
//		for (size_t j = 0; j < code[i].size(); j++)
//		{
//			if (code[i][j] == "endm")
//				fl = 0;
//		}
//	}
//
//	for (size_t i = 0; i < MDT.size(); i++)
//	{
//		for (size_t j = 0; j < MDT[i].size(); j++)
//			if (MDT[i][j] == "macro")
//				MNT.insert({ i + 1, MDT[i][0] });
//	}
//
//	fl = 0;
//	int indx = 0;
//	for (size_t i = 0; i < code.size(); i++)
//	{
//		if (code[i][0] == "main")
//		{
//			if (code[i][1] == "proc")
//			{
//				indx = i+1;
//
//			}
//		}
//	}
//	for (size_t i = indx; i < code.size(); i++)
//	{
//		for (auto it = MNT.begin(); it != MNT.end(); it++)
//		{
//			if (it->second == code[i][0])
//			{
//				count++;
//				temp = to_string(count);
//				temp = screen_ready(temp);
//				code[i] = MDT[it->first];
//				for (size_t l = 0; l < code[i].size(); l++)
//				{
//					auto iter = code[i][l].find("&sys_indx");
//					if (iter != std::string::npos)
//						code[i][l].replace(iter, 9, temp);
//
//				}
//				for (size_t k = it->first + 1; k < MDT.size(); k++)
//				{
//					if (MDT[k][0] == "endm")
//						break;
//					code.insert(code.begin() + i + 1, MDT[k]);
//					i++;
//
//
//					for (size_t l = 0; l < code[i].size(); l++)
//					{
//						auto iter = code[i][l].find("&sys_indx");
//
//						if (iter != std::string::npos)
//							code[i][l].replace(iter, 9, temp);
//
//					}
//				}
//
//			}
//		}
//	}
//
//	fl = 0;
//
//	for (size_t i = indx; i < code.size(); i++)
//	{
//		auto iter = find(code[i].begin(), code[i].end(), ":");
//
//		for (size_t j = 0; j < code[i].size(); j++)
//		{
//
//			auto iter2 = code[i][j].find(":");
//			if (iter != code[i].end() || iter2 != std::string::npos)
//				cout << code[i][j];
//			else
//			{
//				if (j == 0)
//					cout << ' ' << code[i][j];
//				else
//					cout << code[i][j];
//			}
//
//
//			if (j != code[i].size() - 1)
//				cout << ' ';
//
//		}
//		if (i != code.size() - 1)
//			cout << endl;
//
//	}
//	return 0;
//}