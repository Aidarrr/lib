package Tinkoff;

import java.util.Scanner;

public class A {
    static int stickersOnSide = 9;
    static int colorsCount = 6;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int m = scanner.nextInt();
        int replacementCount = ((m * n) / stickersOnSide) ;
        int stickersLeft = colorsCount * ((m * n) % stickersOnSide) ;

        System.out.println(replacementCount);
        System.out.println(stickersLeft);
    }
}
