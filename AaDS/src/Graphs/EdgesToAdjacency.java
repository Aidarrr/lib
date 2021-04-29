package Graphs;

import Graphs.FastIO;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

class Node{
    public ArrayList<Integer> neighboors;

    public Node() {
        this.neighboors = new ArrayList<>();
    }
}

class EdgesToAdjacency {
    static FastIO fastIO;

    public static void printAdjList(Node[] graph){
        for (int i = 1; i < graph.length; i++) {
            fastIO.out.print(graph[i].neighboors.size());
            fastIO.out.print(" ");

            for (int j = 0; j < graph[i].neighboors.size(); j++) {
                fastIO.out.print(graph[i].neighboors.get(j));
                fastIO.out.print(" ");
            }
            fastIO.out.println();
        }

    }

    public static void main(String[] args) throws IOException {
        fastIO = new FastIO();
        int n,m;
        n = fastIO.nextInt(); m = fastIO.nextInt();
        Node[] graph = new Node[n + 1];

        for (int i = 1; i <= n; i++) {
            graph[i] = new Node();
        }

        for (int i = 1; i <= m; i++) {
            int firstNode = fastIO.nextInt();
            int secondNode = fastIO.nextInt();

            graph[firstNode].neighboors.add(secondNode);
            graph[secondNode].neighboors.add(firstNode);
        }

        for (int i = 1; i <= n; i++) {
            Collections.sort(graph[i].neighboors);
        }

        printAdjList(graph);

        fastIO.out.flush();
    }
}
