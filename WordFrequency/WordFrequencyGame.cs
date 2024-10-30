using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }

            //split the input string with 1 to n pieces of spaces
            string[] arr = Regex.Split(inputStr, @"\s+");

            List<Input> inputList = new List<Input>();
            foreach (var s in arr)
            {
                Input input = new Input(s, 1);
                inputList.Add(input);
            }

            //get the map for the next step of sizing the same word
            Dictionary<string, List<Input>> map = GetListMap(inputList);

            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            inputList = list;

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (Input w in inputList)
            {
                string s = w.Value + " " + w.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            return inputList.GroupBy(input => input.Value)
                .ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}