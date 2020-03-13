#include <iostream>
#include<vector>
using namespace std;

class Carriage
{
public:
	virtual int GetWeight() = 0;
};

class Tank : public Carriage
{
private:
	int weight;
public:
	Tank(int weight) 
	{
		this->weight = weight;
	}
	int GetWeight() override
	{

	}
};

class CarTransport : public Carriage
{
public:
	int GetWeight() override
	{

	}
};

class ForestTransport : public Carriage
{
public:
	int GetWeight() override
	{

	}
};

class Passenger : public Carriage
{
public:
	int GetWeight() override
	{

	}
};

class Restaurant : public Carriage
{
public:
	int GetWeight() override
	{

	}
};

int main()
{
	vector<Carriage> train;
	int n, k; cin >> n;

	for (size_t i = 0; i < n; i++)
	{
		cin >> k;
		Tank tank(k);

		train.push_back(tank);
	}

	

	return 0;
}