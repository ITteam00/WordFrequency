namespace WordFrequency
{
    public class Input
    {
        public string Value { get; }
        public int WordCount { get; }

        public Input(string value, int wordCount)
        {
            Value = value;
            WordCount = wordCount;
        }
    }
}
