using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            string[] wordList = splitedAndTrim(inputStr);

            if (wordList.Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                List<Input> wordFrequency = getWordFrequency(wordList);

                return formatResult(wordFrequency);
            }
        }

        private static List<Input> getWordFrequency(string[] wordList)
        {
            return wordList.GroupBy(word => word)
                .Select(group => new Input(group.Key, group.Count()))
                .OrderByDescending(input => input.WordCount).ToList();
        }

        private static string formatResult(List<Input> wordFrequency)
        {
            return string.Join("\n", wordFrequency.Select(w => $"{w.Value} {w.WordCount}"));
        }

        private static string[] splitedAndTrim(string inputStr)
        {
            return Regex.Split(inputStr.Trim(), @"\s+");
        }
    }
}
