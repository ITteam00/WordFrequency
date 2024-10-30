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
            var wordCountDict = new Dictionary<string, int>();

            foreach (var input in inputList)
            {
                if (wordCountDict.ContainsKey(input.Value))
                {
                    wordCountDict[input.Value]++;
                }
                else
                {
                    wordCountDict[input.Value] = 1;
                }
            }

            return wordCountDict.Select(entry => new Input(entry.Key, entry.Value)).ToList();
        }
    }
}
