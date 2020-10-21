/*
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.function.DoubleUnaryOperator;

enum Level {
    HIGH  (3),  //calls constructor with value 3
    MEDIUM(2),  //calls constructor with value 2
    LOW   (1)   //calls constructor with value 1
    ; // semicolon needed when fields / methods follow


    private final int levelCode;

    Level(int levelCode) {
        this.levelCode = levelCode;
    }

    public int getLevelCode() {
        return this.levelCode;
    }

}

public class Main {

    public static char charExpression(int a) {
        return (char)((int)('\\') + a);

    }

    public static boolean isPowerOfTwo(int value)
    {
        if(value == 0)
            return false;

        value = Math.abs(value);

        int count = 0;
        while(value != 0)
        {
            count += value & 1;
            value = value >> 1;
            if(count > 1)
            {
                return false;
            }
        }

        return true;
    }

    public static boolean doubleExpression(double a, double b, double c) {
        return ((a + b) - c < 0.0001);
    }

    public static int flipBit(int value, int bitIndex) {
        return value ^ (1 << (bitIndex - 1));
    }

    public static double integrate(DoubleUnaryOperator f, double a, double b) {
        double step = 0.0000001;
        double res = 0;
        for (double i = a; i < b; i+=step) {
            res+=(f.applyAsDouble(i) * step);
        }
        return res;
    }

    public static Label checkLabels(TextAnalyzer[] analyzers, String text) {
        for (TextAnalyzer e : analyzers)
        {
            Label check = e.processText(text);
            if(check != Label.OK)
                return check;
        }
        return Label.OK;
    }

    public static int roleEndIndex;

    private static boolean consistsRole(String role, String textLine){
        int end = 0;
        for (int i = 0; i < textLine.length(); i++) {
            if(textLine.charAt(i) == ':') {
                end = i;
                roleEndIndex = i;
                break;
            }
        }

        return role.equals(textLine.substring(0, end));
    }

    private static String printTextPerRole(String[] roles, String[] textLines) {
        StringBuilder stringBuilder = new StringBuilder();


        for (int i = 0; i < roles.length; i++) {
            stringBuilder.append(roles[i]);
            stringBuilder.append(":\n");
            for (int j = 0; j < textLines.length; j++) {
                if(consistsRole(roles[i], textLines[j]))
                {
                    stringBuilder.append(j + 1);
                    stringBuilder.append(")");
                    stringBuilder.append(textLines[j].substring(roleEndIndex + 1, textLines[j].length()));
                    stringBuilder.append("\n");
                }
            }
            stringBuilder.append("\n");
        }

        return stringBuilder.toString();
    }


    public String doubleChar(String str) {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < str.length(); i++) {
            for (int j = 0; j < 2; j++) {
                stringBuilder.append(str.charAt(i));
            }
        }
        return new String(stringBuilder);
    }

    public static String wordEnds(String str, String word) {
        String[] arr = str.split(word);
        StringBuilder stringBuilder = new StringBuilder();
        if(arr[0].equals(""))
            stringBuilder.append(arr[0].charAt(arr[0].length() - 1));
        for (int i = 1; i < arr.length - 1; i++) {
            stringBuilder.append(arr[i].charAt(0));
            stringBuilder.append(arr[i].charAt(arr[i].length() - 1));
        }
        stringBuilder.append(arr[arr.length - 1].charAt(0));
        return new String(stringBuilder);
    }


    public static double sqrt(double x) throws IllegalArgumentException{
        if(x < 0)
            throw new IllegalArgumentException(String.format("Expected non-negative number, got %f", x));

        return Math.sqrt(x);
    }



    public static void main(String[] args) {
        */
/*System.out.println("Количество элементов в массиве:");
        Scanner in = new Scanner(System.in);
        int n = in.nextInt();

        System.out.println("Элементы массива:");
        int[] a = new int[n];
        for (int i = 0; i < n; i++) {
            a[i] = in.nextInt();
        }
        System.out.println("ai >= i :");
        for (int i = 0; i < a.length; i++) {
            if(a[i] >= i)
                System.out.println(a[i]);
        }*//*


        */
/*int[][] arr = new int[n][n];
        int[] diagonal = new int[n];
        int[] diagonal2 = new int[n];
        System.out.println("Элементы двумерного массива:");
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[i].length; j++) {
                arr[i][j] = in.nextInt();
            }
        }
        System.out.println("Главная диагональ");
        for (int i = 0, j = 0; i < arr.length; i++, j++) {
            diagonal[i] = arr[i][j];
            System.out.println(diagonal[i]);
        }
        System.out.println("Побочная диагональ");
        for (int i = 0, j = n - 1; i < arr.length; i++, j--) {
            diagonal2[i] = arr[i][j];
            System.out.println(diagonal2[i]);
        }*//*


        */
/**Lab 2 Part 2**//*


        Gun gun = new Gun();
        ColdSteel coldSteel = new ColdSteel();
        Gun gun1 = new Gun();
        ColdSteel coldSteel1 = new ColdSteel();
        ColdSteel coldSteel2 = new ColdSteel();
        ColdSteel coldSteel3 = new ColdSteel();
        Gun gun3 = new Gun();
        ArrayList<Weapon> weapons = new ArrayList<>();
        weapons.add(gun);
        weapons.add(gun1);
        weapons.add(gun3);
        weapons.add(coldSteel1);
        weapons.add(coldSteel2);
        weapons.add(coldSteel3);
        weapons.add(coldSteel);
        Armouries armouries = new Armouries(weapons);
        System.out.println("В оружейной палате:");
        armouries.printArmories();
    }
}

*/
