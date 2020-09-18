//#include <iostream>
//using namespace std;
//
//int p = 1;
//
//void Sundaram(bool massiv[], int N)
//{
//	int i, j;
//	for (i = 1; i <= N; i++)
//	{
//		massiv[i] = true;
//	}
//	i = 1; j = 1;
//	while ((2 * i * j + i + j) <= N)
//	{
//		while (j <= (N - i) / (2 * i + 1))
//		{
//			massiv[2 * i * j + i + j] = false;
//			j++;
//		}
//		i++;
//		j = i;
//	}
//	for (i = 1; i <= N; i++)
//	{
//		if (massiv[i]) p *= 2 * i + 1;
//	}
//}
//
//int main()
//{
//	int N;
//	bool* massiv;
//	cin >> N;
//	if (N > 1)
//		p *= 2;
//	massiv = new bool[N];
//	Sundaram(massiv, N / 2 - 1);
//	delete[] massiv;
//	cout << p;
//	return 0;
//}