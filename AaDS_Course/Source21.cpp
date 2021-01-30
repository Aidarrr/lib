//#include <iostream>
//#include <vector>
//using namespace std;
//
//int64_t calculateMaxPartSumInSegments(uint32_t n) {
//	int64_t partSum = 0, maxPartSum = -1;
//
//	for (uint32_t i = 0; i < n; i++) {
//		int64_t el;
//		cin >> el;
//		partSum += el;
//
//		if (partSum > maxPartSum) {
//			maxPartSum = partSum;
//		}
//
//		if (partSum < 0) {
//			partSum = 0;
//		}
//	}
//
//	return maxPartSum;
//}
//
//int main() {
//	uint32_t n;
//	cin >> n;
//	cout << calculateMaxPartSumInSegments(n);
//
//	return 0;
//}