//#include <iostream>
//#include <string>
//using namespace std;
//
//void swap(uint32_t* xp, uint32_t* yp)
//{
//	uint32_t temp = *xp;
//	*xp = *yp;
//	*yp = temp;
//}
//
//void bubbleSort(uint32_t arr[], uint16_t n)
//{
//	int i, j;
//	for (i = 0; i < n - 1; i++)
//		for (j = 0; j < n - i - 1; j++)
//			if (arr[j] > arr[j + 1])
//				swap(&arr[j], &arr[j + 1]);
//}
//
//int main() {
//	uint16_t n, similarStones = 0;
//	cin >> n;
//	uint32_t* stonesWeight = new uint32_t[n];
//
//	for (size_t i = 0; i < n; i++){
//		cin >> stonesWeight[i];
//	}
//
//	bubbleSort(stonesWeight, n);
//
//	for (size_t i = 0; i < n - 1; i++){
//		if (stonesWeight[i] == stonesWeight[i + 1])
//			similarStones++;
//	}
//
//	if (similarStones <= 1)
//		cout << 1;
//	else
//		cout << 0;
//
//	return 0;
//}