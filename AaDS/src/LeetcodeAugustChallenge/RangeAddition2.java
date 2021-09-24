package LeetcodeAugustChallenge;

public class RangeAddition2 {
    public int maxCount(int m, int n, int[][] ops) {
        int xMin = m, yMin = n;

        for(var op : ops){
            xMin = Math.min(xMin, op[0]);
            yMin = Math.min(yMin, op[1]);
        }

        return xMin * yMin;
    }
}
