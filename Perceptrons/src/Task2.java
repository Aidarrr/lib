import java.util.ArrayList;
import java.util.Arrays;
import java.util.Random;

class Letter {
    static int size = 5;
    private int[][] letterData;
    public char letterChar;

    public Letter(int[][] letterData, char letterChar) {
        this.letterData = letterData;
        this.letterChar = letterChar;
    }

    public int[][] getLetter() {
        return letterData;
    }
}

class Perceptrons {
    static int lettersCount = 5;
    private ArrayList<Letter> letters;
    private int[][] weights;
    private int[] output;
    private int era, totalError;    //Суммарная ошибка
    private int[][] targets;        //Таблица c ожидаемыми значениями

    public Perceptrons(ArrayList<Letter> letters) {
        this.letters = letters;
        weights = new int[lettersCount][Letter.size * Letter.size];

        Random random = new Random();
        for (int i = 0; i < lettersCount; i++) {
            for (int j = 0; j < Letter.size * Letter.size; j++) {
                weights[i][j] = random.nextInt(2) * 10 - 5;
            }
        }

        output = new int[lettersCount];
        targets = new int[lettersCount][lettersCount];
        for (int i = 0; i < lettersCount; i++) {
            Arrays.fill(targets[i], 0);
            targets[i][i] = 1;
        }
        era = 0;
        totalError = 1;
    }

    private int multWeightsOnInput(int[] weights, int[][] letter) {         //Умножение весов w_i определенного нейрона на входной вектор X
        int output = 0;

        for (int i = 0; i < letter.length; i++) {
            for (int j = 0; j < letter[i].length; j++) {
                output += letter[i][j] * weights[i * letter.length + j];
            }
        }
        return output > 0 ? 1 : 0;
    }

    private void adjustWeights(int[] weights, int speed, int target, int output, int[][] input) {       //Корректировка весов
        for (int i = 0; i < input.length; i++) {
            for (int j = 0; j < input[i].length; j++) {
                weights[i * input.length + j] = weights[i * input.length + j] + speed * (target - output) * input[i][j];
            }
        }
    }

    public void train() {               //Обучение сети
        setRandWeights();
        calcTotalError();

        while (totalError != 0) {
            totalError = 0;
            era++;

            for (int k = 0; k < letters.size(); k++) {
                for (int i = 0; i < output.length; i++) {
                    output[i] = multWeightsOnInput(weights[i], letters.get(k).getLetter());
                    adjustWeights(weights[i], 1, targets[i][k], output[i], letters.get(k).getLetter());
                    totalError += Math.abs(targets[i][k] - output[i]);      //Вычисление ошибки
                }
            }
        }
    }

    public int[] getOutput(int[][] letter){
        int[] copyOutput = new int[lettersCount];
        for (int i = 0; i < weights.length; i++) {
            copyOutput[i] = multWeightsOnInput(weights[i], letter);
        }
        return copyOutput;
    }
}

public class Task2 {
    public static void createLetters(ArrayList<Letter> letters) {       //Буквы К, О, С, Т, И

        int[][] letterKData = {
                {1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0},
                {1, 1, 1, 0, 0},
                {1, 0, 0, 1, 0},
                {1, 0, 0, 0, 1}
        };

        int[][] letterOData = {
                {1, 1, 1, 1, 1},
                {1, 0, 0, 0, 1},
                {1, 0, 0, 0, 1},
                {1, 0, 0, 0, 1},
                {1, 1, 1, 1, 1}
        };

        int[][] letterCData = {
                {1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0},
                {1, 0, 0, 0, 0},
                {1, 0, 0, 0, 0},
                {1, 1, 1, 1, 1}
        };

        int[][] letterTData = {
                {1, 1, 1, 1, 1},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0}
        };

        int[][] letterIData = {     //И
                {1, 0, 0, 0, 1},
                {1, 0, 0, 1, 1},
                {1, 0, 1, 0, 1},
                {1, 1, 0, 0, 1},
                {1, 0, 0, 0, 1}
        };

        Letter letterK = new Letter(letterKData, 'К');
        Letter letterO = new Letter(letterOData, 'О');
        Letter letterC = new Letter(letterCData, 'С');
        Letter letterT = new Letter(letterTData, 'Т');
        Letter letterI = new Letter(letterIData, 'И');

        letters.add(letterK);
        letters.add(letterO);
        letters.add(letterC);
        letters.add(letterT);
        letters.add(letterI);
    }

    public static void main(String[] args) {
        ArrayList<Letter> letters = new ArrayList<>(Perceptrons.lettersCount);
        createLetters(letters);

        Perceptrons perceptrons = new Perceptrons(letters);
        perceptrons.train();                                        //Обучение сети

        for (int i = 0; i < Perceptrons.lettersCount; i++) {        //Получение результатов обработки каждой буквы
            System.out.println("Вектор выходов сети для буквы " + letters.get(i).letterChar + ":");
            var outputArray = perceptrons.getOutput(letters.get(i).getLetter());
            System.out.println(Arrays.toString(outputArray));
        }
    }
}
