namespace GameOfLife
{
    using System;
    using System.Linq;

    public class Startup
    {
        public Field Setup()
        {
            Field field = new Field();

            Console.WriteLine("Welcome to the Game of Life!");
            Console.WriteLine();
            Console.WriteLine("Add the parameters to create game field:");

            Console.WriteLine("Number of rows (height):");
            var inputHeight = Console.ReadLine();

            Console.WriteLine("Number of columns (width):");
            var inputWidth = Console.ReadLine();

            field = this.VertifyInput(inputHeight, inputWidth, field);
            FieldAlterations fieldAlterations = new FieldAlterations();

            fieldAlterations.GenerateFieldAndRun(field);
            return field;
        }

        public Field VertifyInput(string inputHeight, string inputWidth, Field field)
        {
            if (this.ValidateInt(inputHeight) || this.ValidateInt(inputWidth))
            {
                int height = int.Parse(inputHeight);
                int width = int.Parse(inputWidth);

                field.Height = height;
                field.Width = width;
                field.Cells = new bool[height, width];
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Height or width parameters were not right. Try again!");
                this.Setup();
            }

            return field;
        }

        public bool ValidateInt(string input)
        { 
            var validInput =
              !string.IsNullOrWhiteSpace(input) ||
               input.Length < 3 ||
               input.All(char.IsDigit);

            return validInput;
        }
    }
}
