#include <iostream>
using namespace std;

//����� �� ����������� ������?

class Person
{
private:
	char *first_name = new char[20];
	char *last_name = new char[20];
	char *middle_name = new char[20];
	int age;
public:
	Person()
	{

	}

	Person(char *first, char *last, char* middle, int age)
	{
		first_name = first;
		last_name = last;
		middle_name = middle;
		/*if(correctAge(age))
			this->age = age;
		else
		{
			
		}*/
		this->age = age;
	}

	//Person(char* first, char* last, char* middle, int age) : first_name(first), last_name (last), middle_name(middle), age(age) {}

	//������ �� ��� ����� ������������� ������� ��� �������� ��� �������� � ������������?
	/*bool correctAge(int age)
	{
		if (age >= 0 && age <= 200)
			return true;
		return false;
	}*/

	void setAge(int age)
	{
		if (age >= 0 && age <= 200)
			this->age = age;
		else
			cout << "������� ������ �������\n";
	}

	void setName(char *first)
	{
		if (strlen(first) >= 0 && strlen(first) <= 20)
			first_name = first;
		else
			cout << "�������� ����� ������\n";
	}
	void setLast(char* last)
	{
		if (strlen(last) >= 0 && strlen(last) <= 20)
			last_name = last;
		else
			cout << "�������� ����� ������\n";
	}
	void setMiddle(char* middle)
	{
		if (strlen(middle) >= 0 && strlen(middle) <= 20)
			middle_name = middle;
		else
			cout << "�������� ����� ������\n";
	}

	void print()
	{
		cout << "���: ";
		for (size_t i = 0; i < strlen(last_name); i++)
			cout << last_name[i];
		for (size_t i = 0; i < strlen(first_name); i++)
			cout << first_name[i];
		for (size_t i = 0; i < strlen(middle_name); i++)
			cout << middle_name[i];
		cout << endl;
		cout << "�������: " << age << endl;
	}
};

enum PhoneBrand
{
	Samsung, Alcatel, Huawei, Honor, Nokia, Meizu
};

class Phone
{
private:
	Person owner;
	PhoneBrand brand;
	char* phonenum = new char[12];
public:
	Phone(){}

	Phone(PhoneBrand brand, char* phonenum)
	{
		this->brand = brand;
		this->phonenum = phonenum;
	}

	//TODO: method set owner

	void print()
	{
		cout << "����� �������� - " << brand << endl;
		cout << "����� �������� - ";
		for (int i = 0; i < 12; i++)
			cout << phonenum[i];
		cout << endl;
		//todo: cout owner's l,f,m names
	}
};

int main()
{
	return 0;
}