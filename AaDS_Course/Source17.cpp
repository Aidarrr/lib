//#include <iostream>
//using std::cin;
//using std::cout;
//using std::endl;
//
//uint16_t getFirstDigit(uint16_t num) {
//    return num / 1000;
//}
//
//bool isNumWasHated(uint16_t num) {
//    if (((num % 4 == 0) && (getFirstDigit(num) != 4 && getFirstDigit(num) != 5)) ||
//        (num % 7 == 0 && (getFirstDigit(num) != 7 && getFirstDigit(num) != 1)) ||
//        (num % 9 == 0 && (getFirstDigit(num) != 9 && getFirstDigit(num) != 8)))
//        return true;
//    return false;
//}
//
//int main() {
//    uint32_t n, count = 0;
//    uint16_t num;
//    cin >> n;
//
//    for (size_t i = 0; i < n; i++) {
//        cin >> num;
//
//        if (isNumWasHated(num)) {
//            count++;
//            cout << num << endl;
//        }
//
//    }
//
//    if (count == 0)
//        cout << count;
//    return 0;
//}