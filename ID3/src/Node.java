import java.util.ArrayList;
import java.util.HashMap;

public class Node {
    int attribute;//Свойство данного узла (температура, влажность, ...)
    ArrayList<Integer> remainingAttributes; //Оставшиеся свойства, которые могут быть использованы
    int numOfClass1;
    int numOfClass2;
    double entropy;

    Node[] children;
    ArrayList<String[]> data;   //Данные, удовлетворяющие данной вершине
    boolean isLeaf = false;
    int classification; //Да или нет, если вершина - лист

    public Node(int attr, String value, int c1, int c2, double entropyVal, ArrayList<String[]> data, ArrayList<Integer> remainingAttributes) {
        attribute = attr;
        numOfClass1 = c1;
        numOfClass2 = c2;

        entropy = entropyVal;
        this.data = data;
        this.remainingAttributes = remainingAttributes;
    }

    public Node(int classification) {
        isLeaf = true;
        this.classification = classification;
    }

    public Node() {

    }

    public String toString() {
        return isLeaf ? "Лист, class = " + classification : "Свойство = " + attribute;
    }

    public static int predictClassOfTestData(Node root, String[] testDataRow, HashMap<Integer, ArrayList<String>> discreteValues) {
        if (root == null) return 1;
        else if (root.isLeaf) return root.classification;

        String s = testDataRow[root.attribute];
        ArrayList<String> discrVals = discreteValues.get(root.attribute);

        for (int i = 0; i < discrVals.size(); i++) {
            if (s.equals(discrVals.get(i))) {
                return predictClassOfTestData(root.children[i], testDataRow, discreteValues);
            }
        }

        return 1;
    }

    public static void printInOrder(Node root) {
        if (root == null) return;
        System.out.println(root);
        if (root.isLeaf) return;
        for (Node c : root.children) printInOrder(c);
    }
}
