import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Data> dataList = new ArrayList<Data>();

        dataList.add(new Data("aa"));
        dataList.add(new Data("aaa"));
        dataList.add(new Data("aaaa"));

        Collections.sort(dataList);
    }
}
