package DP;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class Horse {
    static short borderSize = 2;

    public static long mod(long dividend, long divisor) {
	    return ((dividend % divisor) + divisor) % divisor;
    }

    public static void setBase(ArrayList<ArrayList<Long>> dp, short m, short n) {
        dp.get(borderSize).set(borderSize, 1L);
    }

    public static long getWaysCount(short m, short n, ArrayList<ArrayList<Long>> dp) {
        long divisor = 1000000123;
        short maxDiagonalNum = (short) ((m + n) - 1);

        for (short diagonalNum = 1; diagonalNum < m; diagonalNum++) {
            for (short i = borderSize, j = (short) (borderSize + diagonalNum); i < borderSize + n && j >= borderSize; i++, j--) {
                dp.get(i).set(j, dp.get(i - 2).get(j - 1) + dp.get(i - 2).get(j + 1) + dp.get(i - 1).get(j - 2) + dp.get(i + 1).get(j - 2));

                if(dp.get(i).get(j) >= divisor)
                    dp.get(i).set(j, mod(dp.get(i).get(j), divisor));
            }
        }

        for (short diagonalNum = m; diagonalNum < maxDiagonalNum; diagonalNum++) {
            for (short i = (short) (borderSize + (diagonalNum - (m - 1))), j = (short) (borderSize + (m-1)); i < borderSize + n && j >= borderSize; i++, j--) {
                dp.get(i).set(j, dp.get(i - 2).get(j - 1) + dp.get(i - 2).get(j + 1) + dp.get(i - 1).get(j - 2) + dp.get(i + 1).get(j - 2));

                if(dp.get(i).get(j) >= divisor)
                    dp.get(i).set(j, mod(dp.get(i).get(j), divisor));
            }
        }
        return dp.get(borderSize + (n - 1)).get(borderSize + (m - 1));
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        short n, m;
        n = scanner.nextShort();
        m = scanner.nextShort();

        ArrayList<ArrayList<Long>> dp = new ArrayList<>(n + 2);
        for (int i = 0; i < borderSize + n + borderSize; i++) {
            dp.add(new ArrayList<Long>(Collections.nCopies(borderSize + m + borderSize, 0L)));
        }

        setBase(dp, m, n);
        System.out.println(getWaysCount(m, n, dp));
    }
}
