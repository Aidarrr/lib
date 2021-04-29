import java.awt.*;
import java.awt.image.BufferedImage;

public class Hiragana {
    private BufferedImage[] images;
    private PairInt[] correctAnswers;
    private int borderColor;
    private int yellowColor;
    private int greenColor;
    private FileService fileService;

    public Hiragana() {
        fileService = new FileService();
        images = fileService.readAllImagesFromFolder();

        correctAnswers = new PairInt[images.length];
        for (int i = 0; i < fileService.hiraganaImageNames.length; i++) {
            correctAnswers[i] = new PairInt(i, i + fileService.hiraganaImageNames.length);
        }

        greenColor = 0xFF1C8E3E;
        yellowColor = 0xFFFFF97D;
        borderColor = 0xFFBEBEBE;
    }

    public void setImageToYellow(BufferedImage image){
        for (int i = 0; i < image.getWidth(); i++) {
            for (int j = 0; j < image.getHeight(); j++) {
                int color = image.getRGB(i,j);
                if(color > borderColor){
                    image.setRGB(i, j, yellowColor);
                }
            }
        }
    }

    public void setImageToWhite(BufferedImage image){
        for (int i = 0; i < image.getWidth(); i++) {
            for (int j = 0; j < image.getHeight(); j++) {
                int color = image.getRGB(i,j);
                if(color == yellowColor){
                    image.setRGB(i, j, 0xFFFFFFFF);
                }
            }
        }
    }

    public void setImageToGreen(BufferedImage image){
        for (int i = 0; i < image.getWidth(); i++) {
            for (int j = 0; j < image.getHeight(); j++) {
                image.setRGB(i, j, greenColor);
            }
        }
    }
}
