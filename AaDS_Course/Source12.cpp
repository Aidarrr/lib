//#include <iostream>
//#include <string>
//using namespace std;
//
//int main() {
//	uint16_t n;
//	uint32_t x = 2;
//	cin >> n;
//
//	bool* sieve = new bool[n + 1];
//	
//	for (size_t i = 0; i <= n; i++){
//		sieve[i] = true;
//	}
//	sieve[0] = false; sieve[1] = false;
//
//	while (x * x <= n) {
//		if (sieve[x]) {
//			for (size_t i = x * x; i <= n; i+=x){
//				sieve[i] = false;
//			}
//		}
//		x++;
//	}
//
//	for (size_t i = 0; i <= n; i++) {
//		if (sieve[i]) {
//			cout << i << ' ';
//		}
//	}
//
//	return 0;
//}