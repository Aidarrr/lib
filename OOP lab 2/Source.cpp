//#include <iostream>
//using namespace std;
//
//class Weapon		//Абстрактный класс
//{
//public:
//	virtual void Shoot() = 0;
//};
//
//class Gun : public Weapon
//{
//public:
//	void Shoot() override
//	{
//		cout << "BANG!\n";
//	}
//};
//
//class SubmachineGun : public Gun
//{
//public:
//	void Shoot() override
//	{
//		cout << "BANG! BANG! BANG!\n";
//	}
//};
//
//class Bazooka : public Weapon
//{
//public:
//	void Shoot() override
//	{
//		cout << "BADABUM!!!\n";
//	}
//};
//
//class Knife : public Weapon
//{
//public:
//	void Shoot() override 
//	{
//		cout << "VJUH\n";
//	}
//};
//
//class Player
//{
//public:
//	void Shoot(Weapon* weapon)
//	{
//		weapon->Shoot();
//	}
//};
//
//int main()
//{
//	Knife gun;
//	Player player;
//	player.Shoot(&gun);
//	return 0;
//}