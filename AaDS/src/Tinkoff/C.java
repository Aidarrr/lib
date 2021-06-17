package Tinkoff;

import java.util.Scanner;

public class C {
    public static int modifyBit(int n, int p, int b)
    {
        int mask = 1 << p;
        return ((n & ~mask) | (b << p));
    }

    public static int f(int x, int k, int t){
        for (int i = 0; i < k; i++) {
            x = modifyBit(x, i, t);
        }

        return x;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int l, r, x;
        l = scanner.nextInt();
        r = scanner.nextInt();
        x = scanner.nextInt();

        int k = 1;
        while(true){
            int newX1 = f(x, k, 0);
            int newX2 = f(x, k, 1);

            if(newX1 == x || newX2 == x){
                k++;
                continue;
            }

            if(newX1 >= l && newX1 <= r && newX2 >= l && newX2 <= r){
                k++;
            } else {
                break;
            }
        }

        System.out.print(k - 1 + " " + f(x, k - 1, 0) + " " + f(x, k - 1, 1));
    }
}
