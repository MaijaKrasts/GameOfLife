namespace GameOfLife
{
    using System;
    using GameOfLife.Interfaces;

    internal class FieldAlterations: IField, ISeedField
    {
        public Field GenerateField(Field field)
        {
            Random generator = new Random();
            int number;

            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    number = generator.Next(2);
                    field.Cells[currentRow, currentColumn] = number != 0;
                }
            }

            return field;
        }

        public Field SeedField(Field field)
        {
            field.Height = 3;
            field.Width = 3;

            field.Cells[0, 0] = false;
            field.Cells[0, 1] = false;
            field.Cells[0, 2] = false;
            field.Cells[1, 0] = true;
            field.Cells[1, 1] = true;
            field.Cells[1, 2] = true;
            field.Cells[2, 0] = false;
            field.Cells[2, 1] = false;
            field.Cells[2, 2] = false;

            return field;
        }
    }
}
