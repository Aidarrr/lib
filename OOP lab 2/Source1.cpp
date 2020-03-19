#include <iostream>
#include<vector>
#include <stdlib.h>
#include <time.h> 
using namespace std;

class Carriage
{
public:
	virtual void print() = 0;
	virtual int GetWeight() = 0;
	virtual string GetName() = 0;
};

class Tank : public Carriage
{
private:
	int weight;
	string name;
	string load;
public:
	Tank()
	{
		weight = rand() % 3000 + 1000;
		name = "��������";
		load = "�����";
	}
	Tank(int weight, string load)
	{
		this->weight = weight;
		name = "��������";
		this->load = load;
	}
	int GetWeight() override
	{
		return weight;
	}
	string GetName() override
	{
		return name;
	}
	void print() override
	{
		cout << "���� ��������: " << load << endl;
	}
};

class CarTransport : public Carriage
{
private:
	int weight;
	string name;
	int amount;
	string vehicleType;
public:
	CarTransport()
	{
		weight = rand() % 2500 + 1500;
		name = "����������";
		amount = 50;
		vehicleType = "�������� ����������";
	}
	CarTransport(int weight, int amount, string vehicleType)
	{
		this->weight = weight;
		name = "����������";
		this->amount = amount;
		this->vehicleType = vehicleType;
	}
	int GetWeight() override
	{
		return weight;
	}
	string GetName() override
	{
		return name;
	}
	void print() override
	{
		cout << "��� ����������� �����������: " << vehicleType << endl;
		cout << "���������� �����������: " << amount << endl;
	}
};

class ForestTransport : public Carriage
{
private:
	int weight;
	string name;
	int capacity;
public:
	ForestTransport()
	{
		weight = rand() % 3000 + 2300;
		name = "���";
		capacity = 71000;
	}
	ForestTransport(int weight, int capacity)
	{
		this->weight = weight;
		name = "���";
		this->capacity = capacity;
	}
	int GetWeight() override
	{
		return weight;
	}
	string GetName() override
	{
		return name;
	}
	void print() override
	{
		cout << "����������������: " << capacity << endl;
	}
};

class Passenger : public Carriage
{
private:
	int weight;
	string name;
	int amount;
public:
	Passenger()
	{
		weight = rand() % 1201 + 800;
		name = "���������";
		amount = 20;
	}
	Passenger(int weight, int amount)
	{
		this->weight = weight;
		name = "���������";
		this->amount = amount;
	}
	int GetWeight() override
	{
		return weight;
	}
	string GetName() override
	{
		return name;
	}
	void print() override
	{
		cout << "���������� ����������: " << amount << endl;
	}
};

class Restaurant : public Carriage
{
private:
	int weight;
	string name;
	int sqr;
public:
	Restaurant()
	{
		weight = rand() % 1001 + 800;
		name = "��������";
		sqr = 20;
	}
	Restaurant(int weight, int sqr)
	{
		this->weight = weight;
		name = "��������";
		this->sqr = sqr;
	}
	int GetWeight() override
	{
		return weight;
	}
	string GetName() override
	{
		return name;
	}

	void print() override
	{
		cout << "������� ��������� ���������: " << sqr << endl;
	}
};

int main()
{
	setlocale(LC_ALL, "Russian");
	int n, k, sum = 0;
	
	srand(time(0));
	n = rand() % 20 + 2;
	cout << "n = " << n << endl;
	cout << "������: .";
	for (int i = 0; i < n; i++)
	{
		k = rand() % 5;
		switch (k)
		{
		case 0:
		{
			Tank tank;
			sum += tank.GetWeight();
			cout << "[" << tank.GetName() << "].";
			break;
		}
		case 1:
		{
			CarTransport car;
			sum += car.GetWeight();
			cout << "[" << car.GetName() << "].";
			break;
		}
		case 2:
		{
			ForestTransport forest;
			sum += forest.GetWeight();
			cout << "[" << forest.GetName() << "].";
			break;
		}
		case 3:
		{
			Passenger passenger;
			sum += passenger.GetWeight();
			cout << "[" << passenger.GetName() << "].";
			break;
		}
		case 4:
		{
			Restaurant rest;
			sum += rest.GetWeight();
			cout << "[" << rest.GetName() << "].";
			break;
		}
		}
	}

	cout << "\n���: " << sum << " ��.\n";

	return 0;
}