using System;
using System.Collections.Generic;
using Xunit;

namespace WordFrequency.Tests
{
    public class WordFrequencyGameTest
    {
        [Theory]
        [InlineData("the", "the 1")]
        [InlineData("the is", "the 1\nis 1")]
        [InlineData("the      is", "the 1\nis 1")]
        [InlineData("the   \n   is", "the 1\nis 1")]
        [InlineData("the the is", "the 2\nis 1")]
        [InlineData("the is is", "is 2\nthe 1")]
        public void ShouldProcessInputWordsCorrectly(string inputStr, string expectResult)
        {
            ValidateInputWordsProcessToExpectedWord(inputStr, expectResult);
        }

        private void ValidateInputWordsProcessToExpectedWord(string inputStr, string expectResult)
        {
            WordFrequencyGame game = new WordFrequencyGame();
            // When
            string actualResult = game.GetResult(inputStr);
            // Then
            Assert.Equal(expectResult, actualResult);
        }

        [Fact]
        public void ShouldFormatInputsCorrectly()
        {
            var inputs = new List<Input>
            {
                new Input("the", 2),
                new Input("is", 1)
            };
            var game = new WordFrequencyGame();
            string result = game.FormatInputs(inputs);
            Assert.Equal("the 2\nis 1", result);
        }

        [Fact]
        public void ShouldGroupInputsByValueCorrectly()
        {
            var inputs = new List<Input>
            {
                new Input("the", 1),
                new Input("the", 1),
                new Input("is", 1)
            };
            var game = new WordFrequencyGame();
            var groupedInputs = game.GroupInputsByValue(inputs);
            Assert.Equal(2, groupedInputs["the"].Count);
            Assert.Single(groupedInputs["is"]);
        }

        [Fact]
        public void ShouldGetGroupedInputListCorrectly()
        {
            var groupedInputs = new Dictionary<string, List<Input>>
            {
                { "the", new List<Input> { new Input("the", 1), new Input("the", 1) } },
                { "is", new List<Input> { new Input("is", 1) } }
            };
            var game = new WordFrequencyGame();
            var result = game.GetGroupInputList(groupedInputs);
            Assert.Equal(2, result[0].WordCount);
            Assert.Equal("the", result[0].Word);
            Assert.Equal(1, result[1].WordCount);
            Assert.Equal("is", result[1].Word);
        }

        [Fact]
        public void ShouldGetInputListCorrectly()
        {
            string inputStr = "the is the";
            var game = new WordFrequencyGame();
            var result = game.GetInputList(inputStr);
            Assert.Equal(3, result.Count);
            Assert.Equal("the", result[0].Word);
            Assert.Equal("is", result[1].Word);
            Assert.Equal("the", result[2].Word);
        }
    }
}
