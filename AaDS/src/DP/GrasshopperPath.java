package DP;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;

public class GrasshopperPath {
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

    public static void fillCandyArray(long[] candy, int n) throws IOException {
        for (int i = 1; i <= n; i++) {
            candy[i] = nextLong();
        }
    }

    public static void setBase(long[] dp, long[] candy) {
        dp[0] = 0;
        dp[1] = candy[1];
        dp[2] = dp[1] + candy[2];
        dp[3] = Math.max(dp[2], dp[0]) + candy[3];
        dp[4] = Math.max(dp[3], dp[1]) + candy[4];
    }

    public static long getMaxCandyCount(long[] dp, long[] candy, int n) {
        for (int i = 5; i <= n; i++) {
            dp[i] = Math.max(Math.max(dp[i - 1], dp[i - 3]), dp[i - 5]) + candy[i];
        }

        return dp[n];
    }

    public static void getPathForMaxCandy(ArrayList<Integer> path, long[] dp, long[] candy, int n) {
        int x = n;

        while (x > 0) {
            path.add(x);

            if (dp[x - 1] + candy[x] == dp[x]) {
                x -= 1;
            } else if (x >= 3 && (dp[x - 3] + candy[x] == dp[x])) {
                x -= 3;
            } else if (x >= 5) {
                x -= 5;
            }
        }
    }

    public static void printPath(ArrayList<Integer> path) {
        out.print(" ");
        out.println(path.size());
        for (int i = path.size() - 1; i >= 1; i--) {
            out.print(path.get(i));
            out.print(" ");
        }
        out.print(path.get(0));
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int n;
        n = nextInt();

        long[] candy = new long[n + 4];
        fillCandyArray(candy, n);

        long[] dp = new long[n + 4];
        setBase(dp, candy);
        out.print(getMaxCandyCount(dp, candy, n));

        ArrayList<Integer> path = new ArrayList<>();
        getPathForMaxCandy(path, dp, candy, n);
        printPath(path);

        out.flush();
    }
}
