namespace GameOfLife.Base
{
    using System;

    public abstract class BaseFieldAlterations
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

            if (string.IsNullOrWhiteSpace(inputHeight) ||
                string.IsNullOrWhiteSpace(inputWidth) ||
                inputHeight.Length > 9 ||
                inputWidth.Length > 9)
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

            this.GenerateFieldAndRun(field);
            return field;
        }

        public void GenerateFieldAndRun(Field field)
        {
            this.GenerateField(field);

            SimulationLoop sim = new SimulationLoop();
            sim.DrawAndGrowLoop(field);
        }

        public Field GenerateField(Field field)
        {
            Random generator = new Random();
            int number;

            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    number = generator.Next(2);
                    field.Cells[currentRow, currentColumn] = (number == 0) ? false : true;
                }
            }

            return field;
        }
    }
}
