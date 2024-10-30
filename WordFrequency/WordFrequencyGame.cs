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
                var wordFrequency = wordList.GroupBy(word => word)
                    .Select(group => new Input(group.Key, group.Count()))
                    .OrderByDescending(input => input.WordCount).ToList();
                return formatResult(wordFrequency);
            }
        }

        private static string formatResult(List<Input> wordFrequency)
        {
            List<string> strList = new List<string>();

            foreach (Input word in wordFrequency)
            {
                string s = word.Value + " " + word.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private static string[] splitedAndTrim(string inputStr)
        {
            return Regex.Split(inputStr.Trim(), @"\s+");
        }
    }
}
