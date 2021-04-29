package DP;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

class Coords {
    public int x, y;

    public Coords(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

class TurtleAndPath {
    static long inf = Long.MAX_VALUE;
    static StreamTokenizer in;
    static PrintWriter out;

    public static int nextInt() throws IOException
    {
        in.nextToken();
        return (int)in.nval;
    }

    public static long calcMinCost(int[][] costTable, long[][] dp, int n, int m) {
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                dp[i][j] = Math.min(Math.min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + costTable[i][j];
            }
        }

        return dp[n][m];
    }

    public static void getPathToMinCost(int[][] costTable, long[][] dp, ArrayList<Coords> path, int n, int m) {
        int x = n, y = m;

        while (x > 0 && y > 0) {
            path.add(new Coords(x, y));

            if (dp[x - 1][y] + costTable[x][y] == dp[x][y]) {
                x -= 1;
            } else if (dp[x][y - 1] + costTable[x][y] == dp[x][y]) {
                y -= 1;
            } else {
                x -= 1;
                y -= 1;
            }
        }
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int n, m;
        n = nextInt();
        m = nextInt();

        int[][] costTable = new int[n + 1][m + 1];
        long[][] dp = new long[n + 1][m + 1];
        ArrayList<Coords> path = new ArrayList<>();

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                costTable[i][j] = nextInt();
            }
        }


        for (int i = 0; i <= n; i++) {
            Arrays.fill(dp[i], inf);
        }
        dp[0][0] = 0;

        out.print(calcMinCost(costTable, dp, n, m));

        getPathToMinCost(costTable, dp, path, n, m);

        out.print(" ");
        out.println(path.size());

        for (int i = path.size() - 1; i >= 0; i--) {
            out.print(path.get(i).x);
            out.print(" ");
            out.println(path.get(i).y);
        }
        out.flush();
    }
}
