namespace GameOfLife
{
    using System;
    using GameOfLife.Interfaces;

    public class Display : IDisplayLoop, ILiveCells
    {
        private int numOfIterations = 1;
        private int numOfLiveCells = 0;

        public int AddLiveCells()
        {
            return this.numOfLiveCells++;
        }

        public void CreateNewGame(Field field)
        {
            var sim = new SimulationLoop();
            sim.FillCellList(field);
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
                        Console.Write("#");
                        this.AddLiveCells();
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    if (currentColumn == field.Width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }
        }

        public void PrintResultsLoop(Field field)
        {
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    this.numOfLiveCells = 0;
                    Console.Clear();
                    Console.WriteLine("Number of iterations: {0}", this.numOfIterations);
                    this.DrawGame(field);

                    this.CreateNewGame(field);

                    Console.WriteLine("Number of live cells: {0}", this.numOfLiveCells);
                    this.numOfIterations++;
                    Console.SetCursorPosition(0, Console.WindowTop);
                    System.Threading.Thread.Sleep(1000);
                }

                Console.Clear();
                Console.WriteLine("Game stoped!");
                break;
            }
        }
    }
}
