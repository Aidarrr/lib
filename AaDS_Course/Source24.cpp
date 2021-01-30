//#include <iostream>
//#include <vector>
//using namespace std;
//
//int getFirstOnePosition(int arraySize, uint16_t binSearchIterations) {
//	int left = -1, right = arraySize, middle;
//	int middleValue;
//
//	while (left + 1 < right) {
//		cin >> middleValue;
//		middle = (right - left) / 2 + left;
//
//		if (middleValue == 0) {
//			left = middle;
//		}
//		else {
//			right = middle;
//		}
//	}
//	return right;
//}
//
//int main() {
//	int arraySize;
//	uint16_t binSearchIterations;
//	cin >> arraySize >> binSearchIterations;
//
//	cout << getFirstOnePosition(arraySize, binSearchIterations);
//
//	return 0;
//}