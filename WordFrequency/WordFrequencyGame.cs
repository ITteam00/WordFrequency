using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyStorage
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<string> filteredList = inputStr.Split(new char[] { ' ', '\t', '\n', '\r' })
                                   .Where(word => !string.IsNullOrWhiteSpace(word))
                                   .ToList();
            if (filteredList.Count() == 1)
            {
                return inputStr + " 1";
            }

            List<WordFrequency> inputList = splitInputString(filteredList);

            List<string> wordFrequencyList = getWordListMap(ref inputList);

            foreach (WordFrequency wordFrequency in inputList)
            {
                string formattedWordFrequency = wordFrequency.getWordName + " " + wordFrequency.getFrequency;
                wordFrequencyList.Add(formattedWordFrequency);
            }

            return string.Join("\n", wordFrequencyList.ToArray());

        }

        private List<string> getWordListMap(ref List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> wordFrequencyMap = GetListMap(inputList);

            List<WordFrequency> sortedWordFrequencyList = new List<WordFrequency>();
            foreach (var wordFrequencyEntry in wordFrequencyMap)
            {
                WordFrequency input = new WordFrequency(wordFrequencyEntry.Key, wordFrequencyEntry.Value.Count);
                sortedWordFrequencyList.Add(input);
            }

            inputList = sortedWordFrequencyList;

            inputList.Sort((firstWordFrequency, secondWordFrequency) => secondWordFrequency.getFrequency - firstWordFrequency.getFrequency);

            List<string> formattedWordFrequencyList = new List<string>();
            return formattedWordFrequencyList;
        }

        private static List<WordFrequency> splitInputString(List<string> filteredList)
        {
            List<WordFrequency> inputList = new List<WordFrequency>();
            foreach (var word in filteredList)
            {
                WordFrequency input = new WordFrequency(word, 1);
                inputList.Add(input);
            }

            return inputList;
        }

        private Dictionary<string, List<WordFrequency>> GetListMap(List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> wordFrequencyDictionary = new Dictionary<string, List<WordFrequency>>();
            foreach (var input in inputList)
            {
                if (!wordFrequencyDictionary.ContainsKey(input.getWordName))
                {
                    List<WordFrequency> wordFrequencyList = new List<WordFrequency>();
                    wordFrequencyList.Add(input);
                    wordFrequencyDictionary.Add(input.getWordName, wordFrequencyList);
                }
                else
                {
                    wordFrequencyDictionary[input.getWordName].Add(input);
                }
            }

            return wordFrequencyDictionary;
        }
    }
}
