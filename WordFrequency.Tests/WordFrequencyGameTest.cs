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
    }
}
