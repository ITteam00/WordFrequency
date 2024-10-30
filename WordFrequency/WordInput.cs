namespace WordFrequency
{
    public class WordInput
    {
        public string WordValue { get; }
        public int WordCount { get; }

        public WordInput(string wordValue, int wordCount)
        {
            WordValue = wordValue;
            WordCount = wordCount;
        }
    }
}
