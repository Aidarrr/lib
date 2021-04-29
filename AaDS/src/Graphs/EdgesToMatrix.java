package Graphs;

import Graphs.FastIO;

import java.io.IOException;

public class EdgesToMatrix {
    static FastIO fastIO;

    public static void printAdjMatrix(boolean[][] adjMatrix){
        for (int i = 1; i < adjMatrix.length; i++) {
            for (int j = 1; j < adjMatrix[i].length; j++) {
                fastIO.out.print(adjMatrix[i][j] ? 1 : 0);
            }
            fastIO.out.println();
        }
    }

    public static void edgesToAdjMatrix(int m, boolean[][] adjMatrix) throws IOException {
        for (int i = 1; i <= m; i++) {
            int firstNode = fastIO.nextInt();
            int secondNode = fastIO.nextInt();

            adjMatrix[firstNode][secondNode] = true;
            adjMatrix[secondNode][firstNode] = true;
        }
    }

    public static void main(String[] args) throws IOException {
        fastIO = new FastIO();
        int n = fastIO.nextInt(), m = fastIO.nextInt();
        boolean[][] adjMatrix = new boolean[n + 1][n + 1];

        edgesToAdjMatrix(m, adjMatrix);
        printAdjMatrix(adjMatrix);
        fastIO.out.flush();
    }
}
