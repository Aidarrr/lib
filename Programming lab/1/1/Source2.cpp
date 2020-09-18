//#include <iostream>
//using namespace std;
//
//int main()
//{
//	int n;
//	cin >> n;
//	int *arr = new int[n];
//	int tempOld, tempNew;
//
//	for (int i = 0; i < n; i++)
//	{
//		for (int j = 0; j < i + 1; j++)
//		{
//			if (j == 0 && i != 0)
//				arr[j] = 0;
//			else if ((j == 0 && i == 0) || j == i || j == 1)
//				arr[j] = 1;
//			else if (j == 2)
//			{
//				tempNew = arr[j];
//				arr[j] = arr[j - 1] + j * arr[j];
//			}
//			else if (j > 0 && j < i)
//			{
//				tempOld = arr[j];
//				arr[j] = tempNew + j * arr[j];
//				tempNew = tempOld;
//			}
//
//			cout << arr[j];
//			if (j != i)
//				cout << ' ';
//		}
//
//		if(i != n - 1)
//		cout << endl;
//	}
//	
//	delete[] arr;
//}