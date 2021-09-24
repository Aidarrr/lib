package LeetcodeAugustChallenge;

public class MinInRotatedArray {
    public int findMin(int[] nums) {
        int start = 0;
        int end = nums.length - 1;

        while(start < end){
            int mid = (start + end) / 2;

            if(mid != 0 && nums[mid - 1] > nums[mid]){
                return nums[mid];
            }

            if(nums[mid] > nums[end]){
                start = mid + 1;
            } else if(nums[mid] < nums[end]){
                end = mid - 1;
            }
        }

        return nums[start];
    }
}
