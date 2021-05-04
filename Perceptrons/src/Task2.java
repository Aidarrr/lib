import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
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

class Individual {       //Особь
    static int individualCount = 8;
    public double[] individualWeights;
    public int error;

    public Individual() {
        this.individualWeights = new double[Letter.size * Letter.size];
    }

    public Individual(double[] individualWeights) {
        this.individualWeights = individualWeights;
    }
}

class Perceptrons {
    static int lettersCount = 5;
    private ArrayList<Letter> letters;
    private Individual[][] weights;
    private double[][] correctWeights;
    private int[] output;
    private int era, totalError;    //Суммарная ошибка
    private int[][] targets;        //Таблица c ожидаемыми значениями
    ArrayList<Individual> nextPopulation;

    public Perceptrons(ArrayList<Letter> letters) {
        this.letters = letters;
        weights = new Individual[lettersCount][Individual.individualCount];
        correctWeights = new double[lettersCount][Letter.size * Letter.size];

        output = new int[lettersCount];
        targets = new int[lettersCount][lettersCount];
        for (int i = 0; i < lettersCount; i++) {
            Arrays.fill(targets[i], 0);
            targets[i][i] = 1;
        }
        era = 0;
        totalError = 1;
        nextPopulation = new ArrayList<>();
    }

    private void setRandWeights() {
        Random random = new Random();
        for (int i = 0; i < lettersCount; i++) {
            for (int j = 0; j < Individual.individualCount; j++) {
                weights[i][j] = new Individual();

                for (int k = 0; k < Letter.size * Letter.size; k++) {
                    weights[i][j].individualWeights[k] = random.nextDouble() * 10 - 5;
                }

            }
        }
    }

    private int multWeightsOnInput(double[] weights, int[][] letter) {         //Умножение весов w_i определенного нейрона на входной вектор X
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

    private void copyCorrectWeights(int neuronNumber, double[] individualWeights) {
        correctWeights[neuronNumber] = Arrays.copyOf(individualWeights, individualWeights.length);
    }

    private void calcNextPopulationError(int neuronNumber) {
        for (int k = 0; k < Letter.size; k++) {
            for (int individual = 0; individual < nextPopulation.size(); individual++) {
                int out = multWeightsOnInput(nextPopulation.get(individual).individualWeights, letters.get(k).getLetter());
                nextPopulation.get(individual).error += Math.abs(out - targets[neuronNumber][k]);
            }
        }
    }

    private boolean hasPopulationError(Individual[] weights, int neuronNumber) {
        for (int individual = 0; individual < weights.length; individual++) {
            weights[individual].error = 0;
        }

        for (int k = 0; k < Letter.size; k++) {
            for (int individual = 0; individual < weights.length; individual++) {
                int out = multWeightsOnInput(weights[individual].individualWeights, letters.get(k).getLetter());
                weights[individual].error += Math.abs(out - targets[neuronNumber][k]);
            }
        }

        for (int individual = 0; individual < weights.length; individual++) {
            if (weights[individual].error == 0) {
                copyCorrectWeights(neuronNumber, weights[individual].individualWeights);
                return false;
            }
        }

        return true;
    }

    private Individual[] sortCurrentPopulation(Individual[] individuals) {
        ArrayList<Individual> currentPopulation = new ArrayList<>(Arrays.asList(individuals));
        currentPopulation.sort(Comparator.comparing(e -> e.error));
        individuals = currentPopulation.toArray(new Individual[0]);
        return individuals;
    }

    private void sortNextPopulation() {
        nextPopulation.sort(Comparator.comparing(e -> e.error));
    }

    private void cross(Individual[] weights, int neuronNumber) {
        int weightsArrayLength = weights[0].individualWeights.length;
        int cuttingIndex = (weightsArrayLength - 1) / 2;
        int halfOfIndividuals = weights.length / 2;

        for (int individual = 0; individual < halfOfIndividuals; individual++) {
            double[] childrenWeights = new double[weightsArrayLength];
            double[] mom = weights[individual].individualWeights;
            double[] dad = weights[individual + halfOfIndividuals].individualWeights;

            for (int i = 0; i < cuttingIndex; i++) {
                childrenWeights[i] = mom[i];
            }
            for (int i = cuttingIndex; i < weightsArrayLength; i++) {
                childrenWeights[i] = dad[i];
            }

            nextPopulation.add(new Individual(childrenWeights));
        }
    }

    private void mutate(Individual[] individuals) {
        int weightsArrayLength = individuals[0].individualWeights.length;
        int errorBorder = 3;
        Random random = new Random();

        for (int individual = 0; individual < individuals.length; individual++) {
            if (individuals[individual].error >= errorBorder) {
                double[] mutatedIndividual = Arrays.copyOf(individuals[individual].individualWeights, weightsArrayLength);
                int iterations = errorBorder;

                for (int i = 0; i < iterations; i++) {
                    int randIndex = random.nextInt(weightsArrayLength);
                    mutatedIndividual[randIndex] = random.nextDouble() * 10 - 5;
                }
                nextPopulation.add(new Individual(mutatedIndividual));
            }
        }
    }

    private Individual[] substitute(Individual[] currentPopulation) {
        Individual[] chosenIndividuals = new Individual[Individual.individualCount];
        int i = 0, j = 0, k = 0;

        while (i < currentPopulation.length && j < nextPopulation.size() && k < chosenIndividuals.length) {
            if (currentPopulation[i].error < nextPopulation.get(j).error) {
                chosenIndividuals[k] = currentPopulation[i];
                i++;
                k++;
            } else {
                chosenIndividuals[k] = nextPopulation.get(j);
                j++;
                k++;
            }
        }

        if(k != chosenIndividuals.length){
            while(i < currentPopulation.length && k < chosenIndividuals.length){
                chosenIndividuals[k] = currentPopulation[i];
                i++;
                k++;
            }
        }

        return chosenIndividuals;
    }

    public void train() {               //Обучение сети
        setRandWeights();

        for (int neuron = 0; neuron < letters.size(); neuron++) {
            while (hasPopulationError(weights[neuron], neuron)) {

                cross(weights[neuron], neuron);
                mutate(weights[neuron]);
                calcNextPopulationError(neuron);
                sortNextPopulation();
                weights[neuron] = sortCurrentPopulation(weights[neuron]);
                weights[neuron] = substitute(weights[neuron]);

                nextPopulation.clear();
            }
        }


    }

    public int[] getOutput(int[][] letter) {
        int[] copyOutput = new int[lettersCount];
        for (int i = 0; i < correctWeights.length; i++) {
            copyOutput[i] = multWeightsOnInput(correctWeights[i], letter);
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
