namespace GameOfLife
{
    using System.Linq;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class Validator : IValidator
    {
        private Texts texts;

        public Validator()
        {
            texts = new Texts();
        }

        public bool ValidateInt(string input)
        {
            var validInput =
              !string.IsNullOrWhiteSpace(input) &&
               input.Length < 3 &&
               input.All(char.IsDigit);

            return validInput;
        }

        public bool ValidateString(string input)
        {
            var validInput =
              !string.IsNullOrWhiteSpace(input);

            return validInput;
        }

        public bool ValidateQuestion(string input)
        {
            if (texts.True(input))
            {
                return true;
            }
            else if (texts.False(input))
            {
                return false;
            }

            return false;
        }
    }
}
