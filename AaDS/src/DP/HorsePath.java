package DP;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

class PairInt {
    public int x;
    public int y;

    public PairInt(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

class HorsePath {
    static int borderSize = 2;
    static StreamTokenizer in;
    static PrintWriter out;
    static long inf = 1000000000000000L + 3L;

    public static int nextInt() throws IOException {
        in.nextToken();
        return (int) in.nval;
    }

    public static long nextLong() throws IOException {
        in.nextToken();
        return (long) in.nval;
    }

    public static void fillCostArray(long[][] cost, int n, int m) throws IOException {
        for (int i = borderSize; i < borderSize + n; i++) {
            for (int j = borderSize; j < borderSize + m; j++) {
                cost[i][j] = nextLong();
            }
        }
    }

    public static void setBase(long[][] dp, long[][] cost) {
        for (int i = 0; i < dp.length; i++) {
            Arrays.fill(dp[i], inf);
        }

        dp[borderSize][borderSize] = cost[borderSize][borderSize];
    }

    public static long calcMinCost(int n, int m, long[][] dp, long[][] cost, int[][] parentX, int[][] parentY) {
        int maxDiagonalNum = ((m + n) - 1);

        for (int diagonalNum = 1; diagonalNum < m; diagonalNum++) {
            for (int i = borderSize, j = (borderSize + diagonalNum); i < borderSize + n && j >= borderSize; i++, j--) {
                long min = Math.min(Math.min(Math.min(dp[i - 2][j - 1], dp[i - 2][j + 1]), dp[i - 1][j - 2]), dp[i + 1][j - 2]);
                dp[i][j] = min + cost[i][j];

                if (dp[i - 2][j - 1] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 2;
                    parentY[i][j] = j - 1;
                } else if (dp[i - 2][j + 1] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 2;
                    parentY[i][j] = j + 1;
                } else if (dp[i - 1][j - 2] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 1;
                    parentY[i][j] = j - 2;
                } else {
                    parentX[i][j] = i + 1;
                    parentY[i][j] = j - 2;
                }
            }
        }

        for (int diagonalNum = m; diagonalNum < maxDiagonalNum; diagonalNum++) {
            for (int i = (borderSize + (diagonalNum - (m - 1))), j = (borderSize + (m - 1)); i < borderSize + n && j >= borderSize; i++, j--) {
                long min = Math.min(Math.min(Math.min(dp[i - 2][j - 1], dp[i - 2][j + 1]), dp[i - 1][j - 2]), dp[i + 1][j - 2]);
                dp[i][j] = min + cost[i][j];

                if (dp[i - 2][j - 1] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 2;
                    parentY[i][j] = j - 1;
                } else if (dp[i - 2][j + 1] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 2;
                    parentY[i][j] = j + 1;
                } else if (dp[i - 1][j - 2] + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = i - 1;
                    parentY[i][j] = j - 2;
                } else {
                    parentX[i][j] = i + 1;
                    parentY[i][j] = j - 2;
                }
            }
        }

        return dp[borderSize + (n - 1)][borderSize + (m - 1)];
    }

    public static ArrayList<PairInt> getPath(int[][] parentX, int[][] parentY, int n, int m) {
        ArrayList<PairInt> path = new ArrayList<>();

        int x = (n - 1) + borderSize, y = (m - 1) + borderSize;

        while (x > 0 && y > 0) {
            path.add(new PairInt(x - borderSize + 1, y - borderSize + 1));

            int tempX = x;
            x = parentX[x][y];
            y = parentY[tempX][y];
        }

        return path;
    }

    public static void printPath(ArrayList<PairInt> path) {
        out.print(" ");
        out.println(path.size());

        for (int i = path.size() - 1; i >= 0; i--) {
            out.print(path.get(i).x);
            out.print(" ");
            out.println(path.get(i).y);
        }
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int n = nextInt(), m = nextInt();

        long[][] dp = new long[borderSize + n + borderSize][borderSize + m + borderSize];
        long[][] cost = new long[borderSize + n + borderSize][borderSize + m + borderSize];
        fillCostArray(cost, n, m);
        setBase(dp, cost);
        int[][] parentX = new int[borderSize + n + borderSize][borderSize + m + borderSize];
        int[][] parentY = new int[borderSize + n + borderSize][borderSize + m + borderSize];

        long minCost = calcMinCost(n, m, dp, cost, parentX, parentY);
        ArrayList<PairInt> path = getPath(parentX, parentY, n, m);

        if (path.get(path.size() - 1).x == 1 && path.get(path.size() - 1).y == 1) {

            out.println("YES");
            out.print(minCost);
            printPath(path);
        } else {
            out.print("NO");
        }

        out.flush();
    }
}
