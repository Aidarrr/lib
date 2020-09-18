//#include <iostream>
//#include <vector>
//#include <algorithm>
//#include <string>
//#include <sstream>
//#include <iterator>
//#include <map>
//using namespace std;
//
//int main()
//{
//	bool fl = 0;
//	int n, count = 0, same_char = 0;
//	string temp, a;
//	vector<string> tokens;
//	stringstream stream;
//	cin >> a >> n;
//	for (int i = 0; i < n; i++)
//	{
//		getline(cin, temp);
//		stream.clear();
//		stream.str(temp);
//		while (getline(stream, temp, ' '))
//			tokens.push_back(temp);
//	}
//	for (int i = 0; i < tokens.size(); i++)
//	{
//		for (int j = 0; j < tokens[i].size(); j++)
//		{
//			if (tokens[i][j] == '.' || tokens[i][j] == ',' || tokens[i][j] == ';')
//				tokens[i].erase(j);
//		}
//	}
//
//	for (int i = 0; i < tokens.size(); i++)
//	{
//
//	}
//	return 0;
//}