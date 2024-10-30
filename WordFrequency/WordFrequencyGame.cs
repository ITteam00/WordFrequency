using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordCount> WordList = CreateInputList(inputStr);

            List<WordCount> WordCountList = AggregateWordCounts(WordList);

            WordCountList = SortList(WordCountList);

            List<string> strList = GetWordFrequencyList(WordCountList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> GetWordFrequencyList(List<WordCount> WordList)
        {
            return WordList.Select(curWord => $"{curWord.Word} {curWord.Count}").ToList();
        }

        private static List<WordCount> SortList(List<WordCount> WordList)
        {
            return WordList.OrderByDescending(curWord => curWord.Count).ToList();

        }

        private static List<WordCount> CreateInputList(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            return arr.Select(s => new WordCount(s, 1)).ToList();
        }

        private static List<WordCount> AggregateWordCounts(List<WordCount> WordList)
        {
            return WordList.GroupBy(curWord => curWord.Word)
                            .Select(group => new WordCount(group.Key, group.Count()))
                            .ToList();
        }
    }
}
