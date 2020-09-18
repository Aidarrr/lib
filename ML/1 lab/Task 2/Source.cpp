//#include <iostream>
//#include <vector>
//#include <cctype>
//using namespace std;
//
//int main()
//{
//	vector<char> input;
//	input.push_back('4');
//	vector<char> neg;
//	vector<char> multiply1;
//	vector<char> multiply2;
//	vector<char> multiplyLast;
//	vector<char> result;
//	bool fl = 0;
//
//	vector<char> mult{input[1], input[5], input[7], input[8], input[9], input[2], input[5], input[7], input[8], input[9], input[3], input[5], input[7], input[8], input[9], input[4], input[5], input[7], input[8], input[9],  };
//
//	char t;
//
//	for (int i = 0; i < 12; i++)
//	{
//		cin >> t;
//		input.push_back(t);
//	}
//
//	neg.push_back(toupper(input[4]));
//	neg.push_back(toupper(input[5]));
//
//	for (int i = 0; i < 2; i++)
//	{
//		for (int j = 0; j < 4; j++)
//		{
//			multiply1.push_back(neg[i]);
//			multiply1.push_back(input[j]);
//			
//		}
//	}
//
//	for (int i = 0; i < multiply1.size() - 1; i+=2)
//	{
//		multiply2.push_back(input[6]);
//		multiply2.push_back(toupper(input[7]));
//		multiply2.push_back(multiply1[i]);
//		multiply2.push_back(multiply1[i+1]);
//	}
//
//	for (int i = 8; i < 12; i+=3)
//	{
//		for (int j = 0; j < multiply2.size() - 3; j+= 4)
//		{
//			multiplyLast.push_back(input[i]);
//			multiplyLast.push_back(multiply2[j]);
//			multiplyLast.push_back(multiply2[j + 1]);
//			multiplyLast.push_back(multiply2[j + 2]);
//			multiplyLast.push_back(multiply2[j + 3]);
//		}
//	}
//
//	for (int i = 0; i < multiply2.size() - 3; i+=4)
//	{
//		multiplyLast.push_back(toupper(input[9]));
//		multiplyLast.push_back(toupper(input[10]));
//		multiplyLast.push_back(multiply2[i]);
//		multiplyLast.push_back(multiply2[i + 1]);
//		multiplyLast.push_back(multiply2[i + 2]);
//		multiplyLast.push_back(multiply2[i + 3]);
//	}
//
//	for (int i = 0; i < multiplyLast.size() - 48; i+=5)
//	{
//		cout << multiplyLast[i] << multiplyLast[i + 1] << multiplyLast[i + 2] << multiplyLast[i + 3] << multiplyLast[i + 4];
//		cout << ' ';
//	}
//
//		for (int i = 0; i < 80; i+=5)
//	{
//		fl = 0;
//		for (int j = i; j < i+5; j++)
//		{
//			for (int k = i; k < i+5; k++)
//			{
//				if (toupper(multiplyLast[j]) == multiplyLast[k] && j != k)
//				{
//					fl++;
//				}
//			}
//
//		}
//
//		if (fl == 0)
//		{
//			result.push_back(multiplyLast[i]);
//			result.push_back(multiplyLast[i + 1]);
//			result.push_back(multiplyLast[i + 2]);
//			result.push_back(multiplyLast[i + 3]);
//			result.push_back(multiplyLast[i + 4]);
//		}
//	}
//
//	for (int i = 0; i < 48; i += 6)
//	{
//		fl = 0;
//		for (int j = i; j < i + 6; j++)
//		{
//			for (int k = i; k < i + 6; k++)
//			{
//				if (toupper(multiplyLast[j]) == multiplyLast[k] && j != k)
//				{
//					fl++;
//				}
//			}
//
//		}
//
//		if (fl == 0)
//		{
//			result.push_back(multiplyLast[i]);
//			result.push_back(multiplyLast[i + 1]);
//			result.push_back(multiplyLast[i + 2]);
//			result.push_back(multiplyLast[i + 3]);
//			result.push_back(multiplyLast[i + 4]);
//			result.push_back(multiplyLast[i + 5]);
//		}
//	}
//
//	for (int i = 0; i < result.size(); i++)
//	{
//		cout << result[i];
//	}
//	return 0;
//}