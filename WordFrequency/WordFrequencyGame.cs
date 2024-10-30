using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordCount> inputList = CreateInputList(inputStr);

            List<WordCount> InputCountList = AggregateWordCounts(inputList);

            inputList = SortList(InputCountList);

            List<string> strList = GetWordFrequencyList(inputList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> GetWordFrequencyList(List<WordCount> inputList)
        {
            return inputList.Select(curWord => $"{curWord.Word} {curWord.Count}").ToList();
        }

        private static List<WordCount> SortList(List<WordCount> inputList)
        {
            return inputList.OrderByDescending(curWord => curWord.Count).ToList();

        }

        private static List<WordCount> CreateInputList(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            return arr.Select(s => new WordCount(s, 1)).ToList();
        }

        private static List<WordCount> AggregateWordCounts(List<WordCount> inputList)
        {
            return inputList.GroupBy(curWord => curWord.Word)
                            .Select(group => new WordCount(group.Key, group.Count()))
                            .ToList();
        }
    }
}
