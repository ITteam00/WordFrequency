using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SEPARATOR = " ";

        public string GetResult(string inputStr)
        {
            var inputList = GetInputList(inputStr);
            Dictionary<string, List<Input>> groupedInputs = GroupInputsByValue(inputList);
            List<Input> groupedInputList = GetGroupInputList(groupedInputs);

            string formattedResult = FormatInputs(groupedInputList);
            return formattedResult;
        }

        public string FormatInputs(List<Input> groupedInputList)
        {
            List<string> formattedWordCounts = new List<string>();

            foreach (Input w in groupedInputList)
            {
                string s = w.Word + SEPARATOR + w.WordCount;
                formattedWordCounts.Add(s);
            }
            string formattedResult = string.Join("\n", formattedWordCounts.ToArray());
            return formattedResult;
        }

        public List<Input> GetGroupInputList(Dictionary<string, List<Input>> map)
        {
            var result =  map.Select(entry => new Input(entry.Key, entry.Value.Count)).ToList();
            result.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return result;
        }

        public List<Input> GetInputList(string inputStr)
        {
            string[] splitResult = Regex.Split(inputStr, @"\s+");
            List<Input> inputList = inputList = splitResult.Select(word => new Input(word, 1)).ToList();

            return inputList;
        }

        public Dictionary<string, List<Input>> GroupInputsByValue(List<Input> inputList)
        {
            var groupedResult = inputList.GroupBy(input => input.Word).ToDictionary(group => group.Key, group => group.ToList());
            return groupedResult;
        }
    }
}
