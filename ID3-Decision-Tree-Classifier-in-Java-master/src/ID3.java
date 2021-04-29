import java.util.ArrayList;
import java.util.HashMap;

public class ID3 {
    private HashMap<Integer, ArrayList<String>> discreteValues;
    private String class1, class2;
    private ArrayList<String[]> data;
    private ArrayList<String[]> testData;
    Node root;
    int nodesCount;

    public ID3(ArrayList<String[]> data, ArrayList<String[]> testData, int numOfClass1, int numOfClass2, String class1, String class2, HashMap<Integer, ArrayList<String>> discreteValues, ArrayList<Integer> remAttr) {
        this.data = data;
        this.class1 = class1;
        this.class2 = class2;
        this.testData = testData;
        this.discreteValues = discreteValues;
        this.nodesCount = 0;

        root = new Node();

        double p1 = numOfClass1 / (numOfClass1 + numOfClass2 + 0.0), p2 = numOfClass2 / (numOfClass1 + numOfClass2 + 0.0);
        root.entropy = -1 * pLogP(p1) - 1 * pLogP(p2);

        root.data = data;
        root.numOfClass1 = numOfClass1;
        root.numOfClass2 = numOfClass2;

        root.remainingAttributes = remAttr;

        generateDecisionTree(root);
        countNodes(root);
    }

    public void useDecisionTreeOnTestData() {
        int correctClassification = 0, incorrectClassification = 0;

        for (String[] testRow : testData) {
            int predicted = Node.predictClassOfTestData(root, testRow, discreteValues);
            int actual = testRow[testRow.length - 1].equals(class1) ? 1 : 2;

            if (predicted == actual) {
                correctClassification++;
            } else {
                incorrectClassification++;
            }

            if (predicted == 1) {
                System.out.println(class1);
            } else {
                System.out.println(class2);
            }
        }
    }

    public void countNodes(Node root) {
        if (root == null) return;
        nodesCount++;
        if (root.isLeaf) return;
        for (Node n : root.children) countNodes(n);
    }

    private static double pLogP(double p) {
        return p == 0 ? 0 : p * Math.log(p);
    }

    private void generateDecisionTree(Node root) {
        if (root == null) return;

        if (root.remainingAttributes.size() == 1) {//Лист
            root.isLeaf = true;
            root.classification = root.numOfClass1 >= root.numOfClass2 ? 1 : 2;
        } else if (root.numOfClass1 == 0 || root.numOfClass2 == 0 || root.data.size() == 0) {//Лист
            root.isLeaf = true;
            root.classification = root.numOfClass1 == 0 ? 2 : 1;
        } else {
            //Выбор корня поддерева на основе максимального значения gain
            root.children = calcMaxGain(root);

            ArrayList<String> discreteValuesOfThisAttribute = discreteValues.get(root.attribute);
            for (int j = 0; j < discreteValuesOfThisAttribute.size(); j++) {
                root.children[j].data = new ArrayList<>();
                root.children[j].remainingAttributes = new ArrayList<>();
                for (int rem : root.remainingAttributes) {
                    if (rem != root.attribute) root.children[j].remainingAttributes.add(rem);
                }
                String curr = discreteValuesOfThisAttribute.get(j);
                for (String[] s : root.data) {
                    if (s[root.attribute].equals(curr)) {
                        root.children[j].data.add(s);
                    }
                }
                generateDecisionTree(root.children[j]);
            }
        }
    }

    public Node[] calcMaxGain(Node root) {
        double maxGain = -1.0;
        Node[] choisedRoot = null;

        for (int i : root.remainingAttributes) {
            ArrayList<String> discreteValuesOfThisAttribute = discreteValues.get(i);
            Node[] child = new Node[discreteValuesOfThisAttribute.size()];
            for (int j = 0; j < discreteValuesOfThisAttribute.size(); j++) {
                String curr = discreteValuesOfThisAttribute.get(j);
                child[j] = new Node();
                for (String[] s : root.data) {
                    if (s[i].equals(curr)) {
                        if (s[s.length - 1].equals(class1)) child[j].numOfClass1++;
                        else child[j].numOfClass2++;
                    }
                }
            }

            int total = root.data.size();
            double gain = root.entropy;
            for (int j = 0; j < discreteValuesOfThisAttribute.size(); j++) {
                int c1 = child[j].numOfClass1, c2 = child[j].numOfClass2;
                if (c1 == 0 && c2 == 0) continue;
                double p1 = c1 / (c1 + c2 + 0.0), p2 = c2 / (c1 + c2 + 0.0);
                child[j].entropy = -1 * pLogP(p1) + -1 * pLogP(p2);
                gain -= ((c1 + c2) / (total + 0.0)) * child[j].entropy;
            }
            if (gain > maxGain) {
                root.attribute = i;
                maxGain = gain;
                choisedRoot = child;
            }
        }
        return choisedRoot;
    }
}
