﻿namespace GameOfLife.Base
{
    using System;
    using GameOfLife.Models;

    public abstract class BaseSimulationLoop
    {
        private int numOfIterations = 1;
        private int numOfLiveCells = 0;

        public void DrawAndGrowLoop(Field field)
        {
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    this.numOfLiveCells = 0;
                    Console.Clear();
                    Console.WriteLine("Number of iterations: {0}", this.numOfIterations);
                    this.DrawGame(field);
                    this.Grow(field);
                    Console.WriteLine("Number of live cells: {0}", this.numOfLiveCells);
                    this.numOfIterations++;
                    Console.SetCursorPosition(0, Console.WindowTop);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Clear();
                Console.WriteLine("Game stoped!");
                break;
            }
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

        public int AddLiveCells()
        {
            return this.numOfLiveCells++;
        }

        public void Grow(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    this.CheckLifeStatuss(currentRow, currentColumn, field);
                }
            }
        }

        public bool CheckLifeStatuss(int currentRow, int currentColumn, Field field)
        {
            int numOfAliveNeighbors = this.FindNeighbors(currentRow, currentColumn, field);

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

            return field.Cells[currentRow, currentColumn];
        }

        public int FindNeighbors(int cellRow, int cellColumn, Field field)
        {
            int numOfAliveNeighbors = 0;

            for (int cellNeighborRow = cellRow - 1; cellNeighborRow < cellRow + 2; cellNeighborRow++)
            {
                for (int cellNeighborColumn = cellColumn - 1; cellNeighborColumn < cellColumn + 2; cellNeighborColumn++)
                {
                    NeighborCell neighbor = new NeighborCell()
                    {
                        CellColumn = cellColumn,
                        CellNeighborColumn = cellNeighborColumn,
                        CellNeighborRow = cellNeighborRow,
                        CellRow = cellRow,
                        AliveNeighbors = numOfAliveNeighbors,
                    };

                    this.GetAliveNeighbors(neighbor, field);
                    numOfAliveNeighbors = neighbor.AliveNeighbors;
                }
            }

            return numOfAliveNeighbors;
        }

        public NeighborCell GetAliveNeighbors(NeighborCell neighbor, Field field)
        {
            var negativeNeightbor = neighbor.CellNeighborRow < 0
             || neighbor.CellNeighborColumn < 0
             || neighbor.CellNeighborRow >= field.Height
             || neighbor.CellNeighborColumn >= field.Width;

            var realCell = (neighbor.CellNeighborRow == neighbor.CellRow)
                && (neighbor.CellNeighborColumn == neighbor.CellColumn);

            if (!negativeNeightbor)
            {
                if (!realCell)
                {
                    if (field.Cells[neighbor.CellNeighborRow, neighbor.CellNeighborColumn] == true)
                    {
                        neighbor.AliveNeighbors++;
                    }
                }
            }

            return neighbor;
        }
    }
}