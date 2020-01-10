namespace GameOfLife
{
    using System;

    internal class FieldAlterations
    {
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
