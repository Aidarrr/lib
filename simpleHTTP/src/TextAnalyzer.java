enum Label {
    SPAM, NEGATIVE_TEXT, TOO_LONG, OK
}

public interface TextAnalyzer {
    Label processText(String text);
}

abstract class KeywordAnalyzer implements TextAnalyzer{
    protected abstract String[] getKeywords();
    protected abstract Label getLabel();

    @Override
    public Label processText(String text) {
        for (String s : getKeywords())
        {
            if(text.contains(s))
                return getLabel();
        }
        return Label.OK;
    }
}

class SpamAnalyzer extends KeywordAnalyzer{
    private String[] keywords;

    public SpamAnalyzer(String[] keywords) {
        this.keywords = keywords;
    }

    @Override
    protected String[] getKeywords() {
        return keywords;
    }

    @Override
    protected Label getLabel() {
        return Label.SPAM;
    }
}

class NegativeTextAnalyzer extends KeywordAnalyzer{
    public NegativeTextAnalyzer() {
    }

    @Override
    protected String[] getKeywords() {
        return new String[] {":(", "=(", ":|"};
    }

    @Override
    protected Label getLabel() {
        return Label.NEGATIVE_TEXT;
    }
}

class TooLongTextAnalyzer implements TextAnalyzer{
    private int maxLength;

    public TooLongTextAnalyzer(int maxLength) {
        this.maxLength = maxLength;
    }

    @Override
    public Label processText(String text) {
        if(text.length() > maxLength)
            return Label.TOO_LONG;
        return Label.OK;
    }
}


