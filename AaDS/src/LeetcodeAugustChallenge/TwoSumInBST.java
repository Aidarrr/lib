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
//    TreeNode treeRoot;
//    int stupidCount = 0;
//    TreeNode firstNum;
//
//    public boolean findTarget(TreeNode root, int k) {
//        if(stupidCount == 0){
//            treeRoot = root;
//            stupidCount++;
//        }
//
//        firstNum = root;
//        int secondNum = k - firstNum.val;
//
//        if(binSearch(treeRoot, secondNum)){
//            return true;
//        } else if(root.left != null && findTarget(root.left, k)) {
//            return true;
//        }
//        else if(root.right != null && findTarget(root.right, k)) {
//            return true;
//        }
//
//        return false;
//    }
//
//    public boolean binSearch(TreeNode node, int searchedNum) {
//        if (node == null) {
//            return false;
//        }
//
//        if (node != firstNum && node.val == searchedNum) {
//            return true;
//        } else if (searchedNum < node.val) {
//            return binSearch(node.left, searchedNum);
//        } else {
//            return binSearch(node.right, searchedNum);
//        }
//    }
//}
//
//public class TwoSumInBST {
//}
