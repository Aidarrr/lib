import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class FileService {
    private String hiraganaFolder;
    private String russianFolder;
    public String[] hiraganaImageNames;
    public String[] rusImageNames;

    public FileService() {
        hiraganaFolder = "../resources/HiraganaSyllables";
        russianFolder = "../resources/RussianSyllables";

        hiraganaImageNames = new String[]{"каХир.png", "таХир.png", "руХир.png"};
        rusImageNames = new String[]{"ка.png", "та.png", "ру.png"};
    }

    public BufferedImage readImage(String fileName){
        BufferedImage picture = new BufferedImage(3,3,1);

        try {
            File picFile = new File(fileName);
            picture = ImageIO.read(picFile);
        } catch (IOException e) {
            e.printStackTrace();
        }

        return picture;
    }

    public BufferedImage[] readAllImagesFromFolder(){
        BufferedImage[] images = new BufferedImage[hiraganaImageNames.length + rusImageNames.length];

        for (int i = 0; i < hiraganaImageNames.length; i++) {
            images[i] = readImage(hiraganaFolder + hiraganaImageNames[i]);
        }

        for (int i = hiraganaImageNames.length; i < rusImageNames.length + hiraganaImageNames.length; i++) {
            images[i] = readImage(russianFolder + rusImageNames[i - hiraganaImageNames.length]);
        }

        return images;
    }
}
