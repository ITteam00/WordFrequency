using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<Input> inputList = CreateInputList(inputStr);

            List<Input> InputCountList = AggregateWordCounts(inputList);

            inputList = SortList(InputCountList);

            List<string> strList = GetWordFrequencyList(inputList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> GetWordFrequencyList(List<Input> inputList)
        {
            return inputList.Select(Word => $"{Word.Value} {Word.WordCount}").ToList();
        }

        private static List<Input> SortList(List<Input> inputList)
        {
            return inputList.OrderByDescending(Word => Word.WordCount).ToList();

        }

        private static List<Input> CreateInputList(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            return arr.Select(s => new Input(s, 1)).ToList();
        }

        private static List<Input> AggregateWordCounts(List<Input> inputList)
        {
            return inputList.GroupBy(input => input.Value)
                            .Select(group => new Input(group.Key, group.Count()))
                            .ToList();
        }
    }
}
