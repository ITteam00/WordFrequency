using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyStorage
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (inputStr.Split(new char[] { ' ', '\t', '\n', '\r' }).Where(word => !string.IsNullOrWhiteSpace(word)).Count() == 1)
            {
                return inputStr + " 1";
            }

            List<WordFrequency> inputList = splitInputString(inputStr);

            List<string> strList = getWordListMap(ref inputList);

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (WordFrequency w in inputList)
            {
                string s = w.getWordName + " " + w.getFrequency;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());

        }

        private List<string> getWordListMap(ref List<WordFrequency> inputList)
        {
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
            return strList;
        }

        private static List<WordFrequency> splitInputString(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            List<WordFrequency> inputList = new List<WordFrequency>();
            foreach (var s in arr)
            {
                WordFrequency input = new WordFrequency(s, 1);
                inputList.Add(input);
            }

            return inputList;
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
