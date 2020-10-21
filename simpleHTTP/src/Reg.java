/*
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Reg {
    public static void main(String[] args) {
        String text1 = "apb anb aeb aeeb adcb aveb";
        String regex1 = "a[pne]b";

        String text2 = "aba aca aea abba adda abea";
        String regex2 = "a[bd][bde]a";

        String text3 = "aba aca aea abba adcf abea";
        String regex3 = "ab[be]a";

        String text4 = "aa aba abba abbba abcd";
        String regex4 = "a[b]*a";

        String text5 = "aba aca aea abba adcf abea";
        String regex5 = "adcf";

        Pattern pattern = Pattern.compile(regex2);
        Matcher matcher = pattern.matcher(text2);

        int i = 0;
        while(matcher.find()) {
            i++;
            System.out.println(text2.substring(matcher.start(), matcher.end()));
        }
    }
}
*/
