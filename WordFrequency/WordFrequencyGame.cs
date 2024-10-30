using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyStorage
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] arr = Regex.Split(inputStr, @"\s+");

                List<WordFrequency> inputList = new List<WordFrequency>();
                foreach (var s in arr)
                {
                    WordFrequency input = new WordFrequency(s, 1);
                    inputList.Add(input);
                }

                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordFrequency>> map = GetListMap(inputList);

                List<WordFrequency> list = new List<WordFrequency>();
                foreach (var entry in map)
                {
                    WordFrequency input = new WordFrequency(entry.Key, entry.Value.Count);
                    list.Add(input);
                }

                inputList = list;

                inputList.Sort((w1, w2) => w2.getFrequency - w1.getFrequency);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (WordFrequency w in inputList)
                {
                    string s = w.getWordName + " " + w.getFrequency;
                    strList.Add(s);
                }

                return string.Join("\n", strList.ToArray());
            }
        }

        private Dictionary<string, List<WordFrequency>> GetListMap(List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> map = new Dictionary<string, List<WordFrequency>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.getWordName))
                {
                    List<WordFrequency> arr = new List<WordFrequency>();
                    arr.Add(input);
                    map.Add(input.getWordName, arr);
                }
                else
                {
                    map[input.getWordName].Add(input);
                }
            }

            return map;
        }
    }
}
