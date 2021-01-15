package kiefac;

import java.util.ArrayList;

public class PuzzlesTable {
    private ArrayList<Puzzle> puzzles;
    private Picture mainPicture;

    public PuzzlesTable(Picture picture, int nWidth, int nHeight) {
        mainPicture = picture;
        puzzles = new ArrayList<>();
        int puzzleWidth = mainPicture.getWidth() / nWidth, puzzleHeight = mainPicture.getHeight() / nHeight;

        for (int x = 0; x < mainPicture.getWidth() - puzzleWidth; x += puzzleWidth) {
            for (int y = 0; y < mainPicture.getHeight() - puzzleHeight; y += puzzleHeight) {
                puzzles.add(new Puzzle(mainPicture.getPictureData(), puzzleWidth, puzzleHeight, x, y));
            }
        }
    }
}
