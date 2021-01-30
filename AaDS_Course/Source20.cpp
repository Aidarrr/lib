//#include <iostream>
//#include <vector>
//using namespace std;
//
//void calculatePartSum(vector<uint64_t> &partSum, uint32_t n) {
//	partSum.push_back(0);
//	
//	for (uint32_t i = 1; i <= n; i++) {
//		uint64_t el;
//		cin >> el;
//		partSum.push_back(partSum[i - 1] + el);
//	}
//}
//
//void calcSumInSegment(vector<uint64_t>& partSum, uint32_t q) {
//
//	uint32_t left, right;
//	for (uint32_t i = 0; i < q; i++) {
//		cin >> left >> right;
//		cout << partSum[right] - partSum[left - 1] << endl;
//	}
//	
//}
//
//int main() {
//    uint32_t n, q;
//	cin >> n >> q;
//	
//	vector<uint64_t> partSum;
//
//	calculatePartSum(partSum, n);
//
//	calcSumInSegment(partSum, q);
//	
//
//    return 0;
//}