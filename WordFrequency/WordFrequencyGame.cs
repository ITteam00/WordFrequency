using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            string[] splitedStrings = Regex.Split(inputStr, @"\s+");

            var inputList = WordInputs(splitedStrings);

            Dictionary<string, List<WordInput>> listWordInputMap = GetListMap(inputList);

            var wordInputlist = List(listWordInputMap);

            inputList = wordInputlist;

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            var strList = StrList(inputList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> StrList(List<WordInput> inputList)
        {
            List<string> strList = inputList
                .Select(w => $"{w.WordValue} {w.WordCount}")
                .ToList();
            return strList;
        }

        private static List<WordInput> List(Dictionary<string, List<WordInput>> listWordInputMap)
        {
            List<WordInput> list = listWordInputMap
                .Select(entry => new WordInput(entry.Key, entry.Value.Count))
                .ToList();
            return list;
        }

        private static List<WordInput> WordInputs(string[] splitedStrings)
        {
            List<WordInput> inputList = splitedStrings
                .Select(s => new WordInput(s, 1))
                .ToList();
            return inputList;
        }

        private Dictionary<string, List<WordInput>> GetListMap(List<WordInput> inputList)
        {
            return inputList.GroupBy(input => input.WordValue)
                .ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}