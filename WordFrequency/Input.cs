namespace WordFrequency
{
    public class Input
    {
        private string word;
        private int count;

        public Input(string w, int i)
        {
            this.word = w;
            this.count = i;
        }

        public string Value
        {
            get { return this.word; }
        }

        public int WordCount
        {
            get { return this.count; }
        }
    }
}
