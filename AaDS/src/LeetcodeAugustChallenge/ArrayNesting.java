package LeetcodeAugustChallenge;

public class ArrayNesting {
    public int arrayNesting(int[] nums) {
        int maxLen = 0;

        for (int i = 0; i < nums.length; i++) {
            int cycleLength = 0, j = i;

            while (nums[j] >= 0) {
                int numsJ = nums[j];
                nums[j] = -1;
                j = numsJ;
                cycleLength++;
            }

            maxLen = Math.max(cycleLength, maxLen);
        }

        return maxLen;
    }

    public static void main(String[] args) {
        ArrayNesting arrayNesting = new ArrayNesting();
        System.out.println(arrayNesting.arrayNesting(new int[]{5,4,0,3,1,6,2}));
    }
}
