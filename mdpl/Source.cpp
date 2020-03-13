//#include <iostream>
//#include <bitset>
//using namespace std;
//
//struct el_regt
//{
//	char name[3];
//	char code;
//};
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
//	el_regt regt[16] =
//	{
//		{"ax", 8},
//		{"cx", 9},
//		{"dx", 10},
//		{"bx", 11},
//		{"sp", 12},
//		{"bp", 13},
//		{"si", 14},
//		{"di", 15},
//		{"al", 0},
//		{"cl", 1},
//		{"dl", 2},
//		{"bl", 3},
//		{"ah", 4},
//		{"ch", 5},
//		{"dh", 6},
//		{"bh", 7}
//	};
//
//	cout << "name	code	width\n";
//
//	for (size_t i = 0; i < 16; i++)
//	{
//		i2b(regt[i].code);
//		cout << regt[i].name << '\t' << t << '\t' << (regt[i].code >> 3) << endl;
//	}
//	return 0;
//}