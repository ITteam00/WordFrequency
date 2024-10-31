namespace WordFrequency
{
    public class WordCountPair
    {
        private string value;
        private int count;

        public WordCountPair(string word, int count)
        {
            this.value = word;
            this.count = count;
        }

        public string Value
        {
            get { return this.value; }
        }

        public int WordCount
        {
            get { return this.count; }
        }
    }
}
