package LeetcodeAugustChallenge;

public class MiddleIndex {
    public int getSumOfArray(int[] nums){
        int sum = 0;

        for(var num : nums){
            sum += num;
        }

        return sum;
    }

    public int findMiddleIndex(int[] nums) {
        int leftSum = 0;
        int rightSum = getSumOfArray(nums);

        rightSum -= nums[0];
        if(leftSum == rightSum){
            return 0;
        }

        for (int middleIndex = 1; middleIndex < nums.length; middleIndex++) {
            leftSum += nums[middleIndex - 1];
            rightSum -= nums[middleIndex];

            if(leftSum == rightSum){
                return middleIndex;
            }
        }

        return -1;
    }

    public static void main(String[] args) {
        MiddleIndex m = new MiddleIndex();

        m.findMiddleIndex(new int[]{2,3,-1,8,4});
    }
}
