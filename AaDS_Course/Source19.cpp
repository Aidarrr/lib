//#include <iostream>
//
//using namespace std;
//
//int64_t mod = 1791791791, cur, a, b;
//
//int64_t NextRand() {
//    cur = (cur * a + b) % mod;
//    return cur;
//}
//
//int main() {
//    uint32_t n, indexFirst = 0, indexSecond = 0;
//    cin >> n;
//    cin >> cur >> a >> b;
//
//    int64_t maxFirst = -1, maxSecond = -1;
//    int64_t el;
//
//
//    for (uint32_t i = 0; i < n; i++){
//        el = NextRand();
//        cin >> el;
//        if (el > maxFirst) {
//            maxSecond = maxFirst;
//            maxFirst = el;
//            indexSecond = indexFirst;
//            indexFirst = i;
//        }
//        else if (el > maxSecond) {
//            maxSecond = el;
//            indexSecond = i;
//        }
//    }
//    cout << indexFirst + 1 << ' ' << indexSecond + 1;
//    return 0;
//}