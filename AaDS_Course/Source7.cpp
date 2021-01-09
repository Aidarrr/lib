//#include <iostream>
//#include <string>
//
//class Time {
//public:
//	static const uint32_t MAX_DAY_SECONDS = 86400;
//
//private:
//	uint32_t totalSeconds;
//	uint8_t hh, mm, ss;
//
//public:
//	Time(std::string time) {
//		
//		hh = stoi(time.substr(0, 2));
//		mm = stoi(time.substr(3, 2));
//		ss = stoi(time.substr(6, 2));
//
//		totalSeconds = hh * 60;
//		totalSeconds = (totalSeconds + mm) * 60;
//		totalSeconds += ss;
//	}
//
//	uint32_t getTotalSeconds() {
//		return totalSeconds;
//	}
//};
//
//int main() {
//	using namespace std;
//
//	string time;
//	cin >> time;
//	Time currentTime(time);
//
//	cin >> time;
//	Time alarmTime(time);
//
//
//
//	if (currentTime.getTotalSeconds() < alarmTime.getTotalSeconds()) {
//		cout << alarmTime.getTotalSeconds() - currentTime.getTotalSeconds();
//	}
//	else {
//		cout << Time::MAX_DAY_SECONDS - (currentTime.getTotalSeconds() - alarmTime.getTotalSeconds());
//	}
//
//	return 0;
//}