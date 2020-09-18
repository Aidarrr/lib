//#include <iostream>
//#include <fstream>
//#include <string>
//#include <sstream>      // std::istringstream
//#include <vector>
//#include <map>
//using namespace std;
//
//void get_lvl(uint64_t *n, int k, int num_bits, uint64_t *res)
//{
//	*res = (((1 << num_bits) - 1) & ((*n) >> k));
//	
//	//string bits;
//	//for (int i = 63; i >= 0; i--)
//	//{
//	//	bits += to_string(((*n) & (1 << i)) >> i);
//	//	//k--;
//	//}
//
//	//*res = stoull(bits, 0, 2);
//	///*istringstream iss(bits);
//	//iss >> *res;*/
//}
//
//bool valid_table_addr(uint64_t *addr, map<uint64_t, uint64_t> &addr_value, map<uint64_t, uint64_t>::iterator &it)
//{
//	for (it = addr_value.begin(); it != addr_value.end(); it++)
//	{
//		if (it->first == *addr)
//			return true;
//		else if (it->first > * addr)
//			return false;
//	}
//	return false;
//}
//
//bool get_phys_addr(uint64_t* n, uint64_t* res) //+check bit P
//{
//	//string bits;
//	int k = 12;
//	if ((*n & 1) == 0) return false;
//
//	*res = (((1 << 40) - 1) & ((*n) >> k));
//	*res = *res * 4096;
//	/*for (; k >= 12; k--)
//	{
//		bits += to_string((*n & (1 << k)) >> k);
//	}
//	bits += "000000000000";
//	*res = stoull(bits, 0, 2);*/
//	/*istringstream iss(bits);
//	iss >> *res;*/
//	return true;
//}
//
//bool move(uint64_t* addr, map<uint64_t, uint64_t>& addr_value)
//{
//	map<uint64_t, uint64_t>::iterator it = addr_value.begin();
//	if (valid_table_addr(addr, addr_value, it))
//	{
//		return (get_phys_addr(&(it->second), addr));
//	}
//	else
//		return false;
//}
//
//int main()
//{
//	ifstream data("dataset_44327_15.txt");
//	ofstream res_file("result.txt");
//	string word;
//	int m, q;
//	uint64_t root, t1, t2, log_addr, lvl1, lvl2, lvl3, lvl4, offset;
//	map<uint64_t, uint64_t> addr_value;
//	data >> m; data >> q; data >> word;
//
//	istringstream iss(word);
//	iss >> root;
//
//	for (size_t i = 0; i < m; i++)
//	{
//		data >> word;
//		istringstream iss2(word);
//		iss2 >> t1;
//		data >> word;
//		istringstream iss3(word);
//		iss3 >> t2;
//
//		addr_value.insert({ t1, t2 });
//	}
//
//	for (size_t i = 0; i < q; i++)
//	{
//		t1 = root;
//		data >> word;
//		istringstream iss2(word);
//		iss2 >> log_addr;
//
//		get_lvl(&log_addr, 39, 9, &lvl1);
//		t1 += lvl1 * 8;
//
//		if (move(&t1, addr_value))
//		{
//			get_lvl(&log_addr, 30, 9, &lvl2);
//			t1 += lvl2 * 8;
//			if (move(&t1, addr_value))
//			{
//				get_lvl(&log_addr, 21, 9, &lvl3);
//				t1 += lvl3 * 8;
//				if (move(&t1, addr_value))
//				{
//					get_lvl(&log_addr, 12, 9, &lvl4);
//					t1 += lvl4 * 8;
//					if (move(&t1, addr_value))
//					{
//						get_lvl(&log_addr, 0, 12, &offset);
//						t1 += offset;
//						res_file << t1 << endl;
//						
//					}
//					else
//					{
//						res_file << "fault\n";
//						continue;
//					}
//				}
//				else
//				{
//					res_file << "fault\n";
//					continue;
//				}
//			}
//			else
//			{
//				res_file << "fault\n";
//				continue;
//			}
//		}
//		else
//		{
//			res_file << "fault\n";
//			continue;
//		}
//	}
//
//	return 0;
//}