//#include <iostream>
//#include <cmath>
//using namespace std;
//
//void bubleSort(int* arr, uint16_t n) {
//	bool isSorted = false;
//
//	while (not isSorted) {
//		uint16_t i = 0;
//		isSorted = true;
//
//		while (i < n - 1) {
//			if (arr[i] > arr[i + 1]) {
//				uint32_t tmp = arr[i + 1];
//				arr[i + 1] = arr[i];
//				arr[i] = tmp;
//				isSorted = false;
//			}
//			i++;
//		}
//	}
//}
//
//void writeArray(int* arr, uint16_t n) {
//	for (size_t i = 0; i < n; i++) {
//		cin >> arr[i];
//	}
//}
//
//void printArray(int* arr, uint16_t n) {
//	for (size_t i = 0; i < n; i++) {
//		cout << arr[i] << ' ';
//	}
//}
//
//int main() {
//	uint16_t n;
//	cin >> n;
//	int* arr = new int[n];
//
//	writeArray(arr, n);
//	bubleSort(arr, n);
//	printArray(arr, n);
//
//	return 0;
//}