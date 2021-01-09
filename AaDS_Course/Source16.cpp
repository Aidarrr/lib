//#include <iostream>
//using std::cin;
//using std::cout;
//using std::endl;
//
//void copy(int* source, int* destination, unsigned int n) {
//    for (size_t i = 0; i < n; i++) {
//        destination[i] = source[i];
//    }
//}
//
//int* my_slightly_dumb_reallocation(int* source, unsigned int n_old, unsigned int n_new) {
//    if (source != nullptr) {
//        int* dest;
//        n_new == 0 ? dest = nullptr : dest = new int[n_new];
//        n_new > n_old ? copy(source, dest, n_old) : copy(source, dest, n_new);
//        delete[] source;
//
//        return dest;
//    }
//    if (n_new == 0)
//        return nullptr;
//    return new int[n_new];
//}
//
//int* now_get_me_some_bytes(unsigned int n) {
//    return new int[n];
//}
//
//void now_free_some_bytes(int* p) {
//    delete[] p;
//}
//
//void my_personal_swap(int* a, int* b) {
//    if (a != nullptr && b != nullptr) {
//        int tmp = *a;
//        *a = *b;
//        *b = tmp;
//    }
//}
//
//int do_some_awesome_work(int* a, int* b) {
//    return *a + *b;
//}
//
//int main() {
//    unsigned int n, i;
//    cin >> n;
//    int* a = my_slightly_dumb_reallocation(NULL, 0, n / 2);
//    for (i = 0; i < n / 2; i++)
//        cin >> a[i];
//    a = my_slightly_dumb_reallocation(a, n / 2, n);
//    for (; i < n; i++)
//        cin >> a[i];
//    int sum = 0;
//    for (i = 0; i < n; i++)
//        sum += a[i];
//    cout << sum << endl;
//    a = my_slightly_dumb_reallocation(a, n, n / 2);
//    a = my_slightly_dumb_reallocation(a, n / 2, 0);
//    
//    a = my_slightly_dumb_reallocation(a, 0, 0);
//    return 0;
//}