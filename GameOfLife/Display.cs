namespace GameOfLife
{
    using System;
    using GameOfLife.Interfaces;

    public class Display : IDisplay
    {
        private ConsoleFacade facade;
        private int numOfLiveCells;

        public Display()
        {
            facade = new ConsoleFacade();
        }

        public int AddLiveCells()
        {
            return this.numOfLiveCells++;
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
                        facade.Write("#");
                        this.AddLiveCells();
                    }
                    else
                    {
                        facade.Write(" ");
                    }

                    if (currentColumn == field.Width - 1)
                    {
                        facade.WriteLine("\r");
                    }
                }
            }
        }

        public void WriteProperties (int numOfIterations)
        {
            Console.WriteLine("Number of iterations: {0}", numOfIterations);
            Console.WriteLine("Number of live cells: {0}", numOfLiveCells);
            numOfLiveCells = 0;
            Console.SetCursorPosition(0, Console.WindowTop);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
