import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import static java.lang.Integer.parseInt;

public class MyFrame {
    static JTextField textField = new JTextField("Text: ");

    public static void main(String[] args) {
        JFrame frame = new JFrame("Test");

        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(500, 400);

        setLabelAndSlider(frame);
        setGrid(frame);

        frame.setVisible(true);
        frame.pack();
        frame.setMinimumSize(frame.getSize());
    }

    public static void setLabelAndSlider(JFrame frame) {
        JPanel myPanel1 = new JPanel();
        myPanel1.setLayout(new FlowLayout());

        myPanel1.add(new JLabel("0"));
        JSlider slider = new JSlider(0, 10);
        myPanel1.add(slider);
        myPanel1.add(new JLabel("10"));

        Component horizontalStrut = Box.createHorizontalStrut(40);
        myPanel1.add(horizontalStrut);

        Box myBox = new Box(BoxLayout.Y_AXIS);
        myBox.add(Box.createVerticalStrut(10));
        myBox.add(myPanel1);
        myBox.add(Box.createVerticalGlue());

        textField.addKeyListener(new MyKeyEvent());
        myBox.add(textField);

        slider.addChangeListener(new ChangeListener() {
            @Override
            public void stateChanged(ChangeEvent e) {
                textField.setText(Integer.toString(slider.getValue()));
            }
        });

        frame.add(myBox, BorderLayout.NORTH);
    }

    public static void setGrid(JFrame frame) {
        JPanel myPanel = new JPanel();
        int rows = 4, cols = 5;
        myPanel.setLayout(new GridLayout(rows, cols));

        ArrayList<JButton> buttonArray = new ArrayList<JButton>();
        String[] calcActions = {"+", "-", "="};


        for (int i = 0; i < 3; i++) {
            for (int j = 1; j <= 3; j++) {
                buttonArray.add(new JButton(Integer.toString(3 * i + j)));
            }

            JButton b = new JButton("empty");
            b.setVisible(false);
            buttonArray.add(b);

            buttonArray.add(new JButton(calcActions[i]));
        }

        JButton hiddenButton = new JButton("empty");
        hiddenButton.setVisible(false);
        buttonArray.add(hiddenButton);
        buttonArray.add(new JButton("0"));

        final String[] action = {""};

        for (JButton button : buttonArray) {
            button.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    textField.setText(textField.getText() + button.getText());

                    if (button.getText().equals("+"))
                        action[0] = "+";
                    if (button.getText().equals("-"))
                        action[0] = "-";

                    if (button.getText().equals("=")) {
                        textField.setText(textField.getText() + calculate(textField.getText(), action[0]));
                    }
                }
            });
        }

        for (int i = 0; i < rows * cols - 3; i++) {
            myPanel.add(buttonArray.get(i));
        }

        frame.add(myPanel, BorderLayout.CENTER);
    }

    public static String calculate(String exp, String action) {
        int num1 = 0, num2 = 0;

        String regExp = "[0-9]+";
        Pattern pattern = Pattern.compile(regExp);
        Matcher matcher = pattern.matcher(exp);

        if (matcher.find())
            num1 = parseInt(exp.substring(matcher.start(), matcher.end()));
        if (matcher.find())
            num2 = parseInt(exp.substring(matcher.start(), matcher.end()));

        return Integer.toString(action.equals("+") ? num1 + num2 : num1 - num2);
    }
}

class MyKeyEvent extends KeyAdapter {
    String action = "+";

    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
            MyFrame.textField.setText("Text: ");
        } else if (e.getKeyCode() == KeyEvent.VK_ENTER) {
            MyFrame.textField.setText(MyFrame.textField.getText() + MyFrame.calculate(MyFrame.textField.getText(), action));
        } else if (e.getKeyCode() == KeyEvent.VK_PLUS)
            action = "+";
        else if (e.getKeyCode() == KeyEvent.VK_MINUS)
            action = "-";
    }
}
