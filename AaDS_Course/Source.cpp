//#include <iostream>
//
//int main() {
//	using namespace std;
//	bool flag = false;
//	uint16_t maxPowerOfTwo = 16384;
//	uint16_t x, powerOfTwo = 1;
//	cin >> x;
//
//	for (; powerOfTwo <= maxPowerOfTwo; powerOfTwo = powerOfTwo << 1) {
//		if (x == powerOfTwo) {
//			cout << "YES\n";
//			flag = true;
//			break;
//		}
//	}
//
//	if (!flag)
//		cout << "NO\n";
//
//	return 0;
//}