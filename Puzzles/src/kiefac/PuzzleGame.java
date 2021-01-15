package kiefac;

import java.awt.*;
import java.awt.event.KeyEvent;
import java.io.File;
import java.lang.reflect.Array;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.ArrayList;

import javax.swing.*;

enum State{MAIN, GAME}

public class PuzzleGame extends Barista {
    private Picture mainPicture;
    private Picture fileSelectionPicture;
    private Picture startGamePicture;
    private FileService fileService;
    private int pictureLocationOffsetX;
    private int pictureLocationOffsetY;
    private int fileSelectionPictureOffsetX;
    private int fileSelectionPictureOffsetY;
    private int startButtonOffsetX;
    private int startButtonOffsetY;
    State state;

    private boolean isMouseOnButton(int minX, int maxX, int minY, int maxY){
        return getMouseX() >= minX &&
                getMouseX() <= maxX &&
                getMouseY() >= minY &&
                getMouseY() <= maxY;
    }

    private void drawPicture(Picture pictureObject, int offsetX, int offsetY) {
        var pictureData = pictureObject.getPictureData();
        for (int i = 0; i < pictureObject.getWidth(); i++) {
            for (int j = 0; j < pictureObject.getHeight(); j++) {
                draw(i + offsetX, j + offsetY, pictureData.get(i).get(j));
            }
        }
    }

    @Override
    public boolean onUserCreate() {
        gameName = "PuzzleGame";

        state = State.MAIN;
        mainPicture = new Picture();
        fileSelectionPicture = new Picture("D:/Programming/lib/Puzzles/SelectFile.PNG");
        startGamePicture = new Picture("D:/Programming/lib/Puzzles/Start.PNG");
        fileService = new FileService();
        pictureLocationOffsetX = screenWidth / 6;
        pictureLocationOffsetY = 140;
        fileSelectionPictureOffsetX = screenWidth / 3 + 70;
        fileSelectionPictureOffsetY = 40;
        startButtonOffsetX = fileSelectionPictureOffsetX + 20;
        return true;
    }

    @Override
    public boolean onUserUpdate(double frameTime) {

        fill(0, 0, screenWidth, screenHeight, Color.BLACK);

        if(state == State.MAIN) {
            drawPicture(fileSelectionPicture, fileSelectionPictureOffsetX, fileSelectionPictureOffsetY);

            if (getKey(KeyEvent.VK_F).pressed &&
                isMouseOnButton(fileSelectionPictureOffsetX, fileSelectionPictureOffsetX + fileSelectionPicture.getWidth(),
                fileSelectionPictureOffsetY, fileSelectionPictureOffsetY + fileSelectionPicture.getHeight())) {
                mainPicture = new Picture(fileService.chooseFileFromComputer());
            }

            drawPicture(mainPicture, pictureLocationOffsetX, pictureLocationOffsetY);
            startButtonOffsetY = pictureLocationOffsetY + mainPicture.getHeight() + 40;
            drawPicture(startGamePicture, fileSelectionPictureOffsetX + 20, startButtonOffsetY);

            if(getKey(KeyEvent.VK_F).pressed && isMouseOnButton(startButtonOffsetX,startButtonOffsetX + startGamePicture.getWidth(),
                    startButtonOffsetY, startButtonOffsetY + startGamePicture.getHeight())) {
                state = State.GAME;
            }

        } else {

        }

        return true;
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                PuzzleGame example = new PuzzleGame();
                example.constructFrame(1000, 1000, 1, 1);
                example.start();
            }
        });
    }
}
