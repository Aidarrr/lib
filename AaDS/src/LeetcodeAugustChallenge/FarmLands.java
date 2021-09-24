package LeetcodeAugustChallenge;

import java.util.ArrayList;
import java.util.List;

public class FarmLands {
    public boolean isGroup(int[][] land, int r2, int c2, int size){
        for (int i = c2 - size; i <= c2; i++) {
            for (int j = r2 - size; j <= r2; j++) {
                if(land[i][j] == 0){
                    return false;
                }
            }
        }

        return true;
    }

    public void clearGroup(int[][] land, int r2, int c2, int r1, int c1){
        for (int i = c1; i <= c2; i++) {
            for (int j = r1; j <= r2; j++) {
                land[i][j] = 0;
            }
        }
    }

    public int[][] findFarmland(int[][] land) {
        List<List<Integer>> farmLandGroups = new ArrayList<>();
        int minLandSide = Math.min(land.length, land[0].length);

        for (int i = 0; i < land.length; i++) {
            for (int j = 0; j < land[i].length; j++) {
                if(land[i][j] == 1){
                    int r1 = j, c1 = i, r2 = j, c2 = i;

                    for (int k = c2; k < land.length; k++) {
                        for (int l = r2; l < land[k].length; l++) {
                            if(land[k][l] == 0){
                                break;
                            } else {
                                
                            }
                        }
                    }

                    clearGroup(land, r2, c2, r1, c1);
                    List<Integer> group = new ArrayList<>();
                    group.add(r1);
                    group.add(c1);
                    group.add(r2);
                    group.add(c2);

                    farmLandGroups.add(group);
                }
            }
        }

        if(farmLandGroups.size() == 0){
            return new int[0][];
        }

        int[][] f = new int[farmLandGroups.size()][farmLandGroups.get(0).size()];
        for (int i = 0; i < f.length; i++) {
            for (int j = 0; j < f[i].length; j++) {
                f[i][j] = farmLandGroups.get(i).get(j);
            }
        }

        return f;
    }
}
