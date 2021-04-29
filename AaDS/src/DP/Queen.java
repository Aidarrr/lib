package DP;

import java.util.Scanner;

class Queen {
    static long div = 1000000000 + 7;

    public static long mod(long dividend, long divisor) {
        return ((dividend % divisor) + divisor) % divisor;
    }

    public static void setBase(long[][] dp, long[][] partSumRows, long[][] partSumColumns, int n, int m) {
        dp[1][1] = 1;

        for (int j = 2; j <= m; j++) {
            partSumRows[1][j] = partSumRows[1][j - 1] + dp[1][j - 1];
            if (partSumRows[1][j] >= div) {
                partSumRows[1][j] = mod(partSumRows[1][j], div);
            }

            dp[1][j] = partSumRows[1][j];
        }

        for (int i = 2; i <= n; i++) {
            partSumColumns[i][1] = partSumColumns[i - 1][1] + dp[i - 1][1];
            if (partSumColumns[i][1] >= div) {
                partSumColumns[i][1] = mod(partSumColumns[i][1], div);
            }

            dp[i][1] = partSumColumns[i][1];
        }
    }

    public static long getWaysCount(long[][] dp, long[][] partSumRows, long[][] partSumColumns, long[][] partSumDiagonals, int n, int m) {
        for (int i = 2; i <= n; i++) {
            for (int j = 2; j <= m; j++) {
                partSumRows[i][j] = partSumRows[i][j - 1] + dp[i][j - 1];
                partSumColumns[i][j] = partSumColumns[i - 1][j] + dp[i - 1][j];
                partSumDiagonals[i][j] = partSumDiagonals[i - 1][j - 1] + dp[i - 1][j - 1];

                if (partSumRows[i][j] >= div) {
                    partSumRows[i][j] = mod(partSumRows[i][j], div);
                }
                if (partSumColumns[i][j] >= div) {
                    partSumColumns[i][j] = mod(partSumColumns[i][j], div);
                }
                if (partSumDiagonals[i][j] >= div) {
                    partSumDiagonals[i][j] = mod(partSumDiagonals[i][j], div);
                }

                dp[i][j] = partSumRows[i][j] + partSumColumns[i][j] + partSumDiagonals[i][j];
                if (dp[i][j] >= div) {
                    dp[i][j] = mod(dp[i][j], div);
                }
            }
        }

        return dp[n][m];
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n, m;
        n = scanner.nextInt();
        m = scanner.nextInt();

        long[][] dp = new long[n + 1][m + 1];
        long[][] partSumRows = new long[n + 1][m + 1];
        long[][] partSumColumns = new long[n + 1][m + 1];
        long[][] partSumDiagonals = new long[n + 1][m + 1];

        setBase(dp, partSumRows, partSumColumns, n, m);

        System.out.println(getWaysCount(dp, partSumRows, partSumColumns, partSumDiagonals, n, m));
    }
}
