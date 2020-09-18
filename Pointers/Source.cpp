//#include <iostream>
//#include <vector>
//using namespace std;
//
//int main()
//{
//	//struct sSomeObject
//	//{
//	//	int x = 0xA3A2A1A0;
//	//	int y = 0xB3B2B1B0;
//
//	//	sSomeObject()
//	//	{
//	//		x = 0xC3C2C1C0;
//	//		y = 0xD3D2D1D0;
//	//	}
//	//};
//
//	////Stack Allocation
//	////sSomeObject pSomeObject[10];
//
//	////Heap
//	//sSomeObject** pSomeObject = new sSomeObject*[10];
//	//for (size_t i = 0; i < 10; i++)
//	//{
//	//	pSomeObject[i] = new sSomeObject();
//	//}
//	//
//	//for (size_t i = 0; i < 10; i++)
//	//{
//	//	delete[] pSomeObject[i];
//	//}
//	//delete[] pSomeObject;
//
//
//	struct sSomeBaseObject
//	{
//		virtual const char* IdentifyYourself()
//		{
//			return "Base Object";
//		}
//	};
//
//	struct sSomeSubObjectA : public sSomeBaseObject
//	{
//		const char* IdentifyYourself() override
//		{
//			return "Sub Object A";
//		}
//	};
//
//	struct sSomeSubObjectB : public sSomeBaseObject
//	{
//		const char* IdentifyYourself() override
//		{
//			return "Sub Object B";
//		}
//	};
//
//	/*vector<sSomeBaseObject*> pSomeArray;
//	pSomeArray.push_back(new sSomeBaseObject());
//	pSomeArray.push_back(new sSomeSubObjectA());
//	pSomeArray.push_back(new sSomeSubObjectB());
//	pSomeArray.push_back(new sSomeSubObjectA());
//	pSomeArray.push_back(new sSomeBaseObject());
//	
//	for (size_t i = 0; i < 5; i++)
//	{
//		cout << pSomeArray[i]->IdentifyYourself() << endl;
//	}
//	for (auto &a : pSomeArray)
//	{
//		delete a;
//	}
//	pSomeArray.clear();*/
//
//	{
//		shared_ptr<sSomeBaseObject> spSomeObject1 = make_shared<sSomeBaseObject>();
//		{
//			shared_ptr<sSomeBaseObject> spSomeObject2 = spSomeObject1;
//		}
//	}
//	cout << endl;
//	return 0;
//}