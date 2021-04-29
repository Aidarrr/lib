package DP.Backpack;

import DP.FastIO;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

class Backpack5 {
    static FastIO fastIO;
    static int inf = -1;

    public static void fillWeightsArray(int[] weights, int[] costs) throws IOException {
        for (int i = 1; i < weights.length; i++) {
            weights[i] = fastIO.nextInt();
        }

        for (int i = 1; i < weights.length; i++) {
            costs[i] = fastIO.nextInt();
        }
    }

    public static void setBase(long[][] dp) {
        for (int i = 0; i < dp.length; i++) {
            Arrays.fill(dp[i], inf);
        }
        dp[0][0] = 0;
    }

    public static long calcMaxCost(long[][] dp, int[] weights, int[] costs, int n, int S) {
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= S; j++) {
                if (weights[i] <= j) {
                    dp[i][j] = Math.max(dp[i - 1][j], dp[i - 1][j - weights[i]] + costs[i]);
                } else {
                    dp[i][j] = dp[i - 1][j];
                }
            }
        }

        return  Arrays.stream(dp[n])
                .max()
                .getAsLong();
    }

    public static ArrayList<Integer> getPath(long[][] dp, int maxWeight, int n, int[] weights, int[] costs) {
        ArrayList<Integer> path = new ArrayList<>();
        int x = n, y = maxWeight;

        while (x > 0 && y >= 0) {
            if (weights[x] <= y) {
                if (dp[x - 1][y - weights[x]] != inf && dp[x - 1][y - weights[x]] + costs[x] == dp[x][y]) {
                    path.add(x);
                    int old_x = x;
                    x = x - 1;
                    y = y - weights[old_x];
                } else {
                    x = x - 1;
                }
            } else {
                x = x - 1;
            }
        }

        return path;
    }

    public static void printPath(ArrayList<Integer> path) {
        fastIO.out.print(" ");
        fastIO.out.println(path.size());
        for (int i = path.size() - 1; i >= 1; i--) {
            fastIO.out.print(path.get(i));
            fastIO.out.print(" ");
        }
        if(path.size() > 0)
            fastIO.out.print(path.get(0));
    }

    public static void main(String[] args) throws IOException {
        fastIO = new FastIO();
        int S = fastIO.nextInt(), n = fastIO.nextInt();

        int[] weights = new int[n + 1];
        int[] costs = new int[n + 1];
        fillWeightsArray(weights, costs);

        long[][] dp = new long[n + 1][S + 1];
        setBase(dp);
        long max = calcMaxCost(dp, weights, costs, n, S);
        fastIO.out.print(max);

        int maxW = 0;
        for (int i = 0; i <= S; i++) {
            if(dp[n][i] == max){
                maxW = i;
                break;
            }
        }

        var path = getPath(dp, maxW, n, weights, costs);
        printPath(path);

        fastIO.out.flush();
    }
}
