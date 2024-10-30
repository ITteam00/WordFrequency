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
                //split the input string with 1 to n pieces of spaces
                List<Input> inputList = (from word in wordList
                                         let input = new Input(word, 1)
                                         select input).ToList();

                //get the map for the next step of sizing the same word
                Dictionary<string, List<Input>> wordCountsMap = GetListMap(inputList);

                List<Input> wordFrequency = (from word in wordCountsMap
                                    let input = new Input(word.Key, word.Value.Count)
                                    select input).ToList();

                wordFrequency.Sort((w1, w2) => w2.WordCount - w1.WordCount);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (Input w in inputList)
                {
                    string s = w.Value + " " + w.WordCount;
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
