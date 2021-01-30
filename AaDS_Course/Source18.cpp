//#include <iostream>
//#include <cmath>
//
//using std::cin;
//using std::cout;
//using std::endl;
//
//
//int main() {
//    uint16_t experimentData = 1;
//    uint32_t count = 0;
//    double mathExpectation = 0.0, dispersion = 0.0, mathExpectationOfSQRdata = 0.0;
//    cout.precision(3);
//    cin >> experimentData;
//    while (experimentData != 0) {
//        count++;
//        mathExpectation += experimentData;
//        mathExpectationOfSQRdata += experimentData * experimentData;
//        cin >> experimentData;
//    }
//    mathExpectation = round(1000 * (mathExpectation / count)) / 1000;
//    mathExpectationOfSQRdata = round(1000 * (mathExpectationOfSQRdata / count)) / 1000;
//    dispersion = mathExpectationOfSQRdata - mathExpectation * mathExpectation;
//   
//    cout << std::fixed << mathExpectation << ' ' << dispersion;
//    return 0;
//}