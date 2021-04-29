import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;

public class Main {

    public static void printTestData(ArrayList<String[]> testData) {
        System.out.println("Тестовые данные:");

        for (var line : testData) {
            System.out.println(Arrays.toString(line));
        }
    }

    public static void printTreeNodes(ID3 decisionTree) {
        System.out.println("Кол-во вершин в дереве = " + decisionTree.nodesCount);
        Node.printInOrder(decisionTree.root);
    }

    public static void main(String[] args) throws IOException {
        String class1 = "Да", class2 = "Нет";

        Preprocess preprocess = new Preprocess(class1, class2);
        ArrayList<String[]> trainData = preprocess.parseInputFile(new File("Data/train.data"));
        ArrayList<String[]> testData = preprocess.parseInputFile(new File("Data/test.data"));

        ArrayList<Integer> remainAttr = new ArrayList<>();
        for (int i = 0; i < trainData.get(0).length - 1; i++) remainAttr.add(i);

        int numOfClass1 = preprocess.numOfClass1;
        int numOfClass2 = preprocess.numOfClass2;

        Preprocess.computeDiscreteValues(trainData);

        ID3 decisionTree = new ID3(trainData, testData, numOfClass1, numOfClass2, class1, class2, Preprocess.discreteValues, remainAttr);
        printTreeNodes(decisionTree);

        System.out.println();
        printTestData(testData);
        System.out.println();
        System.out.println("Результаты:");
        decisionTree.useDecisionTreeOnTestData();
    }

}
