public class ExceptionsTest {
    public static void main(String[] args) {

        int c, a = 4, b = 1;

        try {
            c = a / b;
        } catch (ArithmeticException e) {
            System.out.println("Обнаружено деление на 0");
            System.out.println(e.toString());
        }

        try {
            divide(4.0, 2.0);
        }
        catch (ArithmeticException e){
            e.printStackTrace();
        }

        try {
            divide2(5.0,0.0);
        } catch (DivideByZeroException e) {
            e.printStackTrace();
        }
    }

    public static double divide(double a, double b) throws ArithmeticException {

        if (b == 0) {
            throw new ArithmeticException("В делителе 0");
        }

        return a / b;
    }

    public static double divide2(double a, double b) throws DivideByZeroException{
        if(b == 0){
            throw new DivideByZeroException();
        }

        return a/b;
    }
}

class DivideByZeroException extends Exception {
    private String message = " by zero";

    public DivideByZeroException(String message) {
        this.message = message;
    }

    public DivideByZeroException() {

    }

    public String toString() {
        return message;
    }
}