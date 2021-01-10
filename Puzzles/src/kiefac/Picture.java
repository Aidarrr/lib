package kiefac;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class Picture {
    private int width;
    private int height;
    private BufferedImage picture;
    private ArrayList<ArrayList<Color>> pictureData;

    public Picture(){
        pictureData = new ArrayList<>();
        width = 0;
        height = 0;
    }

    public Picture(String pictureName) {
        pictureData = new ArrayList<>();
        try {
            File picFile = new File(pictureName);
            picture = ImageIO.read(picFile);
            width = picture.getWidth();
            height = picture.getHeight();

            for (int i = 0; i < width; i++) {
                ArrayList<Color> col = new ArrayList<>();
                for (int j = 0; j < height; j++) {
                    col.add(new Color(picture.getRGB(i, j)));
                }
                pictureData.add(col);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public ArrayList<ArrayList<Color>> getPictureData() {
        return pictureData;
    }

    public int getWidth() {
        return width;
    }

    public int getHeight() {
        return height;
    }
}
