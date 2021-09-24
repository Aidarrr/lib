package LeetcodeAugustChallenge;

public class longestUncommonSubsequence {
    public boolean isSubstring(String a, String b) {
        if (a.length() > b.length()) {
            return false;
        }
        int firstString = 0, secondString = 0;

        while (firstString < a.length() && secondString < b.length()) {
            if (a.charAt(firstString) == b.charAt(secondString)) {
                firstString++;
            }
            secondString++;
        }

        return firstString == a.length();
    }

    public int findLUSlength(String[] strs) {
        int longestSize = -1;

        for (int firstString = 0; firstString < strs.length; firstString++) {
            boolean isFirstSubstring = false;
            int firstLength = strs[firstString].length();

            for (int secondString = 0; secondString < strs.length; secondString++) {
                if(firstString != secondString && isSubstring(strs[firstString], strs[secondString])){
                    isFirstSubstring = true;
                    break;
                }
            }

            if(!isFirstSubstring){
                longestSize = Math.max(longestSize, firstLength);
            }
        }

        return longestSize;
    }
}
