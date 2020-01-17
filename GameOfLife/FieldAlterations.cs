namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using GameOfLife.Interfaces;

    public class FieldAlterations : IFieldAlterations
    {
        private Field field;
        private IInputs inputs;
        private Random generator;

        public FieldAlterations()
        {
            field = new Field();
            inputs = new Inputs();
            generator = new Random(DateTime.Now.Millisecond);
        }

        public Field GenerateField(Field field)
        {
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

        public List<Field> CreateFieldList()
        {
            List<Field> fieldList = new List<Field>();
            field = inputs.GetUserInput();

            var round = 0;

            while (round < 1000)
            {
                Field parallelField = new Field()
                {
                    Height = field.Height,
                    Width = field.Width,
                    Cells = new bool[field.Height, field.Width],
                };

                parallelField = GenerateField(parallelField);

                fieldList.Add(parallelField);
                round++;
            }

            return fieldList;
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
