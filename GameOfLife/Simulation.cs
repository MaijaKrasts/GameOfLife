namespace GameOfLife
{
    using System;

    internal class Simulation
    {
        private int numOfIterations = 0;

        public void DrawAndGrowLoop(Field field)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Number of iterations: {0}", this.numOfIterations);
                this.DrawGame(field);
                this.Grow(field);
                this.numOfIterations++;
                System.Threading.Thread.Sleep(100);
            }
        }

        public void DrawGame(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    Console.Write(field.Cells[currentRow, currentColumn] ? "1" : " ");
                    if (currentColumn == field.Width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }

        public void Grow(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    int numOfAliveNeighbors = this.GetNeighbors(currentRow, currentColumn, field);

                    if (field.Cells[currentRow, currentColumn])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            field.Cells[currentRow, currentColumn] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            field.Cells[currentRow, currentColumn] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            field.Cells[currentRow, currentColumn] = true;
                        }
                    }
                }
            }
        }

        public int GetNeighbors(int cellRow, int cellColumn, Field field)
        {
            int numOfAliveNeighbors = 0;
            for (int cellNeighborRow = cellRow - 1; cellNeighborRow < cellRow + 2; cellNeighborRow++)
            {
                for (int cellNeighborColumn = cellColumn - 1; cellNeighborColumn < cellColumn + 2; cellNeighborColumn++)
                {
                    var negativeNeightbor = cellNeighborRow < 0
                        || cellNeighborColumn < 0
                        || (cellNeighborRow >= field.Height
                        || cellNeighborColumn >= field.Width);

                    var realCell = (cellNeighborRow == cellRow)
                        && (cellNeighborColumn == cellColumn);

                    if (!negativeNeightbor)
                    {
                        if (!realCell)
                        {
                            if (field.Cells[cellNeighborRow, cellNeighborColumn] == true)
                            {
                                numOfAliveNeighbors++;
                            }
                        }
                    }
                }
            }

            return numOfAliveNeighbors;
        }
    }
}