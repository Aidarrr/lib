//#include <iostream>
//#include <vector>
//using namespace std;
//
//uint32_t getIterationsCount(uint32_t arraySize, uint32_t firstOnePosition) {
//	int left = -1, right = arraySize;
//	uint32_t middle, iterations = 0;
//
//	while (left + 1 < right) {
//		middle = (right - left) / 2 + left;
//
//		if (middle < firstOnePosition) {
//			left = middle;
//		}
//		else {
//			right = middle;
//		}
//		iterations++;
//	}
//	return iterations;
//}
//
//int main() {
//	uint32_t arraySize, queryCount, k;
//	cin >> arraySize >> queryCount;
//
//	for (uint32_t i = 0; i < queryCount; i++){
//		cin >> k;
//		cout << getIterationsCount(arraySize, k) << endl;
//	}
//	return 0;
//}