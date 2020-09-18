//#include <iostream>
//#include <vector>
//#include <algorithm>
//using namespace std;
//
//int main()
//{
//	int x, y, m;
//	cin >> x >> y >> m;
//
//	vector<int> sum1;
//	vector <int> sum2;
//	sum1.push_back(x);
//	sum2.push_back(y);
//
//	int i = 0;
//	bool t1 = false, t2 =false;
//	while (1)
//	{
//		t1 = false; t2 = false;
//		if (sum1[i] + x <= m)
//		{
//			sum1.push_back(sum1[i] + x);
//		}
//		else
//			t1 = true;
//		
//		if (sum1[i] + y <= m)
//		{
//			sum1.push_back(sum1[i] + y);
//			i++;
//		}
//		else
//			t2 = true;
//		
//		if (t1 && t2)
//			break;
//	}
//	while (1)
//	{
//		t1 = false; t2 = false;
//		if (sum2[i] + x <= m)
//		{
//			sum2.push_back(sum2[i] + x);
//		}
//		else
//			t1 = true;
//
//		if (sum2[i] + y <= m)
//		{
//			sum2.push_back(sum2[i] + y);
//			i++;
//		}
//		else
//			t2 = true;
//		if (t1 && t2)
//			break;
//	}
//	cout << max(*max(sum1.begin(), sum1.end()), *max(sum2.begin(), sum2.end()));
//
//}