using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string text)
        {
            string[] splitedWords = splitedAndTrim(text);

            List<WordCountPair> wordFrequency = getWordFrequency(splitedWords);

            return formatResult(wordFrequency);
            
        }

        private static List<WordCountPair> getWordFrequency(string[] splitedWords)
        {
            return splitedWords.GroupBy(word => word)
                .Select(group => new WordCountPair(group.Key, group.Count()))
                .OrderByDescending(input => input.WordCount).ToList();
        }

        private static string formatResult(List<WordCountPair> wordFrequency)
        {
            return string.Join("\n", wordFrequency.Select(w => $"{w.Value} {w.WordCount}"));
        }

        private static string[] splitedAndTrim(string text)
        {
            return Regex.Split(text.Trim(), @"\s+");
        }
    }
}
