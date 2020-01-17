﻿namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using GameOfLife.Interfaces;

    public class FieldAlterations : IFieldAlterations
    {
        private Field field;
        private IInputs userInputs;

        public FieldAlterations()
        {
            field = new Field();
            userInputs = new Inputs();
        }

        public Field GenerateField(Field field)
        {
            double number;
            Random generator = new Random(DateTime.Now.Millisecond);

            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    number = generator.NextDouble();
                    field.Cells[currentRow, currentColumn] = number > 0.5;
                }
            }
            return field;
        }

        public List<Field> GetFieldList()
        {
            List<Field> fieldList = new List<Field>();
            field = userInputs.GetUserInput();

            var rounds = 0;

            while (rounds < 1001)
            {
                Field field2 = new Field()
                {
                    Height = field.Height,
                    Width = field.Width,
                    Cells = new bool[field.Height, field.Width],
                };

                field2 = GenerateField(field2);

                fieldList.Add(field2);
                rounds++;
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
