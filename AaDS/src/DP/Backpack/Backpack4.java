package DP.Backpack;

import DP.FastIO;

import java.io.IOException;
import java.util.Arrays;
import java.util.Comparator;

class Gold {
    public int weight;
    public int cost;
    public int unitCost;
}

public class Backpack4 {
    static FastIO fastIO;

    public static void sortGoldByCost(Gold[] golds) {
        Arrays.sort(golds, new Comparator<Gold>() {
            @Override
            public int compare(Gold o1, Gold o2) {
                return new Integer(o2.unitCost).compareTo(new Integer(o1.unitCost));
            }
        });
    }

    public static void fillGoldArr(Gold[] golds) throws IOException {
        golds[0] = new Gold();
        golds[0].weight = 0;
        golds[0].cost = 1000000;
        golds[0].unitCost = 1000000;

        for (int i = 1; i < golds.length; i++) {
            golds[i] = new Gold();
            golds[i].weight = fastIO.nextInt();
        }

        for (int i = 1; i < golds.length; i++) {
            golds[i].cost = fastIO.nextInt();
            golds[i].unitCost = golds[i].cost * golds[i].weight;
        }
    }

    public static long getMaxCost(Gold[] golds, int S, int n) {
        double cost = 0;
        int i = 1;

        for (; i <= n; i++) {
            if (S > golds[i].weight) {
                cost += golds[i].cost;
                S -= golds[i].weight;
            } else {
                cost += ((double) S / golds[i].weight) * golds[i].cost;
                break;
            }
        }

        if (i < n) {
            for (; i <= n; i++) {
                if (golds[i].weight == 0) {
                    cost += golds[i].cost;
                }
            }
        }

        return (long) Math.ceil(cost);
    }

    public static void main(String[] args) throws IOException {
        fastIO = new FastIO();
        int S = fastIO.nextInt(), n = fastIO.nextInt();

        Gold[] golds = new Gold[n + 1];
        fillGoldArr(golds);
        sortGoldByCost(golds);

        fastIO.out.print(getMaxCost(golds, S, n));

        fastIO.out.flush();
    }
}
