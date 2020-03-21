#include <iostream>
#include <string>
using namespace std;

template<typename T>
class Stack
{
public:
	Stack()
	{
		Size = 0;
		head = nullptr;
	}
	~Stack()
	{
		clear();
	}

	void pop();
	int GetSize() { return Size; }
	void clear();
	void push(T data);
	bool empty();
	T top();
private:
	template<typename T>
	class Node
	{
	public:
		Node* pNext;
		T data;
		Node(T data = T(), Node* pNext = nullptr)
		{
			this->data = data;
			this->pNext = pNext;
		}
	};

	int Size;
	Node<T>* head;
};

template<typename T>
void Stack<T>::pop()
{
	if (empty())
		throw exception("Ошибка: удаление элемента из пустого стека");
	Node<T>* temp = head;
	head = head->pNext;
	delete temp;
	Size--;
}

template<typename T>
void Stack<T>::clear()
{
	while (Size)
		pop();
}

template<typename T>
void Stack<T>::push(T data)
{
	head = new Node<T>(data, head);
	Size++;
}

template<typename T>
bool Stack<T>::empty()
{
	if(head == nullptr)
		return true;
	return false;
}

template<typename T>
T Stack<T>::top()
{
	if(empty())
		throw exception("Ошибка: взятие элемента из пустого стека");
	return head->data;
}

int main()
{
	setlocale(LC_ALL, "ru");
	Stack <int> s;
	int n, el;
	cout << "Кол-во элементов в стеке: ";
	cin >> n;
	cout << "Элементы стека: ";
	for (int i = 0; i < n; i++)
	{
		cin >> el;
		s.push(el);
	}

	cout << "Вывод элементов: ";
	while (!s.empty())
	{
		cout << s.top() << ' ';
		s.pop();
	}
	cout << endl << endl;
	try
	{
		s.pop();
	}
	catch (const std::exception& ex)
	{
		cout << ex.what() << endl;
	}
	
	try
	{
		s.top();
	}
	catch (const std::exception & ex)
	{
		cout << ex.what() << endl;
	}

	
	return 0;
}