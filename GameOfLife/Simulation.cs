using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Simulation
    {
        private int NumOfIterations = 0;
        public void DrawAndGrowLoop(Field field)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Number of iterations: {0}", NumOfIterations);   
                DrawGame(field);
                Grow(field);
                NumOfIterations++;
                System.Threading.Thread.Sleep(100);
            }
        }

        public void DrawGame(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    Console.Write(field.cells[currentRow, currentColumn] ? "1" : " ");
                    if (currentColumn == field.Width - 1) Console.WriteLine("\r");
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
                    int numOfAliveNeighbors = GetNeighbors(currentRow, currentColumn, field);

                    if (field.cells[currentRow, currentColumn])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            field.cells[currentRow, currentColumn] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            field.cells[currentRow, currentColumn] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            field.cells[currentRow, currentColumn] = true;
                        }
                    }   
                }
            }
        }

        public int GetNeighbors(int cellRow, int cellColumn, Field field)
        {
            int NumOfAliveNeighbors = 0;
  
            for (int cellNeighborRow = cellRow - 1; cellNeighborRow < cellRow + 2; cellNeighborRow++)
            {
                for (int cellNeighborColumn = cellColumn - 1; cellNeighborColumn < cellColumn + 2; cellNeighborColumn++)
                {
                    var NegativeNeightbor = cellNeighborRow < 0 
                        || cellNeighborColumn < 0 
                        || (cellNeighborRow >= field.Height 
                        || cellNeighborColumn >= field.Width);

                    var RealCell = (cellNeighborRow == cellRow)
                        && (cellNeighborColumn == cellColumn);
                    
                    if (!NegativeNeightbor)
                    {
                        if (!RealCell)
                        {
                            if (field.cells[cellNeighborRow, cellNeighborColumn] == true) NumOfAliveNeighbors++;
                        }
                    }
                }
            }

            return NumOfAliveNeighbors;
        }
    }
}