import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.StringTokenizer;

public class Preprocess {
    int numOfClass1, numOfClass2;
    String class1, class2;
    static HashMap<Integer, ArrayList<String>> discreteValues = new HashMap<>();    //Значения свойств

    public Preprocess(String class1, String class2) {
        this.class1 = class1;
        this.class2 = class2;
    }

    public ArrayList<String[]> parseInputFile(File trainOriginal) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new FileReader(trainOriginal));
        String fileRow = bufferedReader.readLine();
        bufferedReader.close();

        StringTokenizer stringTokenizer = new StringTokenizer(fileRow, ",");
        int numOfAttributes = stringTokenizer.countTokens();

        ArrayList<String[]> data = new ArrayList<>();
        bufferedReader = new BufferedReader(new FileReader(trainOriginal));

        while ((fileRow = bufferedReader.readLine()) != null) {
            stringTokenizer = new StringTokenizer(fileRow, ",");
            String[] dataset = new String[numOfAttributes];
            for (int i = 0; i < numOfAttributes; i++) {
                dataset[i] = stringTokenizer.nextToken();
            }
            if (dataset[numOfAttributes - 1].equals(class1)) numOfClass1++;
            else numOfClass2++;
            data.add(dataset);
        }

        bufferedReader.close();
        return data;
    }

    public static void computeDiscreteValues(ArrayList<String[]> data) {
        HashSet<String> observedAttributes = new HashSet<>();
        String[] sampleDataset = data.get(0);

        for (int i = 0; i < sampleDataset.length - 1; i++) {
            discreteValues.put(i, new ArrayList<String>());
        }

        for (String[] dataset : data) {
            for (int i = 0; i < dataset.length - 1; i++) {
                String attribute = dataset[i];
                if (attribute.equals("?")) continue;
                if (!observedAttributes.contains(attribute)) {
                    discreteValues.get(i).add(attribute);
                    observedAttributes.add(attribute);
                }
            }
        }

    }
}

class Comp implements Comparator<String[]> {
    int index;

    public Comp(int i) {
        index = i;
    }

    public int compare(String[] s1, String[] s2) {
        return s1[index].compareTo(s2[index]);
    }
}