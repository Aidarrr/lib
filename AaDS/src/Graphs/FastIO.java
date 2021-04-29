package Graphs;

import java.io.*;

public class FastIO {
    public StreamTokenizer in;
    public PrintWriter out;

    public FastIO() {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
    }

    public int nextInt() throws IOException {
        in.nextToken();
        return (int) in.nval;
    }

    public String nextLine() throws IOException {
        in.nextToken();
        return in.sval;
    }

    public long nextLong() throws IOException {
        in.nextToken();
        return (long) in.nval;
    }
}
