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

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (Input word in wordFrequency)
                {
                    string s = word.Value + " " + word.WordCount;
                    strList.Add(s);
                }

                return string.Join("\n", strList.ToArray());
            }
        }

        private static string[] splitedAndTrim(string inputStr)
        {
            return Regex.Split(inputStr.Trim(), @"\s+");
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
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
