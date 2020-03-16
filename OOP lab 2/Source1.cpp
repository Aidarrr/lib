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
		weight = 1000;
		name = "Цистерна";
		load = "Нефть";
	}
	Tank(int weight, string load)
	{
		this->weight = weight;
		name = "Цистерна";
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
		cout << "Груз цистерны: " << load << endl;
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
		weight = 1700;
		name = "Автомобили";
		amount = 50;
		vehicleType = "Легковые автомобили";
	}
	CarTransport(int weight, int amount, string vehicleType)
	{
		this->weight = weight;
		name = "Автомобили";
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
		cout << "Тип перевозимых автомобилей: " << vehicleType << endl;
		cout << "Количество автомобилей: " << amount << endl;
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
		weight = 2300;
		name = "Лес";
		capacity = 71000;
	}
	ForestTransport(int weight, int capacity)
	{
		this->weight = weight;
		name = "Лес";
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
		cout << "Грузоподъемность: " << capacity << endl;
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
		weight = 800;
		name = "Пассажиры";
		amount = 20;
	}
	Passenger(int weight, int amount)
	{
		this->weight = weight;
		name = "Пассажиры";
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
		cout << "Количество пассажиров: " << amount << endl;
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
		weight = 800;
		name = "Ресторан";
		sqr = 20;
	}
	Restaurant(int weight, int sqr)
	{
		this->weight = weight;
		name = "Ресторан";
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
		cout << "Площадь кухонного отделения: " << sqr << endl;
	}
};

int main()
{
	setlocale(LC_ALL, "Russian");
	vector<Carriage*> train;
	int n, k, sum = 0;
	
	srand(time(0));
	n = rand() % 20 + 2;

	for (int i = 0; i < n; i++)
	{
		k = rand() % 4;
		switch (k)
		{
		case 0:
		{
			Tank tank;
			train.push_back(&tank);
			break;
		}
		case 1:
		{
			CarTransport car;
			train.push_back(&car);
			break;
		}
		case 2:
		{
			ForestTransport forest;
			train.push_back(&forest);
			break;
		}
		case 3:
		{
			Passenger passenger;
			train.push_back(&passenger);
			break;
		}
		case 4:
		{
			Restaurant rest;
			train.push_back(&rest);
			break;
		}
		}
	}

	for (int i = 0; i < n; i++)
	{
		sum += train[i]->GetWeight();
		cout << train[i]->GetName() << endl;
	}
	cout << "Вес: " << sum << " кг.\n";

	return 0;
}