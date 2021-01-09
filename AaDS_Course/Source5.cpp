//#include <iostream>
//#include <algorithm>
//
//std::string getWedges(uint32_t x) {
//	using namespace std;
//	string numberInVavilon = "";
//	uint32_t dozens = x / 10;
//	uint32_t units = x % 10;
//
//	for (size_t i = 0; i < units; i++)
//	{
//		numberInVavilon.push_back('v');
//	}
//
//	for (size_t i = 0; i < dozens; i++)
//	{
//		numberInVavilon.push_back('<');
//	}
//	return numberInVavilon;
//}
//
//int main() {
//	using namespace std;
//	
//	string numberInVavilon = "";
//	uint32_t num;
//	cin >> num;
//
//	while (num >= 60) {
//		uint32_t mod = num % 60;
//		num /= 60;
//
//		numberInVavilon += getWedges(mod);
//		numberInVavilon.push_back('.');
//	}
//
//	if (num <= 60 && num != 0) {
//		numberInVavilon += getWedges(num);
//	}
//
//	reverse(numberInVavilon.begin(), numberInVavilon.end());
//	cout << numberInVavilon;
//	return 0;
//}