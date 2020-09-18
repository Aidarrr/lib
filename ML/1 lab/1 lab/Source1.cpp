//#include <iostream>
//#include <vector>
//#include <cctype>
//using namespace std;
//
//int main()
//{
//	vector<char> input;
//	input.push_back('4');
//	char t;
//
//	for (int i = 1; i < 13; i++)
//	{
//		cin >> t;
//		input.push_back(t);
//	}
//
//	vector<char> multiply{ input[1], input[5], input[7], input[8], input[9], input[2], input[5], input[7], input[8], input[9], input[3], input[5], input[7], input[8], input[9], input[4], input[5], input[7], input[8], input[9],
//					   input[1], input[6], input[7], input[8], input[9], input[2], input[6], input[7], input[8], input[9], input[3], input[6], input[7], input[8], input[9], input[4], input[6], input[7], input[8], input[9],
//					   input[1], input[5], input[7], input[8], input[12], input[2], input[5], input[7], input[8], input[12], input[3], input[5], input[7], input[8], input[12], input[4], input[5], input[7], input[8], input[12],
//					   input[1], input[6], input[7], input[8], input[12], input[2], input[6], input[7], input[8], input[12], input[3], input[6], input[7], input[8], input[12], input[4], input[6], input[7], input[8], input[12],
//					   input[1], input[5], input[7], input[8], input[10], input[11], input[2], input[5], input[7], input[8], input[10], input[11], input[3], input[5], input[7], input[8], input[10], input[11], input[4], input[5], input[7], input[8], input[10], input[11],
//					   input[1], input[6], input[7], input[8], input[10], input[11], input[2], input[6], input[7], input[8], input[10], input[11], input[3], input[6], input[7], input[8], input[10], input[11], input[4], input[6], input[7], input[8], input[10], input[11] };
//	
//	for (size_t i = 0; i < multiply.size() - 48; i+=5)
//	{
//
//		for (size_t j = i; j < i + 5; j++)
//		{
//			cout << multiply[j];
//		}
//		cout << ' ';
//	}
//
//	for (size_t i = multiply.size() - 48; i < multiply.size(); i+=6)
//	{
//		for (size_t j = i; j < i + 6; j++)
//		{
//			cout << multiply[j];
//		}
//		cout << ' ';
//	}
//
//	return 0;
//}