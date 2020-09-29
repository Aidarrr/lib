import java.util.Arrays;

public class AsciiCharSequence implements CharSequence {
    private byte[] symbols;

    public AsciiCharSequence(byte[] symbols) {
        this.symbols = symbols;
    }

    @Override
    public int length() {
        return symbols.length;
    }

    @Override
    public char charAt(int index) {
        return (char)symbols[index];
    }

    @Override
    public AsciiCharSequence subSequence(int start, int end)
    {
        byte[] subsymb = new byte[end - start];
        for (int i = start, j = 0; i < end; i++, j++) {
            subsymb[j] = symbols[i];
        }
        AsciiCharSequence sub = new AsciiCharSequence(subsymb);
        return sub;
    }

    @Override
    public String toString()
    {
        StringBuilder str = new StringBuilder();
        for (byte e : symbols)
        {
            str.append((char)e);
        }
        return str.toString();
    }
}
