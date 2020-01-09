namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class FieldAlterations
    {
        public Field GiveParameters()
        {
            Field field = new Field();

            Console.WriteLine("Welcome to the Game of Life!");
            Console.WriteLine();
            Console.WriteLine("Add the parameters to create game field:");

            Console.WriteLine("Number of rows (height):");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of columns (width):");
            int width = int.Parse(Console.ReadLine());

            field.Height = height;
            field.Width = width;
            field.Cells = new bool[height, width];
            Console.Clear();

            this.GenerateField(field);

            return field;
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

            Simulation sim = new Simulation();
            sim.DrawAndGrowLoop(field);

            return field;
        }
    }
}
