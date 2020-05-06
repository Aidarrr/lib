#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <bitset>
#include <sstream>

using namespace std;

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

void seg_str(vector<string> *seg_name)
{
	string in;
	int endname, startname;
	while (getline(cin, in))
	{
		endname = in.find("segment");
		if (endname != -1)
		{
			endname--;
			while (in[endname] == ' ')
				endname--;
			startname = endname;
			while (in[startname] != ' ' && startname != 0)
				startname--;
			if (in[startname] == ' ')
				startname++;
			(*seg_name).push_back(in.substr(startname, endname - startname + 1));
		}
	}
}

int main()
{
	char ch[32];
	vector <string> seg_name;
	vector <string> hex_names;
	vector <string> lnames;
	int chksum = 150;
	lnames.push_back("96");
	seg_name.push_back("");
	int s_size;

	seg_str(&seg_name);
	//получение имени сег.

	for (size_t i = 0; i < seg_name.size(); i++)
	{
		s_size = seg_name[i].size();
		hex_names.push_back(bin_to_hex(bitset<8>(s_size).to_string().c_str(), ch));
		chksum += s_size;
		for (size_t j = 0; j < s_size; j++)
		{
			hex_names.push_back(bin_to_hex(bitset<8>((int)seg_name[i][j]).to_string().c_str(), ch));
			chksum += (int)seg_name[i][j];
		}
	}

	string rec_len = bin_to_hex(bitset<16>(hex_names.size() + 1).to_string().c_str(), ch);

	lnames.push_back(rec_len.substr(2, 2));

	int x;
	stringstream ss;
	ss << hex << lnames.back();
	ss >> x;
	chksum += x;
	ss.clear();

	lnames.push_back(rec_len.substr(0, 2));
	ss << hex << lnames.back();
	ss >> x;
	chksum += x;

	for (size_t i = 0; i < hex_names.size(); i++)
	{
		lnames.push_back(hex_names[i]);
	}
	lnames.push_back(bin_to_hex(bitset<8>(256 - chksum).to_string().c_str(), ch));

	for (size_t i = 0; i < lnames.size() - 1; i++)
	{
		cout << lnames[i] << ' ';
	}
	cout << lnames[lnames.size() - 1];
	return 0;
}