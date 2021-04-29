package Graphs;

import Graphs.FastIO;

import java.io.IOException;

public class AdjListToMatrix {
    static FastIO fastIO;

    public static void printAdjMatrix(boolean[][] adjMatrix){
        for (int i = 1; i < adjMatrix.length; i++) {
            for (int j = 1; j < adjMatrix[i].length; j++) {
                fastIO.out.print(adjMatrix[i][j] ? 1 : 0);
            }
            fastIO.out.println();
        }
    }

    public static void adjListToMatrix(int n, boolean[][] adjMatrix) throws IOException {
        for (int from = 1; from <= n; from++) {
            int degree = fastIO.nextInt();

            for (int i = 1; i <= degree; i++) {
                int to = fastIO.nextInt();

                adjMatrix[from][to] = true;
            }
        }
    }

    public static void main(String[] args) throws IOException {
        fastIO = new FastIO();
        int n = fastIO.nextInt();
        boolean[][] adjMatrix = new boolean[n + 1][n + 1];

        adjListToMatrix(n, adjMatrix);
        printAdjMatrix(adjMatrix);
        fastIO.out.flush();
    }
}
