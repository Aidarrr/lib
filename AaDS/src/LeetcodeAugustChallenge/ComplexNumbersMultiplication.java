package LeetcodeAugustChallenge;

class ComplexNumber {
    int real, imaginary;

    public ComplexNumber(int real, int imaginary) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public ComplexNumber(String stringNum) {
        StringBuilder sbForRealPart = new StringBuilder();
        int currentIndex = 0;

        while (stringNum.charAt(currentIndex) != '+') {
            sbForRealPart.append(stringNum.charAt(currentIndex));
            currentIndex++;
        }

        StringBuilder sbForImaginaryPart = new StringBuilder();
        currentIndex++;

        while (stringNum.charAt(currentIndex) != 'i') {
            sbForImaginaryPart.append(stringNum.charAt(currentIndex));
            currentIndex++;
        }

        real = Integer.parseInt(sbForRealPart.toString());
        imaginary = Integer.parseInt(sbForImaginaryPart.toString());
    }

    public ComplexNumber multiplyOnAnotherNumber(ComplexNumber other) {
        int real = this.real * other.real - this.imaginary * other.imaginary;
        int imaginary = this.real * other.imaginary + this.imaginary * other.real;

        return new ComplexNumber(real, imaginary);
    }

    @Override
    public String toString() {
        return String.valueOf(real) + "+" + String.valueOf(imaginary) + "i";
    }
}

public class ComplexNumbersMultiplication {
    public String complexNumberMultiply(String num1, String num2) {
        ComplexNumber firstComplexNum = new ComplexNumber(num1);
        ComplexNumber secondComplexNum = new ComplexNumber(num2);
        ComplexNumber multiplicationResult = firstComplexNum.multiplyOnAnotherNumber(secondComplexNum);

        return multiplicationResult.toString();
    }

    public static void main(String[] args) {
        ComplexNumbersMultiplication multiplication = new ComplexNumbersMultiplication();

        System.out.println(multiplication.complexNumberMultiply("1+-1i", "1+-1i"));
    }
}
