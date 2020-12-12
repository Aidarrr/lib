import java.util.Comparator;

public class DataComparator implements Comparator<Data> {
    @Override
    public int compare(Data o1, Data o2) {
        int length1 = o1.getName().length();
        int length2 = o2.getName().length();

        if(length1 < length2)
            return 1;
        else if(length1 > length2)
            return -1;
        else
            return 0;
    }
}
