package DP;

import java.io.*;
import java.util.ArrayList;

class CalcPath {
    static StreamTokenizer in;
    static PrintWriter out;

    public static int nextInt() throws IOException {
        in.nextToken();
        return (int) in.nval;
    }

    public static long nextLong() throws IOException {
        in.nextToken();
        return (long) in.nval;
    }

    public static int getMinOperationsCount(int n, int[] dp) {
        dp[1] = 0;

        for (int i = 2; i <= n; i++) {
            int subtrCount, x2Count = Integer.MAX_VALUE, x3Count = Integer.MAX_VALUE;

            subtrCount = dp[i - 1];
            if (i % 2 == 0)
                x2Count = dp[i / 2];
            if (i % 3 == 0)
                x3Count = dp[i / 3];

            dp[i] = Math.min(Math.min(subtrCount, x2Count), x3Count) + 1;
        }
        return dp[n];
    }

    public static void getPathForMinOperationsCount(ArrayList<Integer> path, int[] dp, int n) {
        int x = n;

        while (x > 0) {
            path.add(x);

            if (x % 2 == 0 && (dp[x / 2] + 1 == dp[x])) {
                x = x / 2;
            } else if (x % 3 == 0 && (dp[x / 3] + 1 == dp[x])) {
                x = x / 3;
            } else {
                x = x - 1;
            }
        }
    }

    public static void printPath(ArrayList<Integer> path) {
        for (int i = path.size() - 1; i >= 1; i--) {
            out.print(path.get(i));
            out.print(" ");
        }
        out.print(path.get(0));
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int n = nextInt();
        int[] dp = new int[n + 1];

        out.println(getMinOperationsCount(n, dp));

        ArrayList<Integer> path = new ArrayList<>();
        getPathForMinOperationsCount(path, dp, n);
        printPath(path);

        out.flush();
    }
}
