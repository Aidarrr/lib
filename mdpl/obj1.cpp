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
//	char ch[32];
//	string s;
//	getline(cin, s);
//
//	string rec_len;
//	string name_size;
//	vector<string> name;
//	int chksum = 128;
//	vector<string> t_module;
//
//	t_module.push_back("80");
//	int s_size = s.size();
//
//	name_size = bin_to_hex(bitset<8>(s_size).to_string().c_str(), ch);
//	chksum += s_size;
//
//	for (int i = 0; i < s_size; i++)
//	{
//		name.push_back(bin_to_hex(bitset<8>((int)s[i]).to_string().c_str(), ch));
//		chksum += (int)s[i];
//	}
//
//	rec_len = bin_to_hex(bitset<16>(1 + s_size + 1).to_string().c_str(), ch);
//
//	t_module.push_back(rec_len.substr(2, 2));
//
//	int x;
//	stringstream ss;
//	ss << hex << t_module.back();
//	ss >> x;
//	chksum += x;
//	ss.clear();
//	
//	t_module.push_back(rec_len.substr(0, 2));
//	ss << hex << t_module.back();
//	ss >> x;
//	chksum += x;
//	
//	t_module.push_back(name_size);
//	for (size_t i = 0; i < s.size(); i++)
//		t_module.push_back(name[i]);
//	
//	t_module.push_back(bin_to_hex(bitset<8>(256 - chksum).to_string().c_str(), ch));
//	for (size_t i = 0; i < t_module.size() - 1; i++)
//	{
//		cout << t_module[i] << ' ';
//	}
//	cout << t_module[t_module.size() - 1];
//
//	return 0;
//}