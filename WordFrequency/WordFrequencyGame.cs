using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (inputStr.Length == 1)
            {
                return inputStr + " 1";
            }

            string[] splitedStrings = Regex.Split(inputStr, @"\s+");

            var wordCountResult = splitedStrings.GroupBy(w => w)
                .Select(g => new WordInput(g.Key, g.Count()))
                .OrderByDescending(w => w.WordCount);

            return string.Join("\n", wordCountResult.Select(w => $"{w.WordValue} {w.WordCount}"));
        }
    }
}