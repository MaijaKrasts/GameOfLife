namespace GameOfLife
{
    using System;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class Display : IDisplay
    {
        private int numOfLiveCells;

        private IConsoleFacade facade;

        public Display()
        {
            facade = new ConsoleFacade();
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

        public void DrawRepetitiousGame(Field field)
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

        public void WriteProperties (int numOfIterations)
        {
            facade.Count(Texts.Interations, numOfIterations);
            facade.Count(Texts.LiveCells, numOfLiveCells);

            numOfLiveCells = 0;
            Console.SetCursorPosition(0, Console.WindowTop);
            System.Threading.Thread.Sleep(300);
        }

        public void Sleep()
        { System.Threading.Thread.Sleep(4000); }
    }
}
