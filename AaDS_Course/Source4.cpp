//#include <iostream>
//#include <string>
//
//class Car {
//private:
//	int speed;
//	std::string fullAutoNumber;
//	std::string autoNumberDigits;
//
//public:
//	Car(int speed, std::string autoNumber) {
//		this->speed = speed;
//		fullAutoNumber = autoNumber;
//		autoNumberDigits = autoNumber.substr(1, 3);
//	}
//
//	std::string getFullNumber() {
//		return fullAutoNumber;
//	}
//
//	std::string getNumberDigits() {
//		return autoNumberDigits;
//	}
//
//	int getSpeed() {
//		return speed;
//	}
//
//	int calculateCharge() {
//		int count = 1;
//		for (size_t i = 0; i < autoNumberDigits.size(); i++)
//		{
//			for (size_t j = i+1; j < autoNumberDigits.size(); j++)
//			{
//				if (autoNumberDigits[i] == autoNumberDigits[j])
//					count++;
//			}
//		}
//
//		if (count == 1)
//			return 100;
//		else if (count == 2)
//			return 500;
//		else
//			return 1000;
//	}
//};
//
//int main() {
//	using namespace std;
//
//	int speed;
//	string autoNumber = "";
//	int charge = 0;
//
//	while (true) {
//		cin >> speed;
//		cin >> autoNumber;
//		if (autoNumber == "A999AA")
//			break;
//
//		Car car(speed, autoNumber);
//
//		if (speed > 60)
//			charge += car.calculateCharge();
//	}
//
//	cout << charge;
//	return 0;
//}