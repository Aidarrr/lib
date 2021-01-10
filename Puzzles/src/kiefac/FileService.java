package kiefac;

import javax.swing.*;

public class FileService {
    private String fileName;

    public String chooseFileFromComputer(){
        JFileChooser jfc = new JFileChooser();
        jfc.showDialog(null,"Start");

        fileName = jfc.getSelectedFile().getName();
        return fileName;
    }
}
