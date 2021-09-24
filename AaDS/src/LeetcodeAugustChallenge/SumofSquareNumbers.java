package LeetcodeAugustChallenge;

public class SumofSquareNumbers {
    public boolean judgeSquareSum(int c) {
        for (int a = 0; (a * a) <= (c / 2); a++) {
            int sqrA = a * a;
            int sqrB = c - sqrA;
            double b = Math.sqrt(sqrB);

            if(b == (int)b){
                return true;
            }
        }

        return false;
    }
}
