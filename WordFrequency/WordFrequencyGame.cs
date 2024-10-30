namespace WordFrequencyStorage
{
    public class WordFrequencyGame
    {
        private const int INITIAL_FREQUENCY = 1;
        public string GetResult(string inputStr)
        {
            List<string> filteredList = inputStr.Split(new char[] { ' ', '\t', '\n', '\r' })
                                   .Where(word => !string.IsNullOrWhiteSpace(word))
                                   .ToList();

            List<WordFrequency> inputList = splitInputString(filteredList);

            List<string> wordFrequencyList = getWordListMap(ref inputList);

            wordFrequencyList.AddRange(inputList.Select(wordFrequency => wordFrequency.getWordName + " " + wordFrequency.getFrequency));

            return string.Join("\n", wordFrequencyList.ToArray());

        }

        private List<string> getWordListMap(ref List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> wordFrequencyMap = GetListMap(inputList);

            List<WordFrequency> sortedWordFrequencyList = wordFrequencyMap
                .Select(entry => new WordFrequency(entry.Key, entry.Value.Count))
                .ToList();

            inputList = sortedWordFrequencyList;

            inputList.Sort((firstWordFrequency, secondWordFrequency) => secondWordFrequency.getFrequency - firstWordFrequency.getFrequency);

            List<string> formattedWordFrequencyList = new List<string>();
            return formattedWordFrequencyList;
        }


        private static List<WordFrequency> splitInputString(List<string> filteredList)
        {
            return filteredList
                .Select(word => new WordFrequency(word, INITIAL_FREQUENCY))
                .ToList();
        }


        private Dictionary<string, List<WordFrequency>> GetListMap(List<WordFrequency> inputList)
        {
            return inputList
                .GroupBy(input => input.getWordName)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

    }
}
