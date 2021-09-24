package LeetcodeAugustChallenge;

class Point {
    int x, y;

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

class Solution {
    int startIndexX = 0, startIndexY = 1, endIndexX = 2, endIndexY = 3;

    public int rectangleArea(int[][] rectangles) {
        long area = 0;
        Point maxCoordinates = getMaxCoordinates(rectangles);

        for (int y = 0; y < maxCoordinates.y; y++) {
            for (int x = 0; x < maxCoordinates.x; x++) {
                if(isCellCoveredByRectangle(rectangles, new Point(x, y))){
                    area++;
                }
            }
        }

        return (int)(area % (1000000000 + 7));
    }

    public boolean isCellCoveredByRectangle(int[][] rectangles, Point checkedPoint) {
        for (int i = 0; i < rectangles.length; i++) {
            int[] rectangle = rectangles[i];

            Point start = new Point(rectangle[startIndexX], rectangle[startIndexY]);
            Point end = new Point(rectangle[endIndexX], rectangle[endIndexY]);

            if (checkedPoint.x >= start.x && checkedPoint.y >= start.y && checkedPoint.x < end.x && checkedPoint.y < end.y) {
                return true;
            }
        }

        return false;
    }

    public Point getMaxCoordinates(int[][] rectangles) {
        int maxX = 0, maxY = 0;

        for (int i = 0; i < rectangles.length; i++) {
            if (rectangles[i][startIndexX] > maxX) {
                maxX = rectangles[i][startIndexX];
            } if (rectangles[i][endIndexX] > maxX) {
                maxX = rectangles[i][endIndexX];
            }

            if (rectangles[i][startIndexY] > maxY) {
                maxY = rectangles[i][startIndexY];
            } if (rectangles[i][endIndexY] > maxY) {
                maxY = rectangles[i][endIndexY];
            }
        }

        return new Point(maxX, maxY);
    }
}

public class RectangleArea {
    public static void main(String[] args) {
        Solution solution = new Solution();
        System.out.println(solution.rectangleArea(new int[][]{{0,0,2,2}, {1,0,2,3}, {1,0,3,1}}));
    }
}
