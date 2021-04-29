import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;
import java.util.ArrayList;

public class Frame {
    private JFrame frame;
    int gridRows, gridCols;

    public Frame(int width, int height) {
        frame = new JFrame("Hiragana");
        gridRows = 8; gridCols = 8;

        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(width, height);
        //setGrid(frame);
        createMenuBar(frame);
        frame.setVisible(true);
        frame.pack();
        frame.setMinimumSize(frame.getSize());
    }

    private void setGrid(JFrame frame, BufferedImage[] images) {
        JPanel myPanel = new JPanel();
        myPanel.setLayout(new GridLayout(gridRows, gridCols));

        JLabel[] labels = new JLabel[gridRows * gridCols];
        for (int i = 0; i < labels.length; i++) {
            labels[i] = new JLabel();
            labels[i].setIcon(new ImageIcon(images[i]));
        }

        for (JLabel label : labels) {
            label.addMouseListener(new MouseListener() {
                @Override
                public void mouseClicked(MouseEvent e) {

                }

                @Override
                public void mousePressed(MouseEvent e) {

                }

                @Override
                public void mouseReleased(MouseEvent e) {

                }

                @Override
                public void mouseEntered(MouseEvent e) {

                }

                @Override
                public void mouseExited(MouseEvent e) {

                }
            });
        }

        for (int i = 0; i < labels.length; i++) {
            myPanel.add(labels[i]);
        }

        frame.add(myPanel, BorderLayout.CENTER);
    }

    private void createMenuBar(JFrame frame){
        JMenuBar menuBar = new JMenuBar();
        JMenu menuGame = new JMenu("Игра");
        JMenu menuAlphabet = new JMenu("Алфавит");

        ButtonGroup gameSelectGroup = new ButtonGroup();
        JRadioButton radioButtonMatrix = new JRadioButton("Игра 1");
        radioButtonMatrix.setSelected(true);
        JRadioButton radioButtonWriting = new JRadioButton("Игра 2");
        gameSelectGroup.add(radioButtonMatrix);
        gameSelectGroup.add(radioButtonWriting);
        menuGame.add(radioButtonMatrix);
        menuGame.add(radioButtonWriting);

        ButtonGroup alphabetSelectGroup = new ButtonGroup();
        JRadioButton hiraganaRadioButton = new JRadioButton("Хирагана");
        hiraganaRadioButton.setSelected(true);
        JRadioButton katakanaRadioButton = new JRadioButton("Катакана");
        alphabetSelectGroup.add(hiraganaRadioButton);
        alphabetSelectGroup.add(katakanaRadioButton);
        menuAlphabet.add(hiraganaRadioButton);
        menuAlphabet.add(katakanaRadioButton);

        menuBar.add(menuGame);
        menuBar.add(menuAlphabet);

        frame.setJMenuBar(menuBar);
    }
}
