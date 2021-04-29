package DP;

import java.io.*;
import java.util.ArrayList;

class Point {
    public long val;
    public int x, y;

    public Point(long val, int x, int y) {
        this.val = val;
        this.x = x;
        this.y = y;
    }
}

class Pair {
    public int x;
    public int y;

    public Pair(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

class RookPath {
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

    public static void fillCostArray(long[][] cost) throws IOException {
        for (int i = 1; i < cost.length; i++) {
            for (int j = 1; j < cost[i].length; j++) {
                cost[i][j] = nextLong();
            }
        }
    }

    public static void setBase(long[][] dp, int[][] parentX, int[][] parentY, long[][] cost, Point[] minElementInRow, Point[] minElementInColumn, int n, int m) {
        dp[1][1] = cost[1][1];
        minElementInRow[1] = new Point(dp[1][1], 1, 1);
        minElementInColumn[1] = new Point(dp[1][1], 1, 1);

        for (int j = 2; j <= m; j++) {
            dp[1][j] = minElementInRow[1].val + cost[1][j];
            parentX[1][j] = minElementInRow[1].x;
            parentY[1][j] = 1;

            if (dp[1][j] < minElementInRow[1].val) {
                minElementInRow[1] = new Point(dp[1][j], j, 1);
            }
            minElementInColumn[j] = new Point(dp[1][j], j, 1);
        }

        for (int i = 2; i <= n; i++) {
            dp[i][1] = minElementInColumn[1].val + cost[i][1];
            parentY[i][1] = minElementInColumn[1].y;
            parentX[i][1] = 1;

            if (dp[i][1] < minElementInColumn[1].val) {
                minElementInColumn[1] = new Point(dp[i][1], 1, i);
            }
            minElementInRow[i] = new Point(dp[i][1], 1, i);
        }
    }

    public static long calcMinCost(long[][] dp, int[][] parentX, int[][] parentY, long[][] cost, Point[] minElementInRow, Point[] minElementInColumn, int n, int m) {
        for (int i = 2; i <= n; i++) {
            for (int j = 2; j <= m; j++) {
                long min = Math.min(minElementInRow[i].val, minElementInColumn[j].val);
                dp[i][j] = min + cost[i][j];

                if (minElementInRow[i].val + cost[i][j] == dp[i][j]) {
                    parentX[i][j] = minElementInRow[i].x;
                    parentY[i][j] = minElementInRow[i].y;
                } else {
                    parentX[i][j] = minElementInColumn[j].x;
                    parentY[i][j] = minElementInColumn[j].y;
                }

                if (dp[i][j] < minElementInRow[i].val) {
                    minElementInRow[i] = new Point(dp[i][j], j, i);
                }
                if (dp[i][j] < minElementInColumn[j].val) {
                    minElementInColumn[j] = new Point(dp[i][j], j, i);
                }
            }
        }

        return dp[n][m];
    }

    public static ArrayList<Pair> getPath(int[][] parentX, int[][] parentY, int n, int m) {
        ArrayList<Pair> path = new ArrayList<>();

        int x = m, y = n;

        while (x > 0 && y > 0) {
            path.add(new Pair(x, y));

            int tempX = x;
            x = parentX[y][x];
            y = parentY[y][tempX];
        }

        return path;
    }

    public static void printPath(ArrayList<Pair> path){
        out.print(" ");
        out.println(path.size());

        for (int i = path.size() - 1; i >= 0; i--) {
            out.print(path.get(i).y);
            out.print(" ");
            out.println(path.get(i).x);
        }
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int n, m;
        n = nextInt();
        m = nextInt();

        long[][] cost = new long[n + 1][m + 1];
        long[][] dp = new long[n + 1][m + 1];
        Point[] minElementInRow = new Point[n + 1];
        Point[] minElementInColumn = new Point[m + 1];
        int[][] parentX = new int[n + 1][m + 1];
        int[][] parentY = new int[n + 1][m + 1];

        fillCostArray(cost);
        setBase(dp, parentX, parentY, cost, minElementInRow, minElementInColumn, n, m);
        out.print(calcMinCost(dp, parentX, parentY, cost, minElementInRow, minElementInColumn, n, m));

        ArrayList<Pair> path = getPath(parentX, parentY, n, m);
        printPath(path);

        out.flush();
    }
}
