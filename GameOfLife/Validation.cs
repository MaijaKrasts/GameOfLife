namespace GameOfLife
{
    using System;
    using System.Linq;
    using GameOfLife.Interfaces;

    public class Validation : IValidation
    {
        private ConsoleFacade facade;

        public Validation()
        {
            facade = new ConsoleFacade();
        }

        public bool ValidateInt(string input)
        {
            var validInput =
              !string.IsNullOrWhiteSpace(input) ||
               input.Length < 3 ||
               input.All(char.IsDigit);

            return validInput;
        }

        public bool ValidateString(string input)
        {
            var validInput =
              !string.IsNullOrWhiteSpace(input);

            return validInput;
        }

        public Field VertifyInput(string inputHeight, string inputWidth)
        {
            Field field = new Field();

            if (ValidateInt(inputHeight) && ValidateInt(inputWidth))
            {
                int height = int.Parse(inputHeight);
                int width = int.Parse(inputWidth);

                field.Height = height;
                field.Width = width;
                field.Cells = new bool[height, width];
                facade.Clear();
                return field;
            }
            else
            {
                var userInput = new Inputs();
                facade.WriteLine("Height or width parameters were not right. Try again!");
                userInput.GetUserInput();
                return field;
            }
        }

        public bool ValidateQuestion(string input)
        {
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                var userInput = new Inputs();
                facade.WriteLine("Answer were not right. Try again!");
                userInput.GetUserInput();
                return false;
            }
        }
    }
}
