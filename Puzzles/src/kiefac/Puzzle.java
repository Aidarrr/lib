package kiefac;

import java.awt.*;
import java.util.ArrayList;

public class Puzzle {
    private ArrayList<ArrayList<Color>> puzzleData;
    private int width;
    private int height;

    public Puzzle(ArrayList<ArrayList<Color>> pictureData, int width, int height, int startX, int startY){
        this.width = width;
        this.height = height;
        puzzleData = new ArrayList<>();
        for (int x = startX; x < startX + width; x++) {
            ArrayList<Color> row = new ArrayList<>();
            for (int y = startY; y < startY + height; y++) {
                row.add(pictureData.get(x).get(y));
            }
            puzzleData.add(row);
        }
    }
}
