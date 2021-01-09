//#include <iostream>
//#include <string>
//#include <algorithm>
//using namespace std;
//
//
//int main() {
//	uint32_t n, x, min1 = UINT32_MAX, min2 = UINT32_MAX, max1 = 0, max2 = 0;
//	cin >> n;
//
//	for (size_t i = 0; i < n; i++)
//	{
//		cin >> x;
//		
//		if (x > max1) {
//			max2 = max1;
//			max1 = x;
//		}
//		else if (x > max2) {
//			max2 = x;
//		}
//			
//		if (x < min1) {
//			min2 = min1;
//			min1 = x;
//		}
//		else if (x < min2) {
//			min2 = x;
//		}
//	}
//
//	cout << min1 + min2 << " " << max1 + max2;
//
//	return 0;
//}