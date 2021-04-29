package DP.Backpack;

import java.io.*;
import java.util.ArrayList;

class BackpackLight {
    static StreamTokenizer in;
    static PrintWriter out;

    public static int nextInt() throws IOException {
        in.nextToken();
        return (int) in.nval;
    }

    public static void fillWeightsArray(int[] weights) throws IOException {
        for (int i = 1; i < weights.length; i++) {
            weights[i] = nextInt();
        }
    }

    public static void setBase(boolean[][] dp) {
        dp[0][0] = true;
    }

    public static int maxWeightFromLastLine(boolean[] line) {
        for (int i = line.length - 1; i >= 0; i--) {
            if (line[i]) {
                return i;
            }
        }
        return 0;
    }

    public static int calcMaxWeight(boolean[][] dp, int[] weights, int s, int n) {
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= s; j++) {
                if (weights[i] <= j) {
                    dp[i][j] = dp[i - 1][j] || dp[i - 1][j - weights[i]];
                } else {
                    dp[i][j] = dp[i - 1][j];
                }
            }
        }

        return maxWeightFromLastLine(dp[n]);
    }

    public static ArrayList<Integer> getPath(boolean[][] dp, int maxWeight, int n, int[] weights) {
        ArrayList<Integer> path = new ArrayList<>();
        int x = n, y = maxWeight;

        while (x > 0 && y > 0) {
            if (weights[x] <= y) {
                if (dp[x - 1][y - weights[x]]) {
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
        out.print(" ");
        out.println(path.size());
        for (int i = path.size() - 1; i >= 1; i--) {
            out.print(path.get(i));
            out.print(" ");
        }
        if(path.size() > 0)
            out.print(path.get(0));
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int s = nextInt(), n = nextInt();

        int[] weights = new int[n + 1];
        fillWeightsArray(weights);

        boolean[][] dp = new boolean[n + 1][s + 1];
        setBase(dp);
        var maxW = (calcMaxWeight(dp, weights, s, n));
        out.print(maxW);

        var path = getPath(dp, maxW, n, weights);
        printPath(path);

        out.flush();
    }
}
