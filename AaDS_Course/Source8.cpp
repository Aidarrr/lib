//#include <iostream>
//#include <string>
//#include <algorithm>
//using namespace std;
//
//int getPlaneFromPoint(int x, int y) {
//	if (x > 0 && y > 0)
//		return 0;
//	else if (x < 0 && y > 0)
//		return 1;
//	else if (x < 0 && y < 0)
//		return 2;
//	else if (x > 0 && y < 0)
//		return 3;
//	return -1;
//}
//
//int main() {
//	int planes[4] = {0};
//	int n, x, y, planeNum;
//	cin >> n;
//	for (size_t i = 0; i < n; i++)
//	{
//		cin >> x >> y;
//		planeNum = getPlaneFromPoint(x, y);
//		if(planeNum >= 0)
//			planes[planeNum]++;
//	}
//
//	int maxIndex = max_element(planes, planes + 4) - planes;
//	cout << maxIndex + 1 << ' ' << planes[maxIndex];
//
//	return 0;
//}