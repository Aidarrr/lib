import java.math.BigInteger;
import java.util.function.DoubleUnaryOperator;

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


    public static void main(String[] args) {
        String [] roles= {
                "Городничий","Аммос Федорович",
                "Артемий Филиппович",
                "Лука Лукич"};
        String [] textLines={"Городничий: Я пригласил вас, господа, с тем, чтобы сообщить вам пренеприятное известие: к нам едет ревизор.",
                "Аммос Федорович: Как ревизор?",
                "Артемий Филиппович: Как ревизор?",
                "Городничий: Ревизор из Петербурга, инкогнито. И еще с секретным предписаньем.",
                "Аммос Федорович: Вот те на!",
                "Артемий Филиппович: Вот не было заботы, так подай!",
                "Лука Лукич: Господи боже! еще и с секретным предписаньем!"};
        System.out.println(printTextPerRole(roles, textLines));
        }
}
