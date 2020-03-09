#include <iostream>
using namespace std;

class Person
{
private:
	string first_name;
	string last_name;
	string middle_name;
	int age;
public:
	Person()
	{
		first_name = "Павел";
		last_name = "Костицын";
		middle_name = "Сергеевич";
		age = 19;
	}

	Person(string first, string last, string middle, int age)
	{
		first_name = first;
		last_name = last;
		middle_name = middle;
		this->age = age;
	}

	void setAge(int age)
	{
		if (age >= 0 && age <= 200)
			this->age = age;
	}

	void setName(string first)
	{
		if (first.size() > 0 && first.size() <= 20)
			first_name = first;
	}
	void setLastName(string last)
	{
		if (last.size() > 0 && last.size() <= 20)
			last_name = last;
	}
	void setMiddleName(string middle)
	{
		if (middle.size() > 0 && middle.size() <= 20)
			middle_name = middle;
	}

	int getAge()
	{
		return age;
	}

	string getName()
	{
		return first_name;
	}

	string getLastName()
	{
		return last_name;
	}

	string getMiddleName()
	{
		return middle_name;
	}

	void print()
	{
		cout << "Фамилия: " << getLastName() << endl;
		cout << "Имя: " << getName() << endl;
		cout << "Отчество: " << getMiddleName() << endl;
		cout << "Возраст: " << getAge() << endl;
	}
};

enum PhoneBrand
{
	Samsung, Alcatel, Huawei, Honor
};

class Phone
{
private:
	Person owner;
	PhoneBrand brand;
	string phonenum;
public:
	Phone()
	{
		brand = Alcatel;
		phonenum = "+78005553535";
	}

	Phone(PhoneBrand brand, string phonenum)
	{
		this->brand = brand;
		this->phonenum = phonenum;
	}

	void setOwner(Person newOwner)
	{
		if (owner.getAge() > newOwner.getAge())
		{
			cout << "Несоответствующий возраст" << endl;
			return;
		}
		owner = newOwner;
	}

	void print()
	{
		cout << "Марка телефона - ";
		switch (brand)
		{
		case(0):
			cout << "Samsung";
			break;
		case(1):
			cout << "Alcatel";
			break;
		case(2):
			cout << "Huawei";
			break;
		case(3):
			cout << "Honor";
			break;
		}
		cout << endl;
		cout << "Номер телефона: " << phonenum << endl;
		cout << "Информация о владельце телефона:" << endl;
		owner.print();
	}
};

int main()
{
	setlocale(LC_CTYPE, "Rus");
	Person p1("Александра", "Ложкина", "Сергеевна", 25);
	Person p2("Евгений", "Наговицын", "Васильевич", 21);

	p1.print();
	cout << endl;
	p2.print();
	cout << endl;

	Phone phone(Honor, "+79125348790");
	phone.setOwner(p2);
	phone.print();
	return 0;
}