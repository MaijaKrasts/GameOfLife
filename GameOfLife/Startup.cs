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

            field = this.InputVertify(inputHeight, inputWidth, field);

            FieldAlterations fieldAlterations = new FieldAlterations();

            fieldAlterations.GenerateFieldAndRun(field);
            return field;
        }

        public Field InputVertify(string inputHeight, string inputWidth, Field field)
        {
            var empthyInput =
               string.IsNullOrWhiteSpace(inputHeight) ||
               string.IsNullOrWhiteSpace(inputWidth);

            var tooLongInput =
               inputHeight.Length > 9 ||
               inputWidth.Length > 9;

            var numericalInput =
                inputHeight.All(char.IsDigit) &&
                inputWidth.All(char.IsDigit);

            if (empthyInput || tooLongInput || !numericalInput)
            {
                Console.WriteLine("Height or width parameters were not right. Try again!");
                this.Setup();
            }
            else
            {
                int height = int.Parse(inputHeight);
                int width = int.Parse(inputWidth);

                field.Height = height;
                field.Width = width;
                field.Cells = new bool[height, width];
                Console.Clear();
            }

            return field;
        }
    }
}
