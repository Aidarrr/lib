package DP.Backpack;

import java.io.*;

public class BackPackVeryLight {
    static StreamTokenizer in;
    static PrintWriter out;

    public static int nextInt() throws IOException {
        in.nextToken();
        return (int) in.nval;
    }

    public static void main(String[] args) throws IOException {
        in = new StreamTokenizer(new BufferedReader(new InputStreamReader(System.in)));
        out = new PrintWriter(System.out);
        int s, n;

        s = nextInt();
        n = nextInt();
        int sumWeight = 0;

        for (int i = 0; i < n; i++) {
            sumWeight += nextInt();
        }

        if(sumWeight >= s){
            out.print(s);
        } else{
            out.print(sumWeight);
        }

        out.flush();
    }
}
