public class Data implements Comparable<Data>{
    private String name;

    public Data(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public int compareTo(Data other) {
        int length1 = name.length();
        int length2 = other.getName().length();

        if(length1 < length2)
            return 1;
        else if(length1 > length2)
            return -1;
        else
            return 0;
    }
}