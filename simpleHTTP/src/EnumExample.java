enum Calculator{
    SUM { public int action (int a, int b) { return a + b; } },
    SUB { public int action (int a, int b) { return a - b; } },
    MULT { public int action (int a, int b) { return a * b; }},
    DIV { public int action (int a, int b) { return a / b; } };

    public abstract int action (int a, int b);
}

public class EnumExample {
    public static void main(String[] args) {
        Calculator c_sum = Calculator.SUM;
        Calculator c_sub = Calculator.SUB;
        Calculator c_mul = Calculator.MULT;
        Calculator c_div = Calculator.DIV;

        System.out.println(c_sum.action(10,15));
        System.out.println(c_sub.action(20,10));
        System.out.println(c_mul.action(9,9));
        System.out.println(c_div.action(48,6));


    }
}
