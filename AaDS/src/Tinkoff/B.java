package Tinkoff;

import java.util.Scanner;

public class B {
    public static int getSimilarSymbols(String s, String t){
        int count = 0;
        for (int i = 0; i < s.length(); i++) {
            if(s.charAt(i) == t.charAt(i)){
                count++;
            }
        }

        return count;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String s = scanner.nextLine();
        String t = scanner.nextLine();

        int similarSymbols = getSimilarSymbols(s, t);

        if(similarSymbols == s.length()){
            System.out.println(similarSymbols);
        } else {
            System.out.println(similarSymbols + 1);
        }
    }
}
