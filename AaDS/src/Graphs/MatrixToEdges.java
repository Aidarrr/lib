package Graphs;

import Graphs.FastIO;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

class Pair {
    int v1, v2;

    public Pair(int v1, int v2) {
        this.v1 = v1;
        this.v2 = v2;
    }
}

public class MatrixToEdges {
    static FastIO fastIO;
    static Scanner scanner;

    public static void printEdgesList(ArrayList<Pair> edgesList) {
        System.out.println(edgesList.size());
        for (var edge : edgesList) {
            System.out.print(edge.v1);
            System.out.print(" ");
            System.out.println(edge.v2);
        }
    }

    public static void fillAdjMatrix(boolean[][] adjMatrix) throws IOException {
        scanner.nextLine();
        for (int i = 1; i < adjMatrix.length; i++) {
            String line = scanner.nextLine();

            for (int k = 0; k < line.length(); k++) {
                if (line.charAt(k) == '0') {
                    adjMatrix[i][k + 1] = false;
                } else {
                    adjMatrix[i][k + 1] = true;
                }
            }
        }
    }

    public static void adjMatrixToEdges(int n, boolean[][] adjMatrix, ArrayList<Pair> edgesList) throws IOException {
        for (int i = 1; i < adjMatrix.length; i++) {
            for (int j = i + 1; j < adjMatrix[i].length; j++) {
                if (adjMatrix[i][j]) {
                    edgesList.add(new Pair(i, j));
                }
            }
        }
    }

    public static void main(String[] args) throws IOException {
        //scanner = new Scanner(System.in);
        fastIO = new FastIO();
        int n = fastIO.nextInt();
        boolean[][] adjMatrix = new boolean[n + 1][n + 1];
        ArrayList<Pair> edgesList = new ArrayList<>();

        fillAdjMatrix(adjMatrix);
        adjMatrixToEdges(n, adjMatrix, edgesList);
        printEdgesList(edgesList);
    }
}
