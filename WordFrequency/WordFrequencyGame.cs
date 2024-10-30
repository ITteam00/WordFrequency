using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            string[] splitResult = Regex.Split(inputStr, @"\s+");

            if (splitResult.Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces

                var inputList = GetInputList(splitResult);

                //get the map for the next step of sizing the same word
                Dictionary<string, List<Input>> map = GroupInputsByValue(inputList);

                List<Input> list = map.Select(entry => new Input(entry.Key, entry.Value.Count)).ToList();
     

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
