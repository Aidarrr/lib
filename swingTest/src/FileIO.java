import java.io.File;
import java.io.IOException;
import java.util.Date;

public class FileIO {
    public static void main(String[] args) {

        String path = "D:/test";
        File dir = new File(path);

        if (dir.exists() && dir.isDirectory()) {

            if (!((dir = new File(path + "/test.txt")).exists())) {
                try {
                    dir.createNewFile();
                    System.out.println(dir.length());
                    Date date = new Date(dir.lastModified());
                    System.out.println(date.toString());
                } catch (IOException e) {
                    e.printStackTrace();
                }
            } else {
                System.out.println(dir.length());
                Date date = new Date(dir.lastModified());
                System.out.println(date.toString());
            }
        }
    }
}
