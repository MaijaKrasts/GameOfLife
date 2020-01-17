namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class Display : IDisplay
    {
        private int numOfLiveCells;

        private IConsoleFacade facade;
        private Field field;

        public Display()
        {
            facade = new ConsoleFacade();
            field = new Field();
        }

        public int AddLiveCells()
        {
            return numOfLiveCells++;
        }

        public void DrawGame(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    var currentCell = field.Cells[currentRow, currentColumn];
                    if (currentCell)
                    {
                        facade.Write(Texts.Symbol);
                        AddLiveCells();
                    }
                    else
                    {
                        facade.Write(Texts.Empthy);
                    }

                    if (currentColumn == field.Width - 1)
                    {
                        facade.WriteLine(Texts.Return);
                    }
                }
            }
        }

        public void DrawMultipleGames(List<Field> fieldList)
        {
            int num = 0;
            int index = 0;

            while (num < 8)
            {
                field = fieldList[index];

                for (int currentRow = 0; currentRow < field.Height; currentRow++)
                {
                    for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                    {
                        var currentCell = field.Cells[currentRow, currentColumn];
                        if (currentCell)
                        {
                            facade.Write(Texts.Symbol);
                            AddLiveCells();
                        }
                        else
                        {
                            facade.Write(Texts.Empthy);
                        }

                        if (currentColumn == field.Width - 1)
                        {
                            facade.WriteLine(Texts.Return);
                        }
                    }
                }
                index++;
                num++;
            }
        }

        public void WriteProperties (int numOfIterations)
        {
            facade.Count(Texts.Interations, numOfIterations);
            facade.Count(Texts.LiveCells, numOfLiveCells);

            numOfLiveCells = 0;
            Console.SetCursorPosition(0, 0);
            Sleep();
        }

        public void Sleep()
        { System.Threading.Thread.Sleep(1000); }

        public void WritePropertiesForMultiple(int numOfIterations, int games)
        {
            facade.Count(Texts.Interations, numOfIterations);
            facade.Count(Texts.Games, games);
            Console.SetCursorPosition(0, 0);
            Sleep();
        }
    }
}
