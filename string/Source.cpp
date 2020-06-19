#include <iostream>
using namespace std;

class String
{
public:
	String()
	{
		str = nullptr;
	}

	String(char *str)
	{
		int length = strlen(str);
		this->str = new char[length + 1];
		for (size_t i = 0; i < length; i++)
		{
			this->str[i] = str[i];
		}

		this->str[length] = '\0';
	}

	~String()
	{
		delete[] str;
	}

	String &operator =(const String &other)
	{
		if (this->str != nullptr)
		{
			delete[] str;
		}
		int length = strlen(other.str);
		this->str = new char[length + 1];
		for (size_t i = 0; i < length; i++)
		{
			this->str[i] = other.str[i];
		}

		this->str[length] = '\0';
		return *this;
	}

	String& operator+(const String& other)
	{
		String newStr;
		int thisLength = strlen(this->str);
		int otherLength = strlen(other.str);

		newStr.str = new
	}

	void Print()
	{
		cout << str;
	}

private:
	char* str;
};

int main()
{

	String s((char*)"Hello");
	String s2((char*)"World");

	String s3 = s + s2;

	return 0;
}