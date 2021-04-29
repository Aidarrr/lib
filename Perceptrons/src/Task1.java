import java.util.Scanner;

public class Task1 {
    public static boolean areWeightsCorrect(int[] correctOutput, int[] weights) {       //Проверка правильности настройки весов
        int output, i = 0;

        for (int x1 = 0; x1 <= 1; x1++) {
            for (int x2 = 0; x2 <= 1; x2++) {

                if (weights[0] + weights[1] * x1 + weights[2] * x2 < 0)
                    output = 0;
                else
                    output = 1;

                if (output != correctOutput[i++])
                    return false;
            }
        }

        return true;
    }

    public static int getPerceptronOut(int[] weights, int x1, int x2) {         //Получение результата работы нейрона в зависимости от входов x1, x2
        return weights[0] + weights[1] * x1 + weights[2] * x2 < 0 ? 0 : 1;
    }

    public static void main(String[] args) {
        int[] correctOutput = new int[]{1, 0, 0, 0};
        int[] weights = new int[]{2, -3, -4};           //Веса, установленные вручную
        int x1 = 0, x2 = 0;

        if (areWeightsCorrect(correctOutput, weights)) {
            System.out.println("Perceptron is ready!");
            Scanner scanner = new Scanner(System.in);

            while (x1 >= 0 && x2 >= 0) {
                System.out.println("x1 x2");
                x1 = scanner.nextInt();
                x2 = scanner.nextInt();

                System.out.println(getPerceptronOut(weights, x1, x2));
            }
        }
    }
}
