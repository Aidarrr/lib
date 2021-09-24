//package LeetcodeAugustChallenge;
//
//class TreeNode {
//    int val;
//    TreeNode left;
//    TreeNode right;
//
//    TreeNode() {
//    }
//
//    TreeNode(int val) {
//        this.val = val;
//    }
//
//    TreeNode(int val, TreeNode left, TreeNode right) {
//        this.val = val;
//        this.left = left;
//        this.right = right;
//    }
//}
//
//class Solution {
//    long totalTreeSum = 0, maxProduct = 0;
//
//    public int maxProduct(TreeNode root) {
//        totalTreeSum = sumOfSubTree(root);
//        sumOfSubTree(root);
//        return (int) (maxProduct % (1000000000 + 7));
//    }
//
//    public long sumOfSubTree(TreeNode root) {
//        if (root == null) {
//            return 0;
//        }
//
//        long subTreeSum = root.val + sumOfSubTree(root.left) + sumOfSubTree(root.right);
//        long product = subTreeSum * (totalTreeSum - subTreeSum);
//
//        if (product > maxProduct) {
//            maxProduct = product;
//        }
//
//        return subTreeSum;
//    }
//}
//
//public class MaximumProductofSplittedBinaryTree {
//}
