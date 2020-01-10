namespace GameOfLife
{
    using System;

    internal class FieldAlterations
    {
        public void GenerateFieldAndRun(Field field)
        {
            // this.GenerateField(field);
            this.SeedField(field);

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

        public Field SeedField(Field field)
        {
            field.Height = 3;
            field.Width = 3;

            field.Cells[0, 0] = false;
            field.Cells[0, 1] = true;
            field.Cells[0, 2] = false;
            field.Cells[1, 0] = false;
            field.Cells[1, 1] = true;
            field.Cells[1, 2] = false;
            field.Cells[2, 0] = false;
            field.Cells[2, 1] = true;
            field.Cells[2, 2] = false;

            return field;
        }
    }
}
