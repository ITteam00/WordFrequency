namespace WordFrequencyStorage.Tests
{
    public class WordFrequencyGameTest
    {
        [Fact]
        public void Should_get_the_1_when_input_the()
        {
            //Given
            string inputStr = "the";
            string expectResult = "the 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words()
        {
            //Given
            string inputStr = "the is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words_with_special_spaces()
        {
            //Given
            string inputStr = "the      is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words_with_special_enter()
        {
            //Given
            string inputStr = "the   \n   is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_pracess_two_same_words_with_sorted()
        {
            //Given
            string inputStr = "the the is";
            string expectResult = "the 2\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_sorted_with_count_descending()
        {
            //Given
            string inputStr = "the is is";
            string expectResult = "is 2\nthe 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        private void Validate_Input_words_process_to_expected_word(string inputStr, string expectResult)
        {
            WordFrequencyGame game = new WordFrequencyGame();
            //When
            string actualResult = game.GetResult(inputStr);
            //Then
            Assert.Equal(expectResult, actualResult);
        }

        [Fact]
        public void Should_process_empty_string()
        {
            //Given
            string inputStr = "";
            string expectResult = "";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_single_word_with_multiple_spaces()
        {
            //Given
            string inputStr = "   word   ";
            string expectResult = "word 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_multiple_words_with_mixed_case()
        {
            //Given
            string inputStr = "Word word WORD";
            string expectResult = "Word 1\nword 1\nWORD 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_words_with_punctuation()
        {
            //Given
            string inputStr = "hello, world! hello.";
            string expectResult = "hello, 1\nworld! 1\nhello. 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_words_with_numbers()
        {
            //Given
            string inputStr = "word1 word2 word1";
            string expectResult = "word1 2\nword2 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }
    }
}
