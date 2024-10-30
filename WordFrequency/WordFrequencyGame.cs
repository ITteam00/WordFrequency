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

            //split the input string with 1 to n pieces of spaces
            string[] splitedStrings = Regex.Split(inputStr, @"\s+");

            List<WordInput> inputList = splitedStrings
                .Select(s => new WordInput(s, 1))
                .ToList();

            //get the map for the next step of sizing the same word
            Dictionary<string, List<WordInput>> listWordInputMap = GetListMap(inputList);

            List<WordInput> list = listWordInputMap
                .Select(entry => new WordInput(entry.Key, entry.Value.Count))
                .ToList();

            inputList = list;

            list.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = inputList
                .Select(w => $"{w.WordValue} {w.WordCount}")
                .ToList();

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, List<WordInput>> GetListMap(List<WordInput> inputList)
        {
            return inputList.GroupBy(input => input.WordValue)
                .ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}