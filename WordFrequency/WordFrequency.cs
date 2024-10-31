namespace WordFrequencyStorage
{
    public class WordFrequency
    {
        private string word;
        private int frequency;

        public WordFrequency(string word, int frequency)
        {
            this.word = word;
            this.frequency = frequency;
        }

        public string getWordName
        {
            get { return this.word; }
        }

        public int getFrequency
        {
            get { return this.frequency; }
        }
    }
}

