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
            string[] splitResult = Regex.Split(inputStr, @"\s+");

            if (splitResult.Length == 1)
            {
                return inputStr + SEPARATOR +"1";
            }
            else
            {
                var inputList = GetInputList(splitResult);
                Dictionary<string, List<Input>> groupedInputs = GroupInputsByValue(inputList);
                List<Input> groupedInputList = GetGroupInputList(groupedInputs);

                string formattedResult = formatInputs(groupedInputList);
                return formattedResult;
            }
        }

        private static string formatInputs(List<Input> groupedInputList)
        {
            List<string> formattedWordCounts = new List<string>();

            foreach (Input w in groupedInputList)
            {
                string s = w.Value + SEPARATOR + w.WordCount;
                formattedWordCounts.Add(s);
            }
            string formattedResult = string.Join("\n", formattedWordCounts.ToArray());
            return formattedResult;
        }

        private static List<Input> GetGroupInputList(Dictionary<string, List<Input>> map)
        {
            var result =  map.Select(entry => new Input(entry.Key, entry.Value.Count)).ToList();
            result.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return result;
        }

        private static List<Input> GetInputList(string[] splitResult)
        {
            List<Input> inputList = new List<Input>();

            foreach (var s in splitResult)
            {
                Input input = new Input(s, 1);
                inputList.Add(input);
            }
            return inputList;
        }

        private Dictionary<string, List<Input>> GroupInputsByValue(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                if (!map.ContainsKey(input.Value))
                {
                    List<Input> arr = new List<Input>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}
