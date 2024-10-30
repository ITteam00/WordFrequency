using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<Input> inputList = CreateInputList(inputStr);

            Dictionary<string, List<Input>> map = GetListMap(inputList);

            inputList = SortList(map);

            List<string> strList = GetWordFrequencyList(inputList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> GetWordFrequencyList(List<Input> inputList)
        {
            return inputList.Select(Word => $"{Word.Value} {Word.WordCount}").ToList();
        }

        private static List<Input> SortList(Dictionary<string, List<Input>> map)
        {
            List<Input> inputList;
            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            inputList = list;

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return inputList;
        }

        private static List<Input> CreateInputList(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            return arr.Select(s => new Input(s, 1)).ToList();
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                AddInputToMap(map, input);
            }

            return map;
        }

        private static void AddInputToMap(Dictionary<string, List<Input>> map, Input input)
        {
            if (!map.ContainsKey(input.Value))
            {
                map[input.Value] = new List<Input>();

            }
            map[input.Value].Add(input);
        }
    }
}
