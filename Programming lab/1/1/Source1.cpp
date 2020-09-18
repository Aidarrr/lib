//#include <iostream>
//#include <cmath>
//using namespace std;
//
//int * numArray(int num, int n)
//{
//	int *arr = new int[n];
//	for (int i = 0; i < n; i++)
//		arr[i] = (num / (int)(pow(10, n - i - 1))) % 10;
//
//	return arr;
//}
//
//int main()
//{
//	int n, num = 0, temp;
//	cin >> n;
//	int *arr = new int[n];
//	int *maxArr = new int[n];
//	int *minArr = new int[n];
//	cin >> num;
//	int max = 0, iMax = 0, iMaxArr = 0;
//	int min = 9, iMin = 0, iMinArr = 0;
//
//	arr = numArray(num, n);
//
//	for (int i = 0; i < n; i++)
//	{
//		for (int j = 0; j < n; j++)
//		{
//			if (arr[j] > max)
//			{
//				max = arr[j];
//				iMax = j;
//			}
//		}
//
//		arr[iMax] = 0;
//		maxArr[iMaxArr++] = max;
//		max = 0;
//	}
//
//	arr = numArray(num, n);
//
//	for (int i = 0; i < n; i++)
//	{
//		for (int j = 0; j < n; j++)
//		{
//			if (arr[j] < min && i != 0)
//			{
//				min = arr[j];
//				iMin = j;
//			}
//			else if (i == 0 && arr[j] < min && arr[j] != 0)
//			{
//				min = arr[j];
//				iMin = j;
//			}
//		}
//
//		arr[iMin] = 9;
//		minArr[iMinArr++] = min;
//		min = 9;
//	}
//
//	for (int i = 0; i < n; i++)
//		cout << maxArr[i];
//	cout << endl;
//	for (int i = 0; i < n; i++)
//	{
//		/*if (minArr[i] == 0 && i == 0)
//		{
//			temp = minArr[i+1];
//			minArr[i + 1] = minArr[i];
//			minArr[i] = temp;
//		}*/
//		cout << minArr[i];
//	}
//
//	delete[] arr;
//	delete[] minArr;
//	delete[] maxArr;
//}