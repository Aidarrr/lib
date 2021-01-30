#include <iostream>
#include <vector>
using namespace std;

int getLowerBound(uint32_t arraySize, vector<int>& arr, int valueForSearch) {
	int left = -1, right = arraySize;
	
	while (left + 1 < right) {
		int middle = (left + right) / 2;

		if (arr[middle] >= valueForSearch) {	
			right = middle;
		}
		else {
			left = middle;
		}
	}

	return right;
}

int main() {
	uint32_t arraySize, queryCount;
	cin >> arraySize >> queryCount;
	vector<int> sortedArray(arraySize, 0);
	int valueForSearch;

	string answers[2] = {"NO", "YES"};

	for (uint32_t i = 0; i < arraySize; i++){
		cin >> sortedArray[i];
	}

	for (uint32_t i = 0; i < queryCount; i++) {
		cin >> valueForSearch;
		int lower_bound = getLowerBound(arraySize, sortedArray, valueForSearch);
		lower_bound < arraySize ? cout << sortedArray[lower_bound] << endl : cout << "NO SOLUTION\n";
	}

	return 0;
}