namespace GameOfLife
{
    using System;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class Display : IDisplay
    {
        private int numOfLiveCells;

        private IConsoleFacade facade;
        private ITexts texts;

        public Display()
        {
            facade = new ConsoleFacade();
            texts = new Texts();
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
                        facade.Write(texts.Symbol());
                        AddLiveCells();
                    }
                    else
                    {
                        facade.Write(texts.Empthy());
                    }

                    if (currentColumn == field.Width - 1)
                    {
                        facade.WriteLine(texts.Return());
                    }
                }
            }
        }

        public void WriteProperties (int numOfIterations)
        {
            facade.Count(texts.Interations(), numOfIterations);
            facade.Count(texts.LiveCells(), numOfLiveCells);

            numOfLiveCells = 0;
            Console.SetCursorPosition(0, Console.WindowTop);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
