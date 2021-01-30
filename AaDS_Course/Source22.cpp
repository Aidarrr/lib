//#include <iostream>
//#include <vector>
//using namespace std;
//
//bool isValidYear(uint64_t year) {
//	bool digits[10] = { false };
//
//	while (year > 0) {
//		uint16_t digit = year % 10;
//		year /= 10;
//
//		if (digit == 2 or digit == 0)
//			return false;
//
//		if (digits[digit])
//			return false;
//
//		digits[digit] = true;
//	}
//
//	return true;
//}
//
//int main() {
//	uint64_t year, maxPossibleYear = 100000000;
//	cin >> year;
//	year++;
//	while (!isValidYear(year) and year < maxPossibleYear) {
//		year++;
//	}
//
//	if (year >= maxPossibleYear)
//		cout << -1;
//	else
//		cout << year;
//	return 0;
//}